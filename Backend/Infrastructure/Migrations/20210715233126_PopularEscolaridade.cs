using Confitec.Domain.Entities;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Confitec.Infrastructure.Migrations
{
    public partial class PopularEscolaridade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Escolaridades", new string[] { nameof(Escolaridade.Descricao), nameof(Escolaridade.Ativo) }, new object[] { "Infantil", true });
            migrationBuilder.InsertData("Escolaridades", new string[] { nameof(Escolaridade.Descricao), nameof(Escolaridade.Ativo) }, new object[] { "Fundamental", true });
            migrationBuilder.InsertData("Escolaridades", new string[] { nameof(Escolaridade.Descricao), nameof(Escolaridade.Ativo) }, new object[] { "Medio", true });
            migrationBuilder.InsertData("Escolaridades", new string[] { nameof(Escolaridade.Descricao), nameof(Escolaridade.Ativo) }, new object[] { "Superior", true });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
