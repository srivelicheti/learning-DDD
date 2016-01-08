using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using System.Collections.Generic;
using System.Linq;

namespace DDD.Provider.DataModel
{
    public partial class POC_DDDContext : DbContext
    {
       
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Data Source=.\sql2014;Initial Catalog=POC_DDD;Integrated Security=False;User ID=srvelicheti;Password=Secret@123");
            var t = new List<int>();
            t.FirstOrDefault(x => x == 20);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contractor>(entity =>
            {
                entity.ToTable("Contractor", "Provider");

                entity.Property(e => e.ID).ValueGeneratedNever();

                entity.Property(e => e.AddressLine1)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.AddressLine2).HasMaxLength(150);

                entity.Property(e => e.AlternatePhoneNumber).HasMaxLength(13);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ContactAlternatePhoneNumber).HasMaxLength(10);

                entity.Property(e => e.ContactEmail).HasMaxLength(50);

                entity.Property(e => e.ContactFirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ContactLastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ContactPhoneNumber)
                    .IsRequired()
                    .HasMaxLength(13);

                entity.Property(e => e.ContractEndDate).HasColumnType("date");

                entity.Property(e => e.ContractorName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ContractStartDate).HasColumnType("date");

                entity.Property(e => e.DoingBusinessAs)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EinNumber)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstInsertedBy)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstInsertedDateTime).HasColumnType("datetime");

                entity.Property(e => e.LastSavedBy)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastSavedDateTime).HasColumnType("datetime");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(13);

                entity.Property(e => e.StateCode)
                    .IsRequired()
                    .HasMaxLength(2)
                    .HasColumnType("nchar");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(2)
                    .HasColumnType("nchar");

                entity.Property(e => e.SuffixCode)
                    .HasMaxLength(2)
                    .HasColumnType("nchar");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(2)
                    .HasColumnType("nchar");

                entity.Property(e => e.ZipCode)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnType("nchar");

                entity.Property(e => e.ZipExntension)
                    .HasMaxLength(4)
                    .HasColumnType("nchar");
            });
        }

        public virtual DbSet<Contractor> Contractor { get; set; }
    }
}