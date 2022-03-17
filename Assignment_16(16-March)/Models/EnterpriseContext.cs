using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Assignment_16_16_March_.Models
{
    public partial class EnterpriseContext : DbContext
    {
        public EnterpriseContext()
        {
        }

        public EnterpriseContext(DbContextOptions<EnterpriseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source= YSALOKHE-LAP-05\\MSSQLSERVER01 ;Initial Catalog=Enterprise;Integrated Security=SSPI");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(e => e.CourseName).IsRequired();

                entity.Property(e => e.DegreeType)
                    .IsRequired()
                    .HasDefaultValueSql("(N'')");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.DeptNo)
                    .HasName("PK__Departme__0148CAAEADB18F3F");

                entity.ToTable("Department");

                entity.Property(e => e.DeptNo).ValueGeneratedNever();

                entity.Property(e => e.DeptName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmpNo)
                    .HasName("PK__Employee__AF2D66D3AB23A77C");

                entity.ToTable("Employee");

                entity.Property(e => e.EmpNo).ValueGeneratedNever();

                entity.Property(e => e.Designation)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmpName)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.HasOne(d => d.DeptNoNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.DeptNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Employee__DeptNo__4BAC3F29");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.StudentUniqueId);

                entity.ToTable("students");

                entity.HasIndex(e => e.CourseId, "IX_students_CourseId");

                entity.Property(e => e.FeeStatus).IsRequired();

                entity.Property(e => e.StudentName).IsRequired();

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.CourseId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
