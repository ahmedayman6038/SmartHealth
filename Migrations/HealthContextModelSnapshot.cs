﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartHealth.Data;

namespace SmartHealth.Migrations
{
    [DbContext(typeof(HealthContext))]
    partial class HealthContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SmartHealth.Models.Disease", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Details");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int?>("SpecialtyID");

                    b.HasKey("ID");

                    b.HasIndex("SpecialtyID");

                    b.ToTable("Disease");
                });

            modelBuilder.Entity("SmartHealth.Models.Feedback", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content");

                    b.Property<DateTime>("Date");

                    b.Property<int?>("PatientID");

                    b.HasKey("ID");

                    b.HasIndex("PatientID");

                    b.ToTable("Feedback");
                });

            modelBuilder.Entity("SmartHealth.Models.HealthRecord", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int?>("PatientID");

                    b.HasKey("ID");

                    b.HasIndex("PatientID");

                    b.ToTable("HealthRecord");
                });

            modelBuilder.Entity("SmartHealth.Models.Rating", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment");

                    b.Property<DateTime>("Date");

                    b.Property<int?>("PatientID");

                    b.Property<int>("Value");

                    b.HasKey("ID");

                    b.HasIndex("PatientID");

                    b.ToTable("Rating");
                });

            modelBuilder.Entity("SmartHealth.Models.Specialty", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Details");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Specialty");
                });

            modelBuilder.Entity("SmartHealth.Models.SpecialtyDoctor", b =>
                {
                    b.Property<int>("SpecialtyID");

                    b.Property<int>("DoctorID");

                    b.HasKey("SpecialtyID", "DoctorID");

                    b.HasIndex("DoctorID");

                    b.ToTable("SpecialtyDoctor");
                });

            modelBuilder.Entity("SmartHealth.Models.Symptom", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Symptom");
                });

            modelBuilder.Entity("SmartHealth.Models.SymptomDisease", b =>
                {
                    b.Property<int>("SymptomID");

                    b.Property<int>("DiseaseID");

                    b.HasKey("SymptomID", "DiseaseID");

                    b.HasIndex("DiseaseID");

                    b.ToTable("SymptomDisease");
                });

            modelBuilder.Entity("SmartHealth.Models.Treatment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("EndDate");

                    b.Property<string>("Name");

                    b.Property<int?>("PatientID");

                    b.Property<DateTime?>("StartDate");

                    b.HasKey("ID");

                    b.HasIndex("PatientID");

                    b.ToTable("Treatment");
                });

            modelBuilder.Entity("SmartHealth.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedData")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("User");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");
                });

            modelBuilder.Entity("SmartHealth.Models.Admin", b =>
                {
                    b.HasBaseType("SmartHealth.Models.User");


                    b.ToTable("Admin");

                    b.HasDiscriminator().HasValue("Admin");
                });

            modelBuilder.Entity("SmartHealth.Models.Doctor", b =>
                {
                    b.HasBaseType("SmartHealth.Models.User");

                    b.Property<string>("Address");

                    b.Property<string>("City");

                    b.Property<string>("Information");

                    b.Property<int?>("RatingID");

                    b.HasIndex("RatingID");

                    b.ToTable("Doctor");

                    b.HasDiscriminator().HasValue("Doctor");
                });

            modelBuilder.Entity("SmartHealth.Models.Patient", b =>
                {
                    b.HasBaseType("SmartHealth.Models.User");

                    b.Property<DateTime?>("BirthDate");

                    b.Property<string>("Gender")
                        .HasMaxLength(1);

                    b.Property<int>("Height");

                    b.Property<int>("Weight");

                    b.ToTable("Patient");

                    b.HasDiscriminator().HasValue("Patient");
                });

            modelBuilder.Entity("SmartHealth.Models.Disease", b =>
                {
                    b.HasOne("SmartHealth.Models.Specialty", "Specialty")
                        .WithMany()
                        .HasForeignKey("SpecialtyID");
                });

            modelBuilder.Entity("SmartHealth.Models.Feedback", b =>
                {
                    b.HasOne("SmartHealth.Models.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientID");
                });

            modelBuilder.Entity("SmartHealth.Models.HealthRecord", b =>
                {
                    b.HasOne("SmartHealth.Models.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientID");
                });

            modelBuilder.Entity("SmartHealth.Models.Rating", b =>
                {
                    b.HasOne("SmartHealth.Models.Patient")
                        .WithMany("Ratings")
                        .HasForeignKey("PatientID");
                });

            modelBuilder.Entity("SmartHealth.Models.SpecialtyDoctor", b =>
                {
                    b.HasOne("SmartHealth.Models.Doctor", "Doctor")
                        .WithMany("SpecialtyDoctors")
                        .HasForeignKey("DoctorID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SmartHealth.Models.Specialty", "Specialty")
                        .WithMany("SpecialtyDoctors")
                        .HasForeignKey("SpecialtyID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SmartHealth.Models.SymptomDisease", b =>
                {
                    b.HasOne("SmartHealth.Models.Disease", "Disease")
                        .WithMany("SymptomDiseases")
                        .HasForeignKey("DiseaseID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SmartHealth.Models.Symptom", "Symptom")
                        .WithMany("SymptomDiseases")
                        .HasForeignKey("SymptomID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SmartHealth.Models.Treatment", b =>
                {
                    b.HasOne("SmartHealth.Models.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientID");
                });

            modelBuilder.Entity("SmartHealth.Models.Doctor", b =>
                {
                    b.HasOne("SmartHealth.Models.Rating", "Rating")
                        .WithMany()
                        .HasForeignKey("RatingID");
                });
#pragma warning restore 612, 618
        }
    }
}
