using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Source = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Destiny = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    UserCreationId = table.Column<int>(type: "INTEGER", nullable: false),
                    TripStatus = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trips_Users_UserCreationId",
                        column: x => x.UserCreationId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "trucker_trips",
                columns: table => new
                {
                    TripsId = table.Column<int>(type: "INTEGER", nullable: false),
                    TruckersId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trucker_trips", x => new { x.TripsId, x.TruckersId });
                    table.ForeignKey(
                        name: "FK_trucker_trips_Trips_TripsId",
                        column: x => x.TripsId,
                        principalTable: "Trips",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_trucker_trips_Users_TruckersId",
                        column: x => x.TruckersId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Discriminator", "Email", "Name", "Password" },
                values: new object[,]
                {
                    { 1, "Admin", "emiliano@mail.com", "Emiliano Falabrini", "123456" },
                    { 2, "Admin", "pablo@mail.com", "Pablo Paez", "123456" },
                    { 3, "Trucker", "mateo@mail.com", "Mateo García", "123456" },
                    { 4, "Trucker", "agustin@mail.com", "Agustin Baez", "123456" },
                    { 5, "Trucker", "gabriel@mail.com", "Gabriel Furrer", "123456" }
                });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "Id", "Description", "Destiny", "Source", "TripStatus", "UserCreationId" },
                values: new object[,]
                {
                    { 1, "Soja", "Rosario", "Santa Fe", 0, 1 },
                    { 2, "Trigo", "Rosario", "Rafaela", 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "trucker_trips",
                columns: new[] { "TripsId", "TruckersId" },
                values: new object[,]
                {
                    { 1, 3 },
                    { 1, 4 },
                    { 2, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trips_UserCreationId",
                table: "Trips",
                column: "UserCreationId");

            migrationBuilder.CreateIndex(
                name: "IX_trucker_trips_TruckersId",
                table: "trucker_trips",
                column: "TruckersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "trucker_trips");

            migrationBuilder.DropTable(
                name: "Trips");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
