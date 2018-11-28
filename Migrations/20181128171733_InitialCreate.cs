using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartHealth.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Specialty",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Details = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialty", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Symptom",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Symptom", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Disease",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Details = table.Column<string>(nullable: true),
                    SpecialtyID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disease", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Disease_Specialty_SpecialtyID",
                        column: x => x.SpecialtyID,
                        principalTable: "Specialty",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SymptomDisease",
                columns: table => new
                {
                    SymptomID = table.Column<int>(nullable: false),
                    DiseaseID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SymptomDisease", x => new { x.SymptomID, x.DiseaseID });
                    table.ForeignKey(
                        name: "FK_SymptomDisease_Disease_DiseaseID",
                        column: x => x.DiseaseID,
                        principalTable: "Disease",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SymptomDisease_Symptom_SymptomID",
                        column: x => x.SymptomID,
                        principalTable: "Symptom",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: false),
                    CreatedData = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    Discriminator = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Information = table.Column<string>(nullable: true),
                    RatingID = table.Column<int>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: true),
                    Gender = table.Column<string>(maxLength: 1, nullable: true),
                    Weight = table.Column<int>(nullable: true),
                    Height = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    PatientID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Feedback_User_PatientID",
                        column: x => x.PatientID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HealthRecord",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    PatientID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthRecord", x => x.ID);
                    table.ForeignKey(
                        name: "FK_HealthRecord_User_PatientID",
                        column: x => x.PatientID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Value = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    PatientID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Rating_User_PatientID",
                        column: x => x.PatientID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SpecialtyDoctor",
                columns: table => new
                {
                    SpecialtyID = table.Column<int>(nullable: false),
                    DoctorID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialtyDoctor", x => new { x.SpecialtyID, x.DoctorID });
                    table.ForeignKey(
                        name: "FK_SpecialtyDoctor_User_DoctorID",
                        column: x => x.DoctorID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpecialtyDoctor_Specialty_SpecialtyID",
                        column: x => x.SpecialtyID,
                        principalTable: "Specialty",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Treatment",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true),
                    PatientID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treatment", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Treatment_User_PatientID",
                        column: x => x.PatientID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Disease_SpecialtyID",
                table: "Disease",
                column: "SpecialtyID");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_PatientID",
                table: "Feedback",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_HealthRecord_PatientID",
                table: "HealthRecord",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_PatientID",
                table: "Rating",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialtyDoctor_DoctorID",
                table: "SpecialtyDoctor",
                column: "DoctorID");

            migrationBuilder.CreateIndex(
                name: "IX_SymptomDisease_DiseaseID",
                table: "SymptomDisease",
                column: "DiseaseID");

            migrationBuilder.CreateIndex(
                name: "IX_Treatment_PatientID",
                table: "Treatment",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_User_RatingID",
                table: "User",
                column: "RatingID");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Rating_RatingID",
                table: "User",
                column: "RatingID",
                principalTable: "Rating",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rating_User_PatientID",
                table: "Rating");

            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropTable(
                name: "HealthRecord");

            migrationBuilder.DropTable(
                name: "SpecialtyDoctor");

            migrationBuilder.DropTable(
                name: "SymptomDisease");

            migrationBuilder.DropTable(
                name: "Treatment");

            migrationBuilder.DropTable(
                name: "Disease");

            migrationBuilder.DropTable(
                name: "Symptom");

            migrationBuilder.DropTable(
                name: "Specialty");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Rating");
        }
    }
}
