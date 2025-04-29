using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace practicaExamen.Entities
{
    /// <inheritdoc />
    public partial class MigracionInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Propietario",
                columns: table => new
                {
                    identificaion = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    telefono = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    direccion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Propietario", x => x.identificaion);
                });

            migrationBuilder.CreateTable(
                name: "Carro",
                columns: table => new
                {
                    placa = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    cilindraje = table.Column<double>(type: "float", nullable: false),
                    modelo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    propietarioIdentificacion = table.Column<string>(type: "nvarchar(15)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carro", x => x.placa);
                    table.ForeignKey(
                        name: "FK_Carro_Propietario_propietarioIdentificacion",
                        column: x => x.propietarioIdentificacion,
                        principalTable: "Propietario",
                        principalColumn: "identificaion",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carro_propietarioIdentificacion",
                table: "Carro",
                column: "propietarioIdentificacion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carro");

            migrationBuilder.DropTable(
                name: "Propietario");
        }
    }
}
