using Microsoft.EntityFrameworkCore.Migrations;

namespace OCMS03.Migrations
{
    public partial class InAGAA : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "tblWalkIn",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddressLine1",
                table: "tblWalkIn",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "tblWalkIn",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "tblWalkIn",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "tblWalkIn",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressLine1",
                table: "tblWalkIn");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "tblWalkIn");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "tblWalkIn");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "tblWalkIn");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "tblWalkIn",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
