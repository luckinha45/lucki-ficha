using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class Ini : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FichaT20",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Classe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Raca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nivel = table.Column<int>(type: "int", nullable: false),
                    Experiencia = table.Column<int>(type: "int", nullable: false),
                    Dinheiro = table.Column<int>(type: "int", nullable: false),
                    VidaAtual = table.Column<int>(type: "int", nullable: false),
                    VidaMaxima = table.Column<int>(type: "int", nullable: false),
                    ManaAtual = table.Column<int>(type: "int", nullable: false),
                    ManaMaxima = table.Column<int>(type: "int", nullable: false),
                    Forca = table.Column<int>(type: "int", nullable: false),
                    Destreza = table.Column<int>(type: "int", nullable: false),
                    Constituicao = table.Column<int>(type: "int", nullable: false),
                    Inteligencia = table.Column<int>(type: "int", nullable: false),
                    Sabedoria = table.Column<int>(type: "int", nullable: false),
                    Carisma = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FichaT20", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EquipamentoT20",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Peso = table.Column<int>(type: "int", nullable: false),
                    Preco = table.Column<int>(type: "int", nullable: false),
                    FichaT20Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipamentoT20", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EquipamentoT20_FichaT20_FichaT20Id",
                        column: x => x.FichaT20Id,
                        principalTable: "FichaT20",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HabilidadeT20",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FichaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HabilidadeT20", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HabilidadeT20_FichaT20_FichaId",
                        column: x => x.FichaId,
                        principalTable: "FichaT20",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PericiaT20",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valor = table.Column<int>(type: "int", nullable: false),
                    FichaT20Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PericiaT20", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PericiaT20_FichaT20_FichaT20Id",
                        column: x => x.FichaT20Id,
                        principalTable: "FichaT20",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModT20",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HabilidadeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EquipamentoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AplicaEm = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valor = table.Column<int>(type: "int", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModT20", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModT20_EquipamentoT20_EquipamentoId",
                        column: x => x.EquipamentoId,
                        principalTable: "EquipamentoT20",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ModT20_HabilidadeT20_HabilidadeId",
                        column: x => x.HabilidadeId,
                        principalTable: "HabilidadeT20",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EquipamentoT20_FichaT20Id",
                table: "EquipamentoT20",
                column: "FichaT20Id");

            migrationBuilder.CreateIndex(
                name: "IX_HabilidadeT20_FichaId",
                table: "HabilidadeT20",
                column: "FichaId");

            migrationBuilder.CreateIndex(
                name: "IX_ModT20_EquipamentoId",
                table: "ModT20",
                column: "EquipamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_ModT20_HabilidadeId",
                table: "ModT20",
                column: "HabilidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_PericiaT20_FichaT20Id",
                table: "PericiaT20",
                column: "FichaT20Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModT20");

            migrationBuilder.DropTable(
                name: "PericiaT20");

            migrationBuilder.DropTable(
                name: "EquipamentoT20");

            migrationBuilder.DropTable(
                name: "HabilidadeT20");

            migrationBuilder.DropTable(
                name: "FichaT20");
        }
    }
}
