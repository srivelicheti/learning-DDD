using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;

namespace DDD.Provider.DataModel
{
    public partial class ProviderDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Data Source=.\SQL2014;Initial Catalog=POC_DDD;Integrated Security=False;User ID=srvelicheti;Password=Secret@123;MultipleActiveResultSets=true;Trusted_Connection=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contractor>(entity =>
            {
                entity.ToTable("Contractor", "Provider");

                entity.HasIndex(e => e.EinNumber).HasName("UQ__Contract__B1569C77342428BE").IsUnique();

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
                    .HasMaxLength(11);

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

            modelBuilder.Entity<ContractorSite>(entity =>
            {
                entity.ToTable("ContractorSite", "Provider");

                entity.Property(e => e.ID).ValueGeneratedNever();

                entity.Property(e => e.ArrangedCareTypeCode)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasColumnType("char");

                entity.Property(e => e.AttendanceEntryIndicator).HasDefaultValue(false);

                entity.Property(e => e.FirstInsertedByID)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnType("varchar");

                entity.Property(e => e.FirstInsertedDateTime).HasColumnType("datetime");

                entity.Property(e => e.LastSavedByID)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnType("varchar");

                entity.Property(e => e.LastSavedDateTime).HasColumnType("datetime");

                entity.Property(e => e.RelationshipEffectiveDate).HasColumnType("date");

                entity.Property(e => e.RelationshipEndDate).HasColumnType("date");

                entity.Property(e => e.RelationshipStatusCode)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasColumnType("char");

                entity.HasOne(d => d.Contractor).WithMany(p => p.ContractorSite).HasForeignKey(d => d.ContractorID).OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.Site).WithMany(p => p.ContractorSite).HasForeignKey(d => d.SiteID).OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Site>(entity =>
            {
                entity.ToTable("Site", "Provider");

                entity.HasIndex(e => e.SiteNumber).HasName("UQ__Site__9806F1010CBB6C91").IsUnique();

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

                entity.Property(e => e.ContractStartDate).HasColumnType("date");

                entity.Property(e => e.CountyCode)
                    .IsRequired()
                    .HasMaxLength(2)
                    .HasColumnType("nchar");

                entity.Property(e => e.CountyServedCode)
                    .IsRequired()
                    .HasMaxLength(2)
                    .HasColumnType("nchar");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstInsertedBy)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstInsertedDateTime).HasColumnType("datetime");

                entity.Property(e => e.IsWebEnabled).HasDefaultValue(true);

                entity.Property(e => e.LastSavedBy)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastSavedDateTime).HasColumnType("datetime");

                entity.Property(e => e.LicencingStatusCode)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasColumnType("nchar");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(13);

                entity.Property(e => e.SiteFacilityTypeCode)
                    .IsRequired()
                    .HasMaxLength(2)
                    .HasColumnType("nchar");

                entity.Property(e => e.SiteName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SiteTypeCode)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasColumnType("nchar");

                entity.Property(e => e.StateCode)
                    .IsRequired()
                    .HasMaxLength(2)
                    .HasColumnType("nchar");

                entity.Property(e => e.StatusCode)
                    .IsRequired()
                    .HasMaxLength(2)
                    .HasColumnType("nchar");

                entity.Property(e => e.ZipCode)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnType("nchar");

                entity.Property(e => e.ZipExtension)
                    .HasMaxLength(4)
                    .HasColumnType("nchar");
            });

            modelBuilder.Entity<SiteHoliday>(entity =>
            {
                entity.ToTable("SiteHoliday", "Provider");

                entity.Property(e => e.ID).ValueGeneratedNever();

                entity.Property(e => e.CalendarYearDate)
                    .IsRequired()
                    .HasMaxLength(4)
                    .HasColumnType("nchar");

                entity.Property(e => e.FirstInsertedByID)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnType("varchar");

                entity.Property(e => e.FirstInsertedDateTime).HasColumnType("datetime");

                entity.Property(e => e.HolidayDate).HasColumnType("date");

                entity.Property(e => e.HolidayName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnType("varchar");

                entity.Property(e => e.LastSavedByID)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnType("varchar");

                entity.Property(e => e.LastSavedDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.Site).WithMany(p => p.SiteHoliday).HasForeignKey(d => d.SiteID).OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<SiteRate>(entity =>
            {
                entity.ToTable("SiteRate", "Provider");

                entity.Property(e => e.ID).ValueGeneratedNever();

                entity.Property(e => e.EffectiveDate).HasColumnType("date");

                entity.Property(e => e.FirstInsertedByID)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnType("varchar");

                entity.Property(e => e.FirstInsertedDateTime).HasColumnType("datetime");

                entity.Property(e => e.LastSavedByID)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnType("varchar");

                entity.Property(e => e.LastSavedDateTime).HasColumnType("datetime");

                entity.Property(e => e.RegularCareDailyRate).HasColumnType("decimal");

                entity.Property(e => e.RegularCareWeeklyRate).HasColumnType("decimal");

                entity.Property(e => e.SpecialCareDailyRate).HasColumnType("decimal");

                entity.Property(e => e.SpecialCareWeeklyRate).HasColumnType("decimal");

                entity.HasOne(d => d.Site).WithMany(p => p.SiteRate).HasForeignKey(d => d.SiteID).OnDelete(DeleteBehavior.Restrict);
            });
        }

        public virtual DbSet<Contractor> Contractor { get; set; }
        public virtual DbSet<ContractorSite> ContractorSite { get; set; }
        public virtual DbSet<Site> Site { get; set; }
        public virtual DbSet<SiteHoliday> SiteHoliday { get; set; }
        public virtual DbSet<SiteRate> SiteRate { get; set; }
    }
}