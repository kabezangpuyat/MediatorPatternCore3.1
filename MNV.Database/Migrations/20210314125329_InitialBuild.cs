using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MNV.Database.Migrations
{
    public partial class InitialBuild : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Role",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Key = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValue: new Guid("fbbf329c-9c2c-4bdc-a87e-0da87a61e29f")),
                    CreatedByID = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedByID = table.Column<long>(type: "bigint", nullable: true),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2021, 3, 14, 20, 53, 28, 483, DateTimeKind.Unspecified).AddTicks(5433), new TimeSpan(0, 8, 0, 0, 0))),
                    DateModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Key = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValue: new Guid("61a1dbaa-d838-459b-a0ef-6eb347e6b57e")),
                    CreatedByID = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedByID = table.Column<long>(type: "bigint", nullable: true),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2021, 3, 14, 20, 53, 28, 496, DateTimeKind.Unspecified).AddTicks(3266), new TimeSpan(0, 8, 0, 0, 0))),
                    DateModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RefreshToken",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<long>(type: "bigint", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Expires = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Revoked = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RevokedByIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReplacedByToken = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RefreshToken_User_UserID",
                        column: x => x.UserID,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<long>(type: "bigint", nullable: false),
                    RoleID = table.Column<long>(type: "bigint", nullable: false),
                    Key = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValue: new Guid("dc96aa78-6a8a-4809-954a-335c1183b9e9")),
                    CreatedByID = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedByID = table.Column<long>(type: "bigint", nullable: true),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2021, 3, 14, 20, 53, 28, 499, DateTimeKind.Unspecified).AddTicks(8510), new TimeSpan(0, 8, 0, 0, 0))),
                    DateModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleID",
                        column: x => x.RoleID,
                        principalSchema: "dbo",
                        principalTable: "Role",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_User_UserID",
                        column: x => x.UserID,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Role",
                columns: new[] { "ID", "Active", "CreatedByID", "DateCreated", "DateModified", "Description", "Key", "ModifiedByID", "Name" },
                values: new object[,]
                {
                    { 1L, true, null, new DateTimeOffset(new DateTime(2021, 3, 14, 20, 53, 28, 502, DateTimeKind.Unspecified).AddTicks(4086), new TimeSpan(0, 8, 0, 0, 0)), null, "Super Administrator", new Guid("2b7d30d0-8dc0-4343-9275-860e3959472e"), null, "Superadmin" },
                    { 2L, true, null, new DateTimeOffset(new DateTime(2021, 3, 14, 20, 53, 28, 502, DateTimeKind.Unspecified).AddTicks(4635), new TimeSpan(0, 8, 0, 0, 0)), null, "Administrator", new Guid("80b24d7b-8873-4e04-9b91-9fb70c07aacf"), null, "Administrator" },
                    { 3L, true, null, new DateTimeOffset(new DateTime(2021, 3, 14, 20, 53, 28, 502, DateTimeKind.Unspecified).AddTicks(4653), new TimeSpan(0, 8, 0, 0, 0)), null, "Guest", new Guid("e2a7b30a-face-4aea-ae6e-af57b2634daa"), null, "Guest" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "User",
                columns: new[] { "ID", "Active", "CreatedByID", "DateCreated", "DateModified", "Email", "FirstName", "Key", "LastName", "MiddleName", "ModifiedByID", "Password", "Username" },
                values: new object[,]
                {
                    { 1L, true, 1L, new DateTimeOffset(new DateTime(2021, 3, 14, 20, 53, 28, 504, DateTimeKind.Unspecified).AddTicks(3665), new TimeSpan(0, 8, 0, 0, 0)), null, "mcnielv@gmail.com", "McNiel", new Guid("2b7d30d0-8dc0-4343-9275-860e3959472e"), "Viray", "N", null, "Pasok12345", "mcnielv@gmail.com" },
                    { 2L, true, 1L, new DateTimeOffset(new DateTime(2021, 3, 14, 20, 53, 28, 504, DateTimeKind.Unspecified).AddTicks(3751), new TimeSpan(0, 8, 0, 0, 0)), null, "mcniel.viray@gmail.com", "McNiel", new Guid("80b24d7b-8873-4e04-9b91-9fb70c07aacf"), "Viray II", "N", null, "Pasok12345", "mcniel.viray@gmail.com" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "UserRole",
                columns: new[] { "ID", "Active", "CreatedByID", "DateCreated", "DateModified", "Key", "ModifiedByID", "RoleID", "UserID" },
                values: new object[] { 1L, true, null, new DateTimeOffset(new DateTime(2021, 3, 14, 20, 53, 28, 504, DateTimeKind.Unspecified).AddTicks(7426), new TimeSpan(0, 8, 0, 0, 0)), null, new Guid("2b7d30d0-8dc0-4343-9275-860e3959472e"), null, 1L, 1L });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "UserRole",
                columns: new[] { "ID", "Active", "CreatedByID", "DateCreated", "DateModified", "Key", "ModifiedByID", "RoleID", "UserID" },
                values: new object[] { 2L, true, null, new DateTimeOffset(new DateTime(2021, 3, 14, 20, 53, 28, 504, DateTimeKind.Unspecified).AddTicks(7467), new TimeSpan(0, 8, 0, 0, 0)), null, new Guid("80b24d7b-8873-4e04-9b91-9fb70c07aacf"), null, 3L, 2L });

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_UserID",
                schema: "dbo",
                table: "RefreshToken",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Role_Name",
                schema: "dbo",
                table: "Role",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                schema: "dbo",
                table: "User",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_User_Username",
                schema: "dbo",
                table: "User",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleID",
                schema: "dbo",
                table: "UserRole",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserID",
                schema: "dbo",
                table: "UserRole",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RefreshToken",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserRole",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Role",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "User",
                schema: "dbo");
        }
    }
}
