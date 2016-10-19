using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using NServiceBus;
using NServiceBus.Container;
using NServiceBus.Settings;
using StructureMap;
using StructureMap.Pipeline;
using StructureMap.Query;

namespace DDD.Web.Api
{
    internal class NServiceBusStructureMapObjectBuilder : NServiceBus.ObjectBuilder.Common.IContainer, IDisposable
    {
        private StructureMap.IContainer container;

        private IDictionary<Type, Instance> configuredInstances = new Dictionary<Type, Instance>();

        private int disposeSignaled;

        private bool disposed;

        public NServiceBusStructureMapObjectBuilder()
        {
            this.container = new Container();
        }

        public NServiceBusStructureMapObjectBuilder(StructureMap.IContainer container)
        {
            this.container = container;
        }

        public void Dispose()
        {
            if (Interlocked.Exchange(ref this.disposeSignaled, 1) != 0)
            {
                return;
            }
            if (this.container != null)
            {
                this.container.Dispose();
                this.container = null;
            }
            this.disposed = true;
        }

        public NServiceBus.ObjectBuilder.Common.IContainer BuildChildContainer()
        {
            this.ThrowIfDisposed();
            return new NServiceBusStructureMapObjectBuilder(this.container.GetNestedContainer());
        }

        public object Build(Type typeToBuild)
        {
            this.ThrowIfDisposed();
            if (this.container.Model.PluginTypes.Any((IPluginTypeConfiguration t) => t.PluginType == typeToBuild))
            {
                return this.container.GetInstance(typeToBuild);
            }
            throw new ArgumentException(typeToBuild + " is not registered in the container");
        }

        public IEnumerable<object> BuildAll(Type typeToBuild)
        {
            this.ThrowIfDisposed();
            return this.container.GetAllInstances(typeToBuild).Cast<object>();
        }

        public void ConfigureProperty(Type component, string property, object value)
        {
            this.ThrowIfDisposed();
            if (value == null)
            {
                return;
            }
            lock (this.configuredInstances)
            {
                Instance instance;
                this.configuredInstances.TryGetValue(component, out instance);
                ConfiguredInstance configuredInstance = instance as ConfiguredInstance;
                if (configuredInstance == null)
                {
                    throw new InvalidOperationException("Cannot configure property before the component has been configured. Please call 'Configure' first.");
                }
                configuredInstance.Dependencies.Add(property, value);
            }
        }

        public void Configure(Type component, DependencyLifecycle dependencyLifecycle)
        {
            this.ThrowIfDisposed();
            lock (this.configuredInstances)
            {
                if (this.configuredInstances.ContainsKey(component))
                {
                    return;
                }
            }
            ILifecycle lifecycle = NServiceBusStructureMapObjectBuilder.GetLifecycleFrom(dependencyLifecycle);
            ConfiguredInstance configuredInstance = null;
            this.container.Configure(delegate (ConfigurationExpression x)
            {
                configuredInstance = x.For(component, null).LifecycleIs(lifecycle).Use(component);
                x.EnableSetterInjectionFor(component);
                List<Type> list = NServiceBusStructureMapObjectBuilder.GetAllInterfacesImplementedBy(component).ToList<Type>();
                foreach (Type current in list)
                {
                    x.For(current, null).LifecycleIs(lifecycle).Use((IContext c) => c.GetInstance(component));
                    x.EnableSetterInjectionFor(current);
                }
            });
            lock (this.configuredInstances)
            {
                this.configuredInstances.Add(component, configuredInstance);
            }
        }

        public void Configure<T>(Func<T> componentFactory, DependencyLifecycle dependencyLifecycle)
        {
            this.ThrowIfDisposed();
            Type pluginType = typeof(T);
            lock (this.configuredInstances)
            {
                if (this.configuredInstances.ContainsKey(pluginType))
                {
                    return;
                }
            }
            ILifecycle lifecycle = NServiceBusStructureMapObjectBuilder.GetLifecycleFrom(dependencyLifecycle);
            LambdaInstance<T, T> lambdaInstance = null;
            this.container.Configure(delegate (ConfigurationExpression x)
            {
                lambdaInstance = x.For<T>(null).LifecycleIs(lifecycle).Use<T>("Custom constructor func", componentFactory);
                x.EnableSetterInjectionFor(pluginType);
                foreach (Type current in NServiceBusStructureMapObjectBuilder.GetAllInterfacesImplementedBy(pluginType))
                {
                    x.For(current, null).Use((IContext c) => (object)c.GetInstance<T>());
                    x.EnableSetterInjectionFor(current);
                }
            });
            lock (this.configuredInstances)
            {
                this.configuredInstances.Add(pluginType, lambdaInstance);
            }
        }

        public void RegisterSingleton(Type lookupType, object instance)
        {
            this.ThrowIfDisposed();
            this.container.Configure(delegate (ConfigurationExpression x)
            {
                x.For(lookupType, null).Singleton().Use(instance);
                x.EnableSetterInjectionFor(lookupType);
            });
        }

        public bool HasComponent(Type componentType)
        {
            this.ThrowIfDisposed();
            return this.container.Model.PluginTypes.Any((IPluginTypeConfiguration t) => t.PluginType == componentType);
        }

        public void Release(object instance)
        {
            this.ThrowIfDisposed();
        }

        private static ILifecycle GetLifecycleFrom(DependencyLifecycle dependencyLifecycle)
        {
            switch (dependencyLifecycle)
            {
                case DependencyLifecycle.SingleInstance:
                    return new SingletonLifecycle();
                case DependencyLifecycle.InstancePerUnitOfWork:
                    return null;
                case DependencyLifecycle.InstancePerCall:
                    return new UniquePerRequestLifecycle();
                default:
                    throw new ArgumentException("Unhandled lifecycle - " + dependencyLifecycle);
            }
        }

        private static IEnumerable<Type> GetAllInterfacesImplementedBy(Type t)
        {
            return from x in t.GetInterfaces()
                   where !x.FullName.StartsWith("System.")
                   select x;
        }

        private void ThrowIfDisposed()
        {
            if (this.disposed)
            {
                throw new ObjectDisposedException("StructureMapObjectBuilder");
            }
        }

        //NServiceBus.ObjectBuilder.Common.IContainer NServiceBus.ObjectBuilder.Common.IContainer.BuildChildContainer()
        //{
        //    throw new NotImplementedException();
        //}
    }

    internal static class ConfigurationExpressionExtensions
    {
        public static void EnableSetterInjectionFor(this ConfigurationExpression configuration, Type pluginType)
        {
            configuration.Policies.SetAllProperties(x =>
            {
                x.TypeMatches((Type t) => t == pluginType);
            });
        }
    }


    public class StructureMapBuilder : ContainerDefinition
    {
        public override NServiceBus.ObjectBuilder.Common.IContainer CreateContainer(ReadOnlySettings settings)
        {
            StructureMap.IContainer container;
            if (settings.TryGet<StructureMap.IContainer>("ExistingContainer", out container))
            {
                return new NServiceBusStructureMapObjectBuilder(container);
            }
            return new NServiceBusStructureMapObjectBuilder();
        }
    }

    public static class StructureMapExtensions
    {
        public static void ExistingContainer(this ContainerCustomizations customizations, StructureMap.IContainer container)
        {
            customizations.Settings.Set("ExistingContainer", container);
        }
    }
}
