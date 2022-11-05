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
                values: new object[] { 1, "alejo@gmail.com", "Alejo", "3c9909afec25354d551dae21590bb26e38d53f2173b8d3dc3eee4c047e7ab1c1eb8b85103e3be7ba613b31bb5c9c36214dc9f14a42fd7a2fdb84856bca5c44c2", "Common" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FullName", "Password", "Role" },
                values: new object[] { 2, "gaston_elcapo@gmail.com", "Gaston", "ddaf35a193617abacc417349ae20413112e6fa4e89a97ea20a9eeee64b55d39a2192992a274fc1a836ba3c23a3feebbd454d4423643ce80e2a9ac94fa54ca49f", "Common" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FullName", "Password", "Role" },
                values: new object[] { 3, "elmassi@gmail.com", "Maxi", "ca9879bd727ba3bd815f05fe6b9e4640c774b61cc8f141295542cefc1b7b8fc6e3daf3f656555cdec355894e7af48964e88994d960f41ba8f61f7a05d5ddbd07", "Common" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FullName", "Password", "Role" },
                values: new object[] { 4, "milton_tucson_tuki@gmail.com", "Milton", "b5ba77af1f7bda735894e746a199acb1d2c836424da2fc46bebb55423dccbff871877a30fab77a31e47b0a29ea0154882e532e9a29b220a8f2958773313bbb2a", "Administrator" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FullName", "Password", "Role" },
                values: new object[] { 5, "pedrito@gmail.com", "Pedro", "d67e72421ee3e9e68ca4b6e8da288f406ad976f5371945790d95861398d39064a4fe66f021ce87b63417150545df9a98a76da5cf012f7c908851647bcc2fa4fd", "Administrator" });
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
