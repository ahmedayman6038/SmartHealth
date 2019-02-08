using Microsoft.EntityFrameworkCore;
using SmartHealth.Models;

namespace SmartHealth.Data
{
    public class HealthContext : DbContext
    {
        public HealthContext(DbContextOptions<HealthContext> options) : base(options)
        {
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Disease> Diseases { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<HealthRecord> HealthRecords { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<DoctorRating> DoctorRatings { get; set; }
        public DbSet<Specialty> Specialties { get; set; }
        public DbSet<SpecialtyDoctor> SpecialtyDoctors { get; set; }
        public DbSet<Symptom> Symptoms { get; set; }
        public DbSet<SymptomDisease> SymptomDiseases { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>().ToTable("Admin");
            modelBuilder.Entity<Disease>().ToTable("Disease");
            modelBuilder.Entity<Doctor>().ToTable("Doctor");
            modelBuilder.Entity<Feedback>().ToTable("Feedback");
            modelBuilder.Entity<HealthRecord>().ToTable("HealthRecord");
            modelBuilder.Entity<Patient>().ToTable("Patient");
            modelBuilder.Entity<DoctorRating>().ToTable("DoctorRating");
            modelBuilder.Entity<Specialty>().ToTable("Specialty");
            modelBuilder.Entity<SpecialtyDoctor>().ToTable("SpecialtyDoctor");
            modelBuilder.Entity<Symptom>().ToTable("Symptom");
            modelBuilder.Entity<SymptomDisease>().ToTable("SymptomDisease");
            modelBuilder.Entity<Treatment>().ToTable("Treatment");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<SpecialtyDoctor>()
                        .HasKey(s => new { s.SpecialtyID, s.DoctorID });
            modelBuilder.Entity<SymptomDisease>()
                        .HasKey(s => new { s.SymptomID, s.DiseaseID });
            modelBuilder.Entity<DoctorRating>()
                        .HasKey(s => new { s.PatientID, s.DoctorID });
            modelBuilder.Entity<DoctorRating>()
                        .HasOne(e => e.Patient)
                        .WithMany(e => e.DoctorRatings)
                        .HasForeignKey(e => e.PatientID)
                        .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<DoctorRating>()
                        .HasOne(e => e.Doctor)
                        .WithMany(e => e.DoctorRatings)
                        .HasForeignKey(e => e.DoctorID)
                        .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<User>()
                        .Property(u => u.CreatedData)
                        .HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Feedback>()
                        .Property(f => f.SendDate)
                        .HasDefaultValueSql("getdate()");
            modelBuilder.Entity<DoctorRating>()
                        .Property(r => r.SendDate)
                        .HasDefaultValueSql("getdate()");
        }
    }
}
