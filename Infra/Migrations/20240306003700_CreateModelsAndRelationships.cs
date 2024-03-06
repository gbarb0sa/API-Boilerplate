using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infra.Migrations
{
    public partial class CreateModelsAndRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "addresses",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    street = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    city = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    zipcode = table.Column<string>(type: "text", nullable: false),
                    userId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_addresses", x => x.id);
                    table.ForeignKey(
                        name: "FK_addresses_users_userId",
                        column: x => x.userId,
                        principalSchema: "public",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "informations",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    bio = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    website = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    userId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_informations", x => x.id);
                    table.ForeignKey(
                        name: "FK_informations_users_userId",
                        column: x => x.userId,
                        principalSchema: "public",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user_roles",
                schema: "public",
                columns: table => new
                {
                    userId = table.Column<int>(type: "integer", nullable: false),
                    roleId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_roles", x => new { x.userId, x.roleId });
                    table.ForeignKey(
                        name: "FK_user_roles_roles_roleId",
                        column: x => x.roleId,
                        principalSchema: "public",
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_roles_users_userId",
                        column: x => x.userId,
                        principalSchema: "public",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_addresses_userId",
                schema: "public",
                table: "addresses",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_informations_userId",
                schema: "public",
                table: "informations",
                column: "userId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_roles_roleId",
                schema: "public",
                table: "user_roles",
                column: "roleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "addresses",
                schema: "public");

            migrationBuilder.DropTable(
                name: "informations",
                schema: "public");

            migrationBuilder.DropTable(
                name: "user_roles",
                schema: "public");

            migrationBuilder.DropTable(
                name: "roles",
                schema: "public");
        }
    }
}
