using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kanban.Data.Migrations
{
    public partial class AlterTimeOnlyToLong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "crd_estimated_time",
                table: "card",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(TimeOnly),
                oldType: "time without time zone");

            migrationBuilder.AlterColumn<long>(
                name: "crd_balance_time",
                table: "card",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(TimeOnly),
                oldType: "time without time zone",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeOnly>(
                name: "crd_estimated_time",
                table: "card",
                type: "time without time zone",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<TimeOnly>(
                name: "crd_balance_time",
                table: "card",
                type: "time without time zone",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);
        }
    }
}
