using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TPI_Programación3.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    OfferQuantity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Category = table.Column<string>(type: "TEXT", nullable: false),
                    ImgLink = table.Column<string>(type: "TEXT", nullable: false),
                    CreatorEmail = table.Column<string>(type: "TEXT", nullable: false),
                    PreferedItem = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FullName = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Role = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "OfferQuantity" },
                values: new object[] { 1, "Electrodomésticos", 10 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "OfferQuantity" },
                values: new object[] { 2, "Vehiculo", 5 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "OfferQuantity" },
                values: new object[] { 3, "Inmueble", 2 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "OfferQuantity" },
                values: new object[] { 4, "Mundial", 20 });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "Category", "CreatorEmail", "Description", "ImgLink", "Name", "PreferedItem" },
                values: new object[] { 1, "Electrodoméstico", "alejo@gmail.com", "Es literalmente una licuadora", "https://url24.top/vJGZp", "Licuadora", "Batidora" });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "Category", "CreatorEmail", "Description", "ImgLink", "Name", "PreferedItem" },
                values: new object[] { 2, "Electrodoméstico", "gaston_elcapo@gmail.com", "Sirve para tostar pan", "https://url24.top/AvyPV", "Tostadora", "Tostadora" });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "Category", "CreatorEmail", "Description", "ImgLink", "Name", "PreferedItem" },
                values: new object[] { 3, "Vehiculo", "elmassi@gmail.com", "Corsita 2009", "https://url24.top/hqPKD", "Auto", "Auto" });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "Category", "CreatorEmail", "Description", "ImgLink", "Name", "PreferedItem" },
                values: new object[] { 4, "Inmueble", "milton_tucson_tuki@gmail.com", "Casa dos pisos", "https://url24.top/lPhra", "Casa", "Vivienda" });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "Category", "CreatorEmail", "Description", "ImgLink", "Name", "PreferedItem" },
                values: new object[] { 5, "Mundial", "pedrito@gmail.com", "La figurita de Messi", "https://url24.top/TvJrw", "Figurita", "Mundial" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FullName", "Password", "Role" },
                values: new object[] { 1, "alejo@gmail.com", "Alejo", "4f22a5b713259a8b3e6d47c9073d7eef25e6ced4c20cbe49abaaa2e80b01e4e37c1a7c16891810668dd9a6bd88f259bbf8b7a672d37e785c3f2f3aa0b7169b54", "Common" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FullName", "Password", "Role" },
                values: new object[] { 2, "gaston_elcapo@gmail.com", "Gaston", "ee02b3dd5b2c06e4e61888d141998abac194d57692f77ae7a28d748fdf9b9f28f756d980687f7290f1306857edf3fe01f8ebf4626880d49a33e029399cb2d700", "Common" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FullName", "Password", "Role" },
                values: new object[] { 3, "elmassi@gmail.com", "Maxi", "24d88843644d18578f99a53015a0aa2a9daadde962419591c9695bac2f0c0a4db32a6fbab93ebbd754cdfdd972670a9245706047b83dc853fdea83af2ba14c80", "Common" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FullName", "Password", "Role" },
                values: new object[] { 4, "milton_tucson_tuki@gmail.com", "Milton", "39548e0ef3daf8dcbfb196b886e44367ba1c45d33761d1fe3e1c4d1e77408a539fb9bb88a6415c9f8d168ed2183ebf1ca4e64e0045c5956b69dae68612bae35e", "Administrator" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FullName", "Password", "Role" },
                values: new object[] { 5, "pedrito@gmail.com", "Pedro", "0e5fd7d30f43897ef1247b4f555a144170c112b2195817d38def4f86ece0bc4b62d5068678522da4109c424d57a942de6ff6f79396fd8c40e70c423a72d66c6a", "Administrator" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
