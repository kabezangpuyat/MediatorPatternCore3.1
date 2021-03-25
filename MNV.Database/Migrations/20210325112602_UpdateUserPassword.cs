using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MNV.Database.Migrations
{
    public partial class UpdateUserPassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "Key",
                schema: "dbo",
                table: "UserRole",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("d803f369-32f0-4024-8d82-e1f7e5f129d9"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("dc96aa78-6a8a-4809-954a-335c1183b9e9"));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DateCreated",
                schema: "dbo",
                table: "UserRole",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 3, 25, 19, 26, 1, 767, DateTimeKind.Unspecified).AddTicks(2427), new TimeSpan(0, 8, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 3, 14, 20, 53, 28, 499, DateTimeKind.Unspecified).AddTicks(8510), new TimeSpan(0, 8, 0, 0, 0)));

            migrationBuilder.AlterColumn<Guid>(
                name: "Key",
                schema: "dbo",
                table: "User",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("ccb25b82-191f-42d1-bdfd-5bdc6816a4a4"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("61a1dbaa-d838-459b-a0ef-6eb347e6b57e"));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DateCreated",
                schema: "dbo",
                table: "User",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 3, 25, 19, 26, 1, 762, DateTimeKind.Unspecified).AddTicks(9159), new TimeSpan(0, 8, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 3, 14, 20, 53, 28, 496, DateTimeKind.Unspecified).AddTicks(3266), new TimeSpan(0, 8, 0, 0, 0)));

            migrationBuilder.AlterColumn<Guid>(
                name: "Key",
                schema: "dbo",
                table: "Role",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("b3ca67c8-b437-4c77-b105-d48e5eeac5f2"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("fbbf329c-9c2c-4bdc-a87e-0da87a61e29f"));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DateCreated",
                schema: "dbo",
                table: "Role",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 3, 25, 19, 26, 1, 747, DateTimeKind.Unspecified).AddTicks(9833), new TimeSpan(0, 8, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 3, 14, 20, 53, 28, 483, DateTimeKind.Unspecified).AddTicks(5433), new TimeSpan(0, 8, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Role",
                keyColumn: "ID",
                keyValue: 1L,
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2021, 3, 25, 19, 26, 1, 770, DateTimeKind.Unspecified).AddTicks(674), new TimeSpan(0, 8, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Role",
                keyColumn: "ID",
                keyValue: 2L,
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2021, 3, 25, 19, 26, 1, 770, DateTimeKind.Unspecified).AddTicks(1301), new TimeSpan(0, 8, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Role",
                keyColumn: "ID",
                keyValue: 3L,
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2021, 3, 25, 19, 26, 1, 770, DateTimeKind.Unspecified).AddTicks(1321), new TimeSpan(0, 8, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "User",
                keyColumn: "ID",
                keyValue: 1L,
                columns: new[] { "DateCreated", "Password" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 3, 25, 19, 26, 1, 772, DateTimeKind.Unspecified).AddTicks(2473), new TimeSpan(0, 8, 0, 0, 0)), "Jaemp2W0c4pSRQ8SMICEvg==" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "User",
                keyColumn: "ID",
                keyValue: 2L,
                columns: new[] { "DateCreated", "Password" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 3, 25, 19, 26, 1, 772, DateTimeKind.Unspecified).AddTicks(2593), new TimeSpan(0, 8, 0, 0, 0)), "Jaemp2W0c4pSRQ8SMICEvg==" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserRole",
                keyColumn: "ID",
                keyValue: 1L,
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2021, 3, 25, 19, 26, 1, 772, DateTimeKind.Unspecified).AddTicks(6969), new TimeSpan(0, 8, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserRole",
                keyColumn: "ID",
                keyValue: 2L,
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2021, 3, 25, 19, 26, 1, 772, DateTimeKind.Unspecified).AddTicks(7019), new TimeSpan(0, 8, 0, 0, 0)));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "Key",
                schema: "dbo",
                table: "UserRole",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("dc96aa78-6a8a-4809-954a-335c1183b9e9"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("d803f369-32f0-4024-8d82-e1f7e5f129d9"));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DateCreated",
                schema: "dbo",
                table: "UserRole",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 3, 14, 20, 53, 28, 499, DateTimeKind.Unspecified).AddTicks(8510), new TimeSpan(0, 8, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 3, 25, 19, 26, 1, 767, DateTimeKind.Unspecified).AddTicks(2427), new TimeSpan(0, 8, 0, 0, 0)));

            migrationBuilder.AlterColumn<Guid>(
                name: "Key",
                schema: "dbo",
                table: "User",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("61a1dbaa-d838-459b-a0ef-6eb347e6b57e"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("ccb25b82-191f-42d1-bdfd-5bdc6816a4a4"));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DateCreated",
                schema: "dbo",
                table: "User",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 3, 14, 20, 53, 28, 496, DateTimeKind.Unspecified).AddTicks(3266), new TimeSpan(0, 8, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 3, 25, 19, 26, 1, 762, DateTimeKind.Unspecified).AddTicks(9159), new TimeSpan(0, 8, 0, 0, 0)));

            migrationBuilder.AlterColumn<Guid>(
                name: "Key",
                schema: "dbo",
                table: "Role",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("fbbf329c-9c2c-4bdc-a87e-0da87a61e29f"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("b3ca67c8-b437-4c77-b105-d48e5eeac5f2"));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DateCreated",
                schema: "dbo",
                table: "Role",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2021, 3, 14, 20, 53, 28, 483, DateTimeKind.Unspecified).AddTicks(5433), new TimeSpan(0, 8, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValue: new DateTimeOffset(new DateTime(2021, 3, 25, 19, 26, 1, 747, DateTimeKind.Unspecified).AddTicks(9833), new TimeSpan(0, 8, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Role",
                keyColumn: "ID",
                keyValue: 1L,
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2021, 3, 14, 20, 53, 28, 502, DateTimeKind.Unspecified).AddTicks(4086), new TimeSpan(0, 8, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Role",
                keyColumn: "ID",
                keyValue: 2L,
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2021, 3, 14, 20, 53, 28, 502, DateTimeKind.Unspecified).AddTicks(4635), new TimeSpan(0, 8, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Role",
                keyColumn: "ID",
                keyValue: 3L,
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2021, 3, 14, 20, 53, 28, 502, DateTimeKind.Unspecified).AddTicks(4653), new TimeSpan(0, 8, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "User",
                keyColumn: "ID",
                keyValue: 1L,
                columns: new[] { "DateCreated", "Password" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 3, 14, 20, 53, 28, 504, DateTimeKind.Unspecified).AddTicks(3665), new TimeSpan(0, 8, 0, 0, 0)), "Pasok12345" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "User",
                keyColumn: "ID",
                keyValue: 2L,
                columns: new[] { "DateCreated", "Password" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 3, 14, 20, 53, 28, 504, DateTimeKind.Unspecified).AddTicks(3751), new TimeSpan(0, 8, 0, 0, 0)), "Pasok12345" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserRole",
                keyColumn: "ID",
                keyValue: 1L,
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2021, 3, 14, 20, 53, 28, 504, DateTimeKind.Unspecified).AddTicks(7426), new TimeSpan(0, 8, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "UserRole",
                keyColumn: "ID",
                keyValue: 2L,
                column: "DateCreated",
                value: new DateTimeOffset(new DateTime(2021, 3, 14, 20, 53, 28, 504, DateTimeKind.Unspecified).AddTicks(7467), new TimeSpan(0, 8, 0, 0, 0)));
        }
    }
}
