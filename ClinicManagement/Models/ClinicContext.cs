using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ClinicManagement.Models
{
    public partial class ClinicContext : DbContext
    {
        public ClinicContext()
        {
        }

        public ClinicContext(DbContextOptions<ClinicContext> options)
            : base(options)
        {
        }

        public virtual DbSet<PatientBill> PatientBills { get; set; } = null!;
        public virtual DbSet<PatientInfo> PatientInfos { get; set; } = null!;
        public virtual DbSet<Record> Records { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source= YSALOKHE-LAP-05\\MSSQLSERVER01 ;Initial Catalog=Clinic;Integrated Security=SSPI");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PatientBill>(entity =>
            {
                entity.HasKey(e => e.Billnumber)
                    .HasName("PK__PatientB__1F5944947F65ED60");

                entity.ToTable("PatientBill");

                entity.Property(e => e.Billnumber).HasColumnName("billnumber");

                entity.Property(e => e.Currentdate)
                    .HasColumnType("date")
                    .HasColumnName("currentdate")
                    .HasDefaultValueSql("(CONVERT([date],getdate()))");

                entity.Property(e => e.Fees).HasColumnName("fees");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.PatientBills)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PatientBi__Patie__5070F446");
            });

            modelBuilder.Entity<PatientInfo>(entity =>
            {
                entity.HasKey(e => e.PatientId)
                    .HasName("PK__Patient___970EC366D854B241");

                entity.ToTable("Patient_info");

                entity.Property(e => e.MobileNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PatientAddress)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PatientName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Record>(entity =>
            {
                entity.Property(e => e.AppointmentDate).HasColumnType("date");

                entity.Property(e => e.BloodPressure)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cholestrol)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MedicineSubscribed)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.PatientName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sugar)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Records)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Records__Patient__571DF1D5");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
