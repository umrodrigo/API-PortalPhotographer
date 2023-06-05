using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "entityPhoto",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", maxLength: null, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: null, nullable: true),
                    Order = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_entityPhoto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "entityType",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Code = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_entityType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "entityUser",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_entityUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "entitySector",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdType = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_entitySector", x => x.Id);
                    table.ForeignKey(
                        name: "FK_entitySector_entityType_IdType",
                        column: x => x.IdType,
                        principalSchema: "dbo",
                        principalTable: "entityType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "photoSector",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdEntityPhoto = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdEntitySector = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_photoSector", x => x.Id);
                    table.ForeignKey(
                        name: "FK_photoSector_entityPhoto_IdEntityPhoto",
                        column: x => x.IdEntityPhoto,
                        principalSchema: "dbo",
                        principalTable: "entityPhoto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_photoSector_entitySector_IdEntitySector",
                        column: x => x.IdEntitySector,
                        principalSchema: "dbo",
                        principalTable: "entitySector",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_entitySector_IdType",
                schema: "dbo",
                table: "entitySector",
                column: "IdType");

            migrationBuilder.CreateIndex(
                name: "IX_photoSector_IdEntityPhoto",
                schema: "dbo",
                table: "photoSector",
                column: "IdEntityPhoto",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_photoSector_IdEntitySector",
                schema: "dbo",
                table: "photoSector",
                column: "IdEntitySector",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "entityUser",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "photoSector",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "entityPhoto",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "entitySector",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "entityType",
                schema: "dbo");
        }
    }
}
