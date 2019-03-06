using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartHealth.Migrations
{
    public partial class ChangeTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HealthRecord_User_PatientID",
                table: "HealthRecord");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HealthRecord",
                table: "HealthRecord");

            migrationBuilder.RenameTable(
                name: "HealthRecord",
                newName: "Assessment");

            migrationBuilder.RenameIndex(
                name: "IX_HealthRecord_PatientID",
                table: "Assessment",
                newName: "IX_Assessment_PatientID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Assessment",
                table: "Assessment",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Assessment_User_PatientID",
                table: "Assessment",
                column: "PatientID",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assessment_User_PatientID",
                table: "Assessment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Assessment",
                table: "Assessment");

            migrationBuilder.RenameTable(
                name: "Assessment",
                newName: "HealthRecord");

            migrationBuilder.RenameIndex(
                name: "IX_Assessment_PatientID",
                table: "HealthRecord",
                newName: "IX_HealthRecord_PatientID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HealthRecord",
                table: "HealthRecord",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_HealthRecord_User_PatientID",
                table: "HealthRecord",
                column: "PatientID",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
