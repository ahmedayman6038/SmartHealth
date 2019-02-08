using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartHealth.Migrations
{
    public partial class CreateRating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Rating_RatingID",
                table: "User");

            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.DropIndex(
                name: "IX_User_RatingID",
                table: "User");

            migrationBuilder.DropColumn(
                name: "RatingID",
                table: "User");

            migrationBuilder.CreateTable(
                name: "DoctorRating",
                columns: table => new
                {
                    PatientID = table.Column<int>(nullable: false),
                    DoctorID = table.Column<int>(nullable: false),
                    Value = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    SendDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorRating", x => new { x.PatientID, x.DoctorID });
                    table.ForeignKey(
                        name: "FK_DoctorRating_User_DoctorID",
                        column: x => x.DoctorID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DoctorRating_User_PatientID",
                        column: x => x.PatientID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoctorRating_DoctorID",
                table: "DoctorRating",
                column: "DoctorID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctorRating");

            migrationBuilder.AddColumn<int>(
                name: "RatingID",
                table: "User",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Comment = table.Column<string>(nullable: true),
                    PatientID = table.Column<int>(nullable: true),
                    SendDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    Value = table.Column<int>(nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_User_RatingID",
                table: "User",
                column: "RatingID");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_PatientID",
                table: "Rating",
                column: "PatientID");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Rating_RatingID",
                table: "User",
                column: "RatingID",
                principalTable: "Rating",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
