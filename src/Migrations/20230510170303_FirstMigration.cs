using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommandInterceptionWebApplication.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "dbo",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ProductTitle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ProductDescription = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: true),
                    MainImageName = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: true),
                    MainImageTitle = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: true),
                    MainImageUri = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: true),
                    IsFreeDelivery = table.Column<bool>(type: "bit", nullable: false),
                    IsExisting = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: true),
                    OffPrice = table.Column<float>(type: "real", nullable: true),
                    Weight = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product",
                schema: "dbo");
        }
    }
}
