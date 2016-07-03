//using Microsoft.Data.Entity;
//using Microsoft.Data.Entity.Metadata;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DDD.Provider.DataModel
{
    public partial class ProviderDbContext : DbContext
    {

        public ProviderDbContext(DbContextOptions<ProviderDbContext> options)
    : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // options.UseSqlServer(@"Data Source=.\SQL2014;Initial Catalog=POC_DDD;Integrated Security=False;User ID=srvelicheti;Password=Secret@123;MultipleActiveResultSets=true;Trusted_Connection=true;");
            //.SuppressAmbientTransactionWarning();
            //var extension = new SqlServerOptionsExtension(options.Options.GetExtension<SqlServerOptionsExtension>())
            //{
            //    ThrowOnAmbientTransaction = false
            //                };

            //var optionsBuilder = new Microsoft.EntityFrameworkCore.DbContextOptionsBuilder();

            //var extension =
            //    new SqlServerOptionsExtension(optionsBuilder.Options.GetExtension<SqlServerOptionsExtension>());
            //extension
            optionsBuilder.ConfigureWarnings(x => x.Ignore(RelationalEventId.AmbientTransactionWarning));
            //((IDbContextOptionsBuilderInfrastructure)optionsBuilder).AddOrUpdateExtension(extension);
            //var ex = new RelationalEventId
            //{

            //};
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContractorState>(entity =>
            {
                entity.ToTable("Contractor", "Provider");

                entity.HasIndex(e => e.EinNumber).HasName("UQ__Contract__B1569C77342428BE").IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

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
                    .HasColumnType("nchar(2)");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnType("nchar(1)");

                entity.Property(e => e.SuffixCode).HasColumnType("nchar(2)");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnType("nchar(1)");

                entity.Property(e => e.ZipCode)
                    .IsRequired()
                    .HasColumnType("nchar(5)");

                entity.Property(e => e.ZipExntension).HasColumnType("nchar(4)");
            });

            modelBuilder.Entity<ContractorSite>(entity =>
            {
                entity.ToTable("ContractorSite", "Provider");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ArrangedCareTypeCode)
                    .IsRequired()
                    .HasColumnType("char(1)");

                entity.Property(e => e.AttendanceEntryIndicator).HasDefaultValueSql("0");

                entity.Property(e => e.FirstInsertedById)
                    .IsRequired()
                    .HasColumnType("varchar(128)");

                entity.Property(e => e.FirstInsertedDateTime).HasColumnType("datetime");

                entity.Property(e => e.LastSavedById)
                    .IsRequired()
                    .HasColumnType("varchar(128)");

                entity.Property(e => e.LastSavedDateTime).HasColumnType("datetime");

                entity.Property(e => e.RelationshipEffectiveDate).HasColumnType("date");

                entity.Property(e => e.RelationshipEndDate).HasColumnType("date");

                entity.Property(e => e.RelationshipStatusCode)
                    .IsRequired()
                    .HasColumnType("char(1)");

                entity.HasOne(d => d.ContractorState).WithMany(p => p.ContractorSite).HasForeignKey(d => d.ContractorId).OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.SiteState).WithMany(p => p.ContractorSite).HasForeignKey(d => d.SiteId).OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<SiteState>(entity =>
            {
                entity.ToTable("Site", "Provider");

                entity.HasIndex(e => e.SiteNumber).HasName("UQ__Site__9806F1010CBB6C91").IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

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
                    .HasColumnType("nchar(2)");

                entity.Property(e => e.CountyServedCode)
                    .IsRequired()
                    .HasColumnType("nchar(2)");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstInsertedBy)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstInsertedDateTime).HasColumnType("datetime");

                entity.Property(e => e.IsWebEnabled).HasDefaultValueSql("1");

                entity.Property(e => e.LastSavedBy)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastSavedDateTime).HasColumnType("datetime");

                entity.Property(e => e.LicencingStatusCode)
                    .IsRequired()
                    .HasColumnType("nchar(1)");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(13);

                entity.Property(e => e.SiteFacilityTypeCode)
                    .IsRequired()
                    .HasColumnType("nchar(2)");

                entity.Property(e => e.SiteName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SiteTypeCode)
                    .IsRequired()
                    .HasColumnType("nchar(1)");

                entity.Property(e => e.StateCode)
                    .IsRequired()
                    .HasColumnType("nchar(2)");

                entity.Property(e => e.StatusCode)
                    .IsRequired()
                    .HasColumnType("nchar(1)");

                entity.Property(e => e.ZipCode)
                    .IsRequired()
                    .HasColumnType("nchar(5)");

                entity.Property(e => e.ZipExtension).HasColumnType("nchar(4)");
            });

            modelBuilder.Entity<SiteHolidayState>(entity =>
            {
                entity.ToTable("SiteHoliday", "Provider");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CalendarYearDate)
                    .IsRequired()
                    .HasColumnType("nchar(4)");

                entity.Property(e => e.FirstInsertedById)
                    .IsRequired()
                    .HasColumnType("varchar(128)");

                entity.Property(e => e.FirstInsertedDateTime).HasColumnType("datetime");

                entity.Property(e => e.HolidayDate).HasColumnType("date");

                entity.Property(e => e.HolidayName)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.LastSavedById)
                    .IsRequired()
                    .HasColumnType("varchar(128)");

                entity.Property(e => e.LastSavedDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.SiteState).WithMany(p => p.SiteHoliday).HasForeignKey(d => d.SiteId).OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<SiteRateState>(entity =>
            {
                entity.ToTable("SiteRate", "Provider");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.EffectiveDate).HasColumnType("date");

                entity.Property(e => e.FirstInsertedById)
                    .IsRequired()
                    .HasColumnType("varchar(128)");

                entity.Property(e => e.FirstInsertedDateTime).HasColumnType("datetime");

                entity.Property(e => e.LastSavedById)
                    .IsRequired()
                    .HasColumnType("varchar(128)");

                entity.Property(e => e.LastSavedDateTime).HasColumnType("datetime");

                entity.Property(e => e.RegularCareDailyRate).HasColumnType("decimal");

                entity.Property(e => e.RegularCareWeeklyRate).HasColumnType("decimal");

                entity.Property(e => e.SpecialCareDailyRate).HasColumnType("decimal");

                entity.Property(e => e.SpecialCareWeeklyRate).HasColumnType("decimal");

                entity.HasOne(d => d.SiteState).WithMany(p => p.SiteRate).HasForeignKey(d => d.SiteID).OnDelete(DeleteBehavior.Restrict);
            });
        }


        public virtual DbSet<ContractorState> Contractor { get; set; }
        public virtual DbSet<ContractorSite> ContractorSite { get; set; }
        public virtual DbSet<SiteState> Site { get; set; }
        public virtual DbSet<SiteHolidayState> SiteHoliday { get; set; }
        public virtual DbSet<SiteRateState> SiteRate { get; set; }
    }
}