using Microsoft.EntityFrameworkCore;
using TrungTamNgoaiNgu.Domain.Entities;

namespace TrungTamNgoaiNgu.Application.Data;

public sealed class LanguageCenterDbContext(DbContextOptions<LanguageCenterDbContext> options) : DbContext(options)
{
    public DbSet<AccountEntity> Accounts => Set<AccountEntity>();
    public DbSet<CourseEntity> Courses => Set<CourseEntity>();
    public DbSet<TeacherEntity> Teachers => Set<TeacherEntity>();
    public DbSet<ClassEntity> Classes => Set<ClassEntity>();
    public DbSet<StudentEntity> Students => Set<StudentEntity>();
    public DbSet<EnrollmentEntity> Enrollments => Set<EnrollmentEntity>();
    public DbSet<ReceiptEntity> Receipts => Set<ReceiptEntity>();
    public DbSet<AttendanceEntity> Attendances => Set<AttendanceEntity>();
    public DbSet<ScoreEntity> Scores => Set<ScoreEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AccountEntity>(entity =>
        {
            entity.ToTable("Accounts");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id).HasMaxLength(20);
            entity.Property(x => x.Username).HasMaxLength(50).IsRequired();
            entity.Property(x => x.PasswordHash).HasMaxLength(255).IsRequired();
            entity.Property(x => x.DisplayName).HasMaxLength(120).IsRequired();
            entity.Property(x => x.Email).HasMaxLength(120).IsRequired();
            entity.Property(x => x.Phone).HasMaxLength(20).IsRequired();
            entity.Property(x => x.Role).HasConversion<string>().HasMaxLength(20).IsRequired();
            entity.Property(x => x.Status).HasConversion<string>().HasMaxLength(20).IsRequired();
            entity.Property(x => x.IsDeleted).HasDefaultValue(false);
            entity.Property(x => x.CreatedAt).HasColumnType("datetime2").HasDefaultValueSql("SYSUTCDATETIME()");
            entity.Property(x => x.UpdatedAt).HasColumnType("datetime2");
            entity.HasIndex(x => x.Username).IsUnique().HasFilter("[IsDeleted] = 0");
            entity.HasIndex(x => x.Email).IsUnique().HasFilter("[IsDeleted] = 0");
            entity.HasIndex(x => x.Phone).IsUnique().HasFilter("[IsDeleted] = 0");
        });

        modelBuilder.Entity<CourseEntity>(entity =>
        {
            entity.ToTable("Courses");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id).HasMaxLength(20);
            entity.Property(x => x.Name).HasMaxLength(150).IsRequired();
            entity.Property(x => x.Description).HasMaxLength(1000);
            entity.Property(x => x.TuitionFee).HasColumnType("decimal(18,2)").IsRequired();
            entity.Property(x => x.Status).HasMaxLength(30).IsRequired();
            entity.Property(x => x.IsDeleted).HasDefaultValue(false);
            entity.Property(x => x.CreatedAt).HasColumnType("datetime2").HasDefaultValueSql("SYSUTCDATETIME()");
            entity.Property(x => x.UpdatedAt).HasColumnType("datetime2");
        });

        modelBuilder.Entity<TeacherEntity>(entity =>
        {
            entity.ToTable("Teachers");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id).HasMaxLength(20);
            entity.Property(x => x.FullName).HasMaxLength(120).IsRequired();
            entity.Property(x => x.Phone).HasMaxLength(20).IsRequired();
            entity.Property(x => x.Email).HasMaxLength(120).IsRequired();
            entity.Property(x => x.Specialization).HasMaxLength(120);
            entity.Property(x => x.Gender).HasMaxLength(20);
            entity.Property(x => x.Address).HasMaxLength(300);
            entity.Property(x => x.AvatarPath).HasMaxLength(260);
            entity.Property(x => x.AccountId).HasMaxLength(20);
            entity.Property(x => x.Status).HasMaxLength(30).IsRequired();
            entity.Property(x => x.IsDeleted).HasDefaultValue(false);
            entity.Property(x => x.CreatedAt).HasColumnType("datetime2").HasDefaultValueSql("SYSUTCDATETIME()");
            entity.Property(x => x.UpdatedAt).HasColumnType("datetime2");
            entity.HasIndex(x => x.Email).IsUnique().HasFilter("[IsDeleted] = 0");
            entity.HasIndex(x => x.Phone).IsUnique().HasFilter("[IsDeleted] = 0");
            entity.HasIndex(x => x.AccountId).IsUnique().HasFilter("[AccountId] IS NOT NULL AND [IsDeleted] = 0");
            entity.HasOne(x => x.Account)
                .WithOne(x => x.TeacherProfile)
                .HasForeignKey<TeacherEntity>(x => x.AccountId)
                .OnDelete(DeleteBehavior.SetNull);
        });

        modelBuilder.Entity<ClassEntity>(entity =>
        {
            entity.ToTable("Classes");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id).HasMaxLength(20);
            entity.Property(x => x.Name).HasMaxLength(120).IsRequired();
            entity.Property(x => x.CourseId).HasMaxLength(20).IsRequired();
            entity.Property(x => x.TeacherId).HasMaxLength(20).IsRequired();
            entity.Property(x => x.StartDate).HasColumnType("datetime2");
            entity.Property(x => x.EndDate).HasColumnType("datetime2");
            entity.Property(x => x.Schedule).HasMaxLength(120);
            entity.Property(x => x.Room).HasMaxLength(50);
            entity.Property(x => x.Status).HasMaxLength(30).IsRequired();
            entity.Property(x => x.IsDeleted).HasDefaultValue(false);
            entity.Property(x => x.CreatedAt).HasColumnType("datetime2").HasDefaultValueSql("SYSUTCDATETIME()");
            entity.Property(x => x.UpdatedAt).HasColumnType("datetime2");
            entity.HasIndex(x => x.CourseId);
            entity.HasIndex(x => x.TeacherId);
            entity.HasOne(x => x.Course)
                .WithMany(x => x.Classes)
                .HasForeignKey(x => x.CourseId)
                .OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(x => x.Teacher)
                .WithMany(x => x.Classes)
                .HasForeignKey(x => x.TeacherId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<StudentEntity>(entity =>
        {
            entity.ToTable("Students");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id).HasMaxLength(20);
            entity.Property(x => x.FullName).HasMaxLength(120).IsRequired();
            entity.Property(x => x.BirthDate).HasColumnType("datetime2");
            entity.Property(x => x.Phone).HasMaxLength(20).IsRequired();
            entity.Property(x => x.Email).HasMaxLength(120);
            entity.Property(x => x.Address).HasMaxLength(300);
            entity.Property(x => x.AvatarPath).HasMaxLength(260);
            entity.Property(x => x.Status).HasMaxLength(30).IsRequired();
            entity.Property(x => x.IsDeleted).HasDefaultValue(false);
            entity.Property(x => x.CreatedAt).HasColumnType("datetime2").HasDefaultValueSql("SYSUTCDATETIME()");
            entity.Property(x => x.UpdatedAt).HasColumnType("datetime2");
            entity.HasIndex(x => x.Email).IsUnique().HasFilter("[Email] IS NOT NULL AND [IsDeleted] = 0");
            entity.HasIndex(x => x.Phone).IsUnique().HasFilter("[IsDeleted] = 0");
        });

        modelBuilder.Entity<EnrollmentEntity>(entity =>
        {
            entity.ToTable("Enrollments");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id).HasMaxLength(20);
            entity.Property(x => x.StudentId).HasMaxLength(20).IsRequired();
            entity.Property(x => x.ClassId).HasMaxLength(20).IsRequired();
            entity.Property(x => x.EnrollDate).HasColumnType("datetime2");
            entity.Property(x => x.Status).HasMaxLength(30).IsRequired();
            entity.Property(x => x.Note).HasMaxLength(500);
            entity.Property(x => x.IsDeleted).HasDefaultValue(false);
            entity.Property(x => x.CreatedAt).HasColumnType("datetime2").HasDefaultValueSql("SYSUTCDATETIME()");
            entity.Property(x => x.UpdatedAt).HasColumnType("datetime2");
            entity.HasIndex(x => x.ClassId);
            entity.HasIndex(x => x.StudentId);
            entity.HasIndex(x => new { x.StudentId, x.ClassId }).IsUnique().HasFilter("[IsDeleted] = 0");
            entity.HasOne(x => x.Student)
                .WithMany(x => x.Enrollments)
                .HasForeignKey(x => x.StudentId)
                .OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(x => x.Class)
                .WithMany(x => x.Enrollments)
                .HasForeignKey(x => x.ClassId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<ReceiptEntity>(entity =>
        {
            entity.ToTable("Receipts");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id).HasMaxLength(20);
            entity.Property(x => x.EnrollmentId).HasMaxLength(20).IsRequired();
            entity.Property(x => x.PayDate).HasColumnType("datetime2");
            entity.Property(x => x.PaymentMethod).HasMaxLength(50).IsRequired();
            entity.Property(x => x.Note).HasMaxLength(500);
            entity.Property(x => x.CreatedByStaffId).HasMaxLength(20);
            entity.Property(x => x.AmountPaid).HasColumnType("decimal(18,2)");
            entity.Property(x => x.IsDeleted).HasDefaultValue(false);
            entity.Property(x => x.CreatedAt).HasColumnType("datetime2").HasDefaultValueSql("SYSUTCDATETIME()");
            entity.Property(x => x.UpdatedAt).HasColumnType("datetime2");
            entity.HasIndex(x => x.CreatedByStaffId);
            entity.HasIndex(x => x.EnrollmentId);
            entity.HasOne(x => x.Enrollment)
                .WithMany(x => x.Receipts)
                .HasForeignKey(x => x.EnrollmentId)
                .OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(x => x.CreatedByStaff)
                .WithMany(x => x.CreatedReceipts)
                .HasForeignKey(x => x.CreatedByStaffId)
                .OnDelete(DeleteBehavior.SetNull);
        });

        modelBuilder.Entity<AttendanceEntity>(entity =>
        {
            entity.ToTable("Attendances");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id).HasMaxLength(20);
            entity.Property(x => x.EnrollmentId).HasMaxLength(20).IsRequired();
            entity.Property(x => x.AttendanceDate).HasColumnType("datetime2");
            entity.Property(x => x.Status).HasMaxLength(20).IsRequired();
            entity.Property(x => x.Note).HasMaxLength(300);
            entity.Property(x => x.CreatedAt).HasColumnType("datetime2").HasDefaultValueSql("SYSUTCDATETIME()");
            entity.Property(x => x.UpdatedAt).HasColumnType("datetime2");
            entity.HasOne(x => x.Enrollment)
                .WithMany(x => x.Attendances)
                .HasForeignKey(x => x.EnrollmentId)
                .OnDelete(DeleteBehavior.Restrict);
            entity.HasIndex(x => new { x.EnrollmentId, x.AttendanceDate }).IsUnique();
        });

        modelBuilder.Entity<ScoreEntity>(entity =>
        {
            entity.ToTable("Scores");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id).HasMaxLength(20);
            entity.Property(x => x.EnrollmentId).HasMaxLength(20).IsRequired();
            entity.Property(x => x.MidtermScore).HasColumnType("decimal(4,2)");
            entity.Property(x => x.FinalScore).HasColumnType("decimal(4,2)");
            entity.Property(x => x.Note).HasMaxLength(300);
            entity.Property(x => x.CreatedAt).HasColumnType("datetime2").HasDefaultValueSql("SYSUTCDATETIME()");
            entity.Property(x => x.UpdatedAt).HasColumnType("datetime2");
            entity.HasIndex(x => x.EnrollmentId).IsUnique();
            entity.HasOne(x => x.Enrollment)
                .WithOne(x => x.Score)
                .HasForeignKey<ScoreEntity>(x => x.EnrollmentId)
                .OnDelete(DeleteBehavior.Restrict);
        });
    }
}
