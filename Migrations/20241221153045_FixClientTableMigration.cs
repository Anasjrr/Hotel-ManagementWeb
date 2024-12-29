using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelReservationWeb.Migrations
{
    public partial class FixClientTableMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Create Clients table if it doesn't exist
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    isClient = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            // Create Rooms table if it doesn't exist
            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nprice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TypeR = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    PicturePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                });

            // Create Users table if it doesn't exist
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: ""),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: ""),
                    ClientId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                });

            // Create Employees table with UserId column defined as nullable
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    isEmployee = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true) // Ensure UserId is here and nullable
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Users_UserId", // Foreign Key to Users table
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            // Create Managers table with UserId column defined as nullable
            migrationBuilder.CreateTable(
                name: "Managers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    isManager = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true) // Ensure UserId is here and nullable
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Managers_Users_UserId", // Foreign Key to Users table
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            // Create indexes for foreign key relationships
            migrationBuilder.CreateIndex(
                name: "IX_Employees_UserId",
                table: "Employees",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Managers_UserId",
                table: "Managers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ClientId",
                table: "Users",
                column: "ClientId",
                unique: true,
                filter: "[ClientId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Employees");
            migrationBuilder.DropTable(name: "Managers");
            migrationBuilder.DropTable(name: "Rooms");
            migrationBuilder.DropTable(name: "Users");
            migrationBuilder.DropTable(name: "Clients");
        }
    }
}
