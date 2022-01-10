using Microsoft.EntityFrameworkCore;

#nullable disable

namespace da_service.Entities
{
    public partial class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<SChemistry> SChemistries { get; set; }
        public virtual DbSet<SCstdata> SCstdatas { get; set; }
        public virtual DbSet<SCsttemp> SCsttemps { get; set; }
        public virtual DbSet<SEafdata> SEafdatas { get; set; }
        public virtual DbSet<SEaftemp> SEaftemps { get; set; }
        public virtual DbSet<SErporder> SErporders { get; set; }
        public virtual DbSet<SGrade> SGrades { get; set; }
        public virtual DbSet<SHeat> SHeats { get; set; }
        public virtual DbSet<SHeatHeatLineUp> SHeatHeatLineUps { get; set; }
        public virtual DbSet<SHeatLineUp> SHeatLineUps { get; set; }
        public virtual DbSet<SLadle> SLadles { get; set; }
        public virtual DbSet<SLadleEvent> SLadleEvents { get; set; }
        public virtual DbSet<SLadleEventType> SLadleEventTypes { get; set; }
        public virtual DbSet<SLmsdata> SLmsdatas { get; set; }
        public virtual DbSet<SLmstemp> SLmstemps { get; set; }
        public virtual DbSet<SLogFileMonitoringStatus> SLogFileMonitoringStatuses { get; set; }
        public virtual DbSet<SLogFileParsingStatus> SLogFileParsingStatuses { get; set; }
        public virtual DbSet<SSpot> SSpots { get; set; }
        public virtual DbSet<STemperature> STemperatures { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=MSI\\SQLEXPRESS;Database=INNOSTAL;Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Polish_CI_AS");

            modelBuilder.Entity<SChemistry>(entity =>
            {
                entity.HasKey(e => e.ChemistryId);

                entity.ToTable("S_Chemistry");

                entity.Property(e => e.Ce).HasColumnName("CE");

                entity.Property(e => e.LmsdataId).HasColumnName("LMSDataId");

                entity.HasOne(d => d.Lmsdata)
                    .WithMany(p => p.SChemistries)
                    .HasForeignKey(d => d.LmsdataId);
            });

            modelBuilder.Entity<SCstdata>(entity =>
            {
                entity.HasKey(e => e.CstdataId);

                entity.ToTable("S_CSTDatas");

                entity.Property(e => e.CstdataId).HasColumnName("CSTDataId");

                entity.Property(e => e.ErporderId).HasColumnName("ERPOrderId");

                entity.Property(e => e.ErporderValue).HasColumnName("ERPOrderValue");

                entity.Property(e => e.Tph).HasColumnName("TPH");

                entity.HasOne(d => d.Erporder)
                    .WithMany(p => p.SCstdata)
                    .HasForeignKey(d => d.ErporderId);

                entity.HasOne(d => d.Grade)
                    .WithMany(p => p.SCstdata)
                    .HasForeignKey(d => d.GradeId);

                entity.HasOne(d => d.Heat)
                    .WithMany(p => p.SCstdata)
                    .HasForeignKey(d => d.HeatId);

                entity.HasOne(d => d.Ladle)
                    .WithMany(p => p.SCstdata)
                    .HasForeignKey(d => d.LadleId);
            });

            modelBuilder.Entity<SCsttemp>(entity =>
            {
                entity.HasKey(e => e.CsttempId);

                entity.ToTable("S_CSTTemps");

                entity.Property(e => e.CsttempId).HasColumnName("CSTTempId");

                entity.Property(e => e.CstdataId).HasColumnName("CSTDataId");

                entity.Property(e => e.CstunitName).HasColumnName("CSTUnitName");

                entity.HasOne(d => d.Cstdata)
                    .WithMany(p => p.SCsttemps)
                    .HasForeignKey(d => d.CstdataId);
            });

            modelBuilder.Entity<SEafdata>(entity =>
            {
                entity.HasKey(e => e.EafdataId);

                entity.ToTable("S_EAFDatas");

                entity.Property(e => e.EafdataId).HasColumnName("EAFDataId");

                entity.Property(e => e.Ctotal).HasColumnName("CTotal");

                entity.Property(e => e.ErporderId).HasColumnName("ERPOrderId");

                entity.Property(e => e.ErporderValue).HasColumnName("ERPOrderValue");

                entity.Property(e => e.O2total).HasColumnName("O2Total");

                entity.Property(e => e.Tph).HasColumnName("TPH");

                entity.HasOne(d => d.Erporder)
                    .WithMany(p => p.SEafdata)
                    .HasForeignKey(d => d.ErporderId);

                entity.HasOne(d => d.Grade)
                    .WithMany(p => p.SEafdata)
                    .HasForeignKey(d => d.GradeId);

                entity.HasOne(d => d.Heat)
                    .WithMany(p => p.SEafdata)
                    .HasForeignKey(d => d.HeatId);

                entity.HasOne(d => d.Ladle)
                    .WithMany(p => p.SEafdata)
                    .HasForeignKey(d => d.LadleId);
            });

            modelBuilder.Entity<SEaftemp>(entity =>
            {
                entity.HasKey(e => e.EaftempId);

                entity.ToTable("S_EAFTemps");

                entity.Property(e => e.EaftempId).HasColumnName("EAFTempId");

                entity.Property(e => e.EafdataId).HasColumnName("EAFDataId");

                entity.HasOne(d => d.Eafdata)
                    .WithMany(p => p.SEaftemps)
                    .HasForeignKey(d => d.EafdataId);
            });

            modelBuilder.Entity<SErporder>(entity =>
            {
                entity.HasKey(e => e.ErporderId);

                entity.ToTable("S_ERPOrders");

                entity.Property(e => e.ErporderId).HasColumnName("ERPOrderId");
            });

            modelBuilder.Entity<SGrade>(entity =>
            {
                entity.HasKey(e => e.GradeId);

                entity.ToTable("S_Grades");

                entity.Property(e => e.Name).HasMaxLength(450);
            });

            modelBuilder.Entity<SHeat>(entity =>
            {
                entity.HasKey(e => e.HeatId);

                entity.ToTable("S_Heats");

                entity.Property(e => e.ErporderId).HasColumnName("ERPOrderId");

                entity.HasOne(d => d.Erporder)
                    .WithMany(p => p.SHeats)
                    .HasForeignKey(d => d.ErporderId);

                entity.HasOne(d => d.Grade)
                    .WithMany(p => p.SHeats)
                    .HasForeignKey(d => d.GradeId);
            });

            modelBuilder.Entity<SHeatHeatLineUp>(entity =>
            {
                entity.HasKey(e => new { e.HeatLineUpsHeatLineUpId, e.HeatsHeatId });

                entity.ToTable("S_HeatHeatLineUp");

                entity.HasOne(d => d.HeatLineUpsHeatLineUp)
                    .WithMany(p => p.SHeatHeatLineUps)
                    .HasForeignKey(d => d.HeatLineUpsHeatLineUpId);

                entity.HasOne(d => d.HeatsHeat)
                    .WithMany(p => p.SHeatHeatLineUps)
                    .HasForeignKey(d => d.HeatsHeatId);
            });

            modelBuilder.Entity<SHeatLineUp>(entity =>
            {
                entity.HasKey(e => e.HeatLineUpId);

                entity.ToTable("S_HeatLineUps");
            });

            modelBuilder.Entity<SLadle>(entity =>
            {
                entity.HasKey(e => e.LadleId);

                entity.ToTable("S_Ladles");
            });

            modelBuilder.Entity<SLadleEvent>(entity =>
            {
                entity.HasKey(e => e.LadleEventId);

                entity.ToTable("S_LadleEvents");

                entity.HasOne(d => d.LadleEventType)
                    .WithMany(p => p.SLadleEvents)
                    .HasForeignKey(d => d.LadleEventTypeId);

                entity.HasOne(d => d.Ladle)
                    .WithMany(p => p.SLadleEvents)
                    .HasForeignKey(d => d.LadleId);

                entity.HasOne(d => d.Spot)
                    .WithMany(p => p.SLadleEvents)
                    .HasForeignKey(d => d.SpotId);
            });

            modelBuilder.Entity<SLadleEventType>(entity =>
            {
                entity.HasKey(e => e.LadleEventTypeId);

                entity.ToTable("S_LadleEventTypes");
            });

            modelBuilder.Entity<SLmsdata>(entity =>
            {
                entity.HasKey(e => e.LmsdataId);

                entity.ToTable("S_LMSDatas");

                entity.Property(e => e.LmsdataId).HasColumnName("LMSDataId");

                entity.Property(e => e.ErporderId).HasColumnName("ERPOrderId");

                entity.Property(e => e.ErporderValue).HasColumnName("ERPOrderValue");

                entity.HasOne(d => d.Erporder)
                    .WithMany(p => p.SLmsdata)
                    .HasForeignKey(d => d.ErporderId);

                entity.HasOne(d => d.Grade)
                    .WithMany(p => p.SLmsdata)
                    .HasForeignKey(d => d.GradeId);

                entity.HasOne(d => d.Heat)
                    .WithMany(p => p.SLmsdata)
                    .HasForeignKey(d => d.HeatId);

                entity.HasOne(d => d.Ladle)
                    .WithMany(p => p.SLmsdata)
                    .HasForeignKey(d => d.LadleId);
            });

            modelBuilder.Entity<SLmstemp>(entity =>
            {
                entity.HasKey(e => e.LmstempId);

                entity.ToTable("S_LMSTemps");

                entity.Property(e => e.LmstempId).HasColumnName("LMSTempId");

                entity.Property(e => e.LmsdataId).HasColumnName("LMSDataId");

                entity.Property(e => e.LmsunitName).HasColumnName("LMSUnitName");

                entity.HasOne(d => d.Lmsdata)
                    .WithMany(p => p.SLmstemps)
                    .HasForeignKey(d => d.LmsdataId);
            });

            modelBuilder.Entity<SLogFileMonitoringStatus>(entity =>
            {
                entity.HasKey(e => e.LogFileMonitoringStatusId);

                entity.ToTable("S_LogFileMonitoringStatuses");
            });

            modelBuilder.Entity<SLogFileParsingStatus>(entity =>
            {
                entity.HasKey(e => e.LogFileParsingStatusId);

                entity.ToTable("S_LogFileParsingStatuses");
            });

            modelBuilder.Entity<SSpot>(entity =>
            {
                entity.HasKey(e => e.SpotId);

                entity.ToTable("S_Spots");
            });

            modelBuilder.Entity<STemperature>(entity =>
            {
                entity.HasKey(e => e.TemperatureId);

                entity.ToTable("S_Temperatures");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
