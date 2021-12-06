using Microsoft.EntityFrameworkCore.Migrations;

namespace AplikacjaInternetowa.Migrations
{
    public partial class AdresZamieszkania : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdresZamieszkania",
                table: "Studenci",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdresZamieszkania",
                table: "Studenci");
        }
    }
}
