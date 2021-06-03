using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sample.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    bookId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ISBN = table.Column<int>(nullable: false),
                    AuthorName = table.Column<string>(nullable: false),
                    BookTitle = table.Column<string>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Review = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.bookId);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    cartItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    bookId = table.Column<int>(nullable: false),
                    ISBN = table.Column<int>(nullable: false),
                    AuthorName = table.Column<string>(nullable: true),
                    BookTitle = table.Column<string>(nullable: true),
                    Amount = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.cartItemId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Carts");
        }
    }
}
