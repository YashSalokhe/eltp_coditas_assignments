using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using _16_March.Models;

#nullable disable

namespace _16_March.Models
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
        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<LogExecution> LogExecutions { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<UserInfo> UserInfos { get; set; }

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

            modelBuilder.Entity<Log>(entity =>
            {
                entity.HasKey(e => e.RequestId)
                    .HasName("PK__Logs__33A8517ADA860963");

                entity.Property(e => e.ActionName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ControllerName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ExecutionCompletionTime)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RequestDateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<LogExecution>(entity =>
            {
                entity.HasKey(e => e.RequestId)
                    .HasName("PK__LogExecu__33A8517A9B7D8D87");

                entity.ToTable("LogExecution");

                entity.Property(e => e.ActionName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ControllerName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ExceptionMessage)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ExceptionType)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ExecutionCompletionTime)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RequestDateTime).HasColumnType("datetime");
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

            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserInfo__B9BE370FA7099FA9");

                entity.ToTable("UserInfo");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("user_name");

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("user_password");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<_16_March.Models.Category> Category { get; set; }

        public DbSet<_16_March.Models.Product> Product { get; set; }
    }
}
