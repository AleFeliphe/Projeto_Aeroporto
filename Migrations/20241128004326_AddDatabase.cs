using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aeroporto.Migrations
{
    /// <inheritdoc />
    public partial class AddDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aeronaves",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    numero_Assento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Aeronave__3213E83FB5DCAF21", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ClientesPreferenciais",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    telefone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    data_nascimento = table.Column<DateOnly>(type: "date", nullable: false),
                    gestante = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    idoso = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Clientes__3213E83F49355665", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Assento",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    aeronave_id = table.Column<int>(type: "int", nullable: true),
                    numero = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    localizacao = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    disponibilidade = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Poltrona__3213E83F96B6E083", x => x.id);
                    table.ForeignKey(
                        name: "FK__Assento__dispo__3E52440B",
                        column: x => x.aeronave_id,
                        principalTable: "Aeronaves",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Voos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    aeroporto_origem = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    aeroporto_destino = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    horario_saida = table.Column<DateTime>(type: "datetime", nullable: false),
                    horario_previsto_chegada = table.Column<DateTime>(type: "datetime", nullable: false),
                    aeronave_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Voos__3213E83F2C326BB0", x => x.id);
                    table.ForeignKey(
                        name: "FK__Voos__aeronave_i__38996AB5",
                        column: x => x.aeronave_id,
                        principalTable: "Aeronaves",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Escalas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    voo_id = table.Column<int>(type: "int", nullable: true),
                    aeroporto_saida = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    horario_saida = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Escalas__3213E83FCF58F572", x => x.id);
                    table.ForeignKey(
                        name: "FK__Escalas__voo_id__3B75D760",
                        column: x => x.voo_id,
                        principalTable: "Voos",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    voo_id = table.Column<int>(type: "int", nullable: true),
                    poltrona_id = table.Column<int>(type: "int", nullable: true),
                    cliente_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Reservas__3213E83FF7558A66", x => x.id);
                    table.ForeignKey(
                        name: "FK__Reservas__client__44FF419A",
                        column: x => x.cliente_id,
                        principalTable: "ClientesPreferenciais",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__Reservas__poltro__440B1D61",
                        column: x => x.poltrona_id,
                        principalTable: "Assento",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__Reservas__voo_id__4316F928",
                        column: x => x.voo_id,
                        principalTable: "Voos",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assento_aeronave_id",
                table: "Assento",
                column: "aeronave_id");

            migrationBuilder.CreateIndex(
                name: "IX_Escalas_voo_id",
                table: "Escalas",
                column: "voo_id");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_cliente_id",
                table: "Reservas",
                column: "cliente_id");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_poltrona_id",
                table: "Reservas",
                column: "poltrona_id");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_voo_id",
                table: "Reservas",
                column: "voo_id");

            migrationBuilder.CreateIndex(
                name: "IX_Voos_aeronave_id",
                table: "Voos",
                column: "aeronave_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Escalas");

            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "ClientesPreferenciais");

            migrationBuilder.DropTable(
                name: "Assento");

            migrationBuilder.DropTable(
                name: "Voos");

            migrationBuilder.DropTable(
                name: "Aeronaves");
        }
    }
}
