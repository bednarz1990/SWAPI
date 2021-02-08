using Microsoft.EntityFrameworkCore.Migrations;

namespace SWAPI.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Films",
                table => new
                {
                    Id = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EpisodeId = table.Column<int>("int", nullable: false),
                    Rate = table.Column<decimal>("decimal(18,2)", nullable: false),
                    Average = table.Column<decimal>("decimal(18,2)", nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Films", x => x.Id); });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Films");
        }
    }
}