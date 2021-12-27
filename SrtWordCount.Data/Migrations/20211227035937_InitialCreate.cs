using Microsoft.EntityFrameworkCore.Migrations;

namespace SrtWordCount.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SrtStatisticsModelList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieTitle = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Genre = table.Column<int>(type: "int", nullable: false),
                    Words = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DistinctWordCounts = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalWords = table.Column<int>(type: "int", nullable: false),
                    TotalDistictWordCounts = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SrtStatisticsModelList", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SrtStatisticsModelList");
        }
    }
}
