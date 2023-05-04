using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Migrations
{
    /// <inheritdoc />
    public partial class InitialDbConnection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ThesisCollections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    thesisTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    thesisDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    thesisAuthor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    thesisCourse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    yearPublished = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThesisCollections", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ThesisCollections");
        }
    }
}
