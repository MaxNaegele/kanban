using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace kanban.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "departament",
                columns: table => new
                {
                    dpt_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    dpt_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    dpt_create_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_departament", x => x.dpt_id);
                });

            migrationBuilder.CreateTable(
                name: "status",
                columns: table => new
                {
                    stt_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    stt_description = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    stt_color = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_status", x => x.stt_id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    use_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    use_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    use_email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    use_create_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    use_password = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.use_id);
                });

            migrationBuilder.CreateTable(
                name: "board",
                columns: table => new
                {
                    brd_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    use_id = table.Column<long>(type: "bigint", nullable: false),
                    brd_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    brd_description = table.Column<string>(type: "text", nullable: true),
                    brd_create_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_board", x => x.brd_id);
                    table.ForeignKey(
                        name: "fk_board_reference_users",
                        column: x => x.use_id,
                        principalTable: "users",
                        principalColumn: "use_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "groups",
                columns: table => new
                {
                    grp_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    brd_id = table.Column<long>(type: "bigint", nullable: false),
                    grp_title = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    grp_create_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    grp_sequence = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_groups", x => x.grp_id);
                    table.ForeignKey(
                        name: "fk_groups_reference_board",
                        column: x => x.brd_id,
                        principalTable: "board",
                        principalColumn: "brd_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "card",
                columns: table => new
                {
                    crd_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    use_id = table.Column<long>(type: "bigint", nullable: false),
                    grp_id = table.Column<long>(type: "bigint", nullable: false),
                    stt_id = table.Column<long>(type: "bigint", nullable: false),
                    crd_sequence = table.Column<int>(type: "integer", nullable: false),
                    crd_title = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    crd_description = table.Column<string>(type: "text", nullable: true),
                    crd_create_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    crd_expected_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    crd_estimated_time = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    crd_balance_time = table.Column<TimeOnly>(type: "time without time zone", nullable: true),
                    crd_update_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_card", x => x.crd_id);
                    table.ForeignKey(
                        name: "fk_card_reference_groups",
                        column: x => x.grp_id,
                        principalTable: "groups",
                        principalColumn: "grp_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_card_reference_status",
                        column: x => x.stt_id,
                        principalTable: "status",
                        principalColumn: "stt_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_card_reference_users",
                        column: x => x.use_id,
                        principalTable: "users",
                        principalColumn: "use_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tasks_departament",
                columns: table => new
                {
                    dpt_id = table.Column<long>(type: "bigint", nullable: false),
                    crd_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tasks_departament", x => new { x.dpt_id, x.crd_id });
                    table.ForeignKey(
                        name: "fk_tasks_de_reference_card",
                        column: x => x.crd_id,
                        principalTable: "card",
                        principalColumn: "crd_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_tasks_de_reference_departam",
                        column: x => x.dpt_id,
                        principalTable: "departament",
                        principalColumn: "dpt_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "team",
                columns: table => new
                {
                    use_id = table.Column<long>(type: "bigint", nullable: false),
                    crd_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_team", x => new { x.use_id, x.crd_id });
                    table.ForeignKey(
                        name: "fk_team_reference_card",
                        column: x => x.crd_id,
                        principalTable: "card",
                        principalColumn: "crd_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_team_reference_users",
                        column: x => x.use_id,
                        principalTable: "users",
                        principalColumn: "use_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_board_use_id",
                table: "board",
                column: "use_id");

            migrationBuilder.CreateIndex(
                name: "IX_card_grp_id",
                table: "card",
                column: "grp_id");

            migrationBuilder.CreateIndex(
                name: "IX_card_stt_id",
                table: "card",
                column: "stt_id");

            migrationBuilder.CreateIndex(
                name: "IX_card_use_id",
                table: "card",
                column: "use_id");

            migrationBuilder.CreateIndex(
                name: "IX_groups_brd_id",
                table: "groups",
                column: "brd_id");

            migrationBuilder.CreateIndex(
                name: "IX_tasks_departament_crd_id",
                table: "tasks_departament",
                column: "crd_id");

            migrationBuilder.CreateIndex(
                name: "IX_team_crd_id",
                table: "team",
                column: "crd_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tasks_departament");

            migrationBuilder.DropTable(
                name: "team");

            migrationBuilder.DropTable(
                name: "departament");

            migrationBuilder.DropTable(
                name: "card");

            migrationBuilder.DropTable(
                name: "groups");

            migrationBuilder.DropTable(
                name: "status");

            migrationBuilder.DropTable(
                name: "board");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
