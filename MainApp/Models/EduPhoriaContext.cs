using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MainApp.Models
{
    public partial class EduPhoriaContext : IdentityDbContext<IdentityUser>
    {
        public EduPhoriaContext()
        {
        }

        public EduPhoriaContext(DbContextOptions<EduPhoriaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Instructor> Instructors { get; set; }
        public virtual DbSet<Learner> Learners { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
            => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=EduPhoriaSystem;Trusted_Connection=True;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.AdminId).HasName("PK__Admin__719FE4E8EAFAE049");

                entity.ToTable("Admin");

                entity.HasIndex(e => e.Email).IsUnique();

                entity.Property(e => e.AdminId).HasColumnName("AdminID");
                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.HasOne(d => d.EmailNavigation).WithOne(p => p.Admin)
                    .HasForeignKey<Admin>(d => d.Email)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Admin__Email__2E26C93A");
            });

            modelBuilder.Entity<Instructor>(entity =>
            {
                entity.HasKey(e => e.InstructorId).HasName("PK__Instruct__9D010B7B66685292");

                entity.ToTable("Instructor");

                entity.HasIndex(e => e.Email).IsUnique();

                entity.Property(e => e.InstructorId).HasColumnName("InstructorID");
                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.ExpertiseArea)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("expertise_area");
                entity.Property(e => e.LatestQualification)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("latest_qualification");
                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.HasOne(d => d.EmailNavigation).WithOne(p => p.Instructor)
                    .HasForeignKey<Instructor>(d => d.Email)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Instructo__Email__2A563856");
            });

            modelBuilder.Entity<Learner>(entity =>
            {
                entity.HasKey(e => e.LearnerId).HasName("PK__Learner__67ABFCFAAAD00C07");

                entity.ToTable("Learner");

                entity.HasIndex(e => e.Email).IsUnique();

                entity.Property(e => e.LearnerId).HasColumnName("LearnerID");
                entity.Property(e => e.BirthDate).HasColumnName("birth_date");
                entity.Property(e => e.Country)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("country");
                entity.Property(e => e.CulturalBackground)
                    .HasColumnType("text")
                    .HasColumnName("cultural_background");
                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.FirstName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("first_name");
                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("gender");
                entity.Property(e => e.LastName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("last_name");

                entity.HasOne(d => d.EmailNavigation).WithOne(p => p.Learner)
                    .HasForeignKey<Learner>(d => d.Email)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Learner__Email__6C5905DD");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.Email).HasName("PK__Users__A9D10535A5236085");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.PasswordHash)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("password_hash");
                entity.Property(e => e.Role)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(e => e.Admin)
                    .WithOne(a => a.EmailNavigation)
                    .HasForeignKey<Admin>(a => a.Email)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Admin__Email__2E26C93A");

                entity.HasOne(e => e.Instructor)
                    .WithOne(i => i.EmailNavigation)
                    .HasForeignKey<Instructor>(i => i.Email)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Instructo__Email__2A563856");

                entity.HasOne(e => e.Learner)
                    .WithOne(l => l.EmailNavigation)
                    .HasForeignKey<Learner>(l => l.Email)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Learner__Email__6C5905DD");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}