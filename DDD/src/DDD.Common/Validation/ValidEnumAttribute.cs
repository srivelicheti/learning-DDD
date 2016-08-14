using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace DDD.Common.Validation
{
    public class ValidEnumAttribute : ValidationAttribute
    {
        private Type EnumType { get; }

        private Type ValueType { get; }

        private Type BaseType { get; }
        public ValidEnumAttribute(Type enumType)
        {
            EnumType = enumType;
            var typeInfo = EnumType.GetTypeInfo();
            BaseType = typeInfo.BaseType;
            if (BaseType == null || !(BaseType.GetGenericTypeDefinition() == typeof(Enumeration<,>)))
                throw new Exception("Invalid Enumeration type. Enums should be derived from Enumeration<,> generic type");

            ValueType = BaseType.GetGenericArguments()[1];

        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            var isValid = value != null &&  ValueType == value.GetType();

            if (isValid)
            {
                isValid = (bool)BaseType.GetMethod("IsValid").Invoke(null, new[] { value });
            }
            if (!isValid)
            {
                return new ValidationResult($"{value} is not a valid value for type {EnumType.Name}");
            }
            return ValidationResult.Success;
        }
    }
}
