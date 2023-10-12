using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIs.Migrations
{
    public partial class InitialCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    CategoriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Peso = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.CategoriaId);
                });

            migrationBuilder.CreateTable(
                name: "Tarea",
                columns: table => new
                {
                    TareaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PrioridadTarea = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarea", x => x.TareaId);
                    table.ForeignKey(
                        name: "FK_Tarea_Categoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categoria",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Descripcion", "Nombre", "Peso" },
                values: new object[,]
                {
                    { new Guid("ae6f2420-78ac-4145-b2d9-6de49e10867e"), "Tareas relacionadas con el trabajo", "Trabajo", 60 },
                    { new Guid("b1b0b0a0-78ac-4145-b2d9-6de49e10867e"), "Tareas personales", "Personal", 30 },
                    { new Guid("c2c0c0a0-78ac-4145-b2d9-6de49e10867e"), "Tareas de ocio", "Ocio", 10 },
                    { new Guid("d3d0d0a0-78ac-4145-b2d9-6de49e10867e"), "Tareas relacionadas con los estudios", "Estudios", 20 }
                });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaId", "Descripcion", "FechaCreacion", "PrioridadTarea", "Titulo" },
                values: new object[,]
                {
                    { new Guid("ae6f2420-78ac-4145-b2d9-6de49e108661"), new Guid("ae6f2420-78ac-4145-b2d9-6de49e10867e"), "Realizar el back segun mokups en .Net y C#", new DateTime(2023, 10, 12, 12, 41, 47, 275, DateTimeKind.Local).AddTicks(6156), 2, "Hacer le back en .Net" },
                    { new Guid("ae6f2420-78ac-4145-b2d9-6de49e108662"), new Guid("ae6f2420-78ac-4145-b2d9-6de49e10867e"), "Realizar el front segun mokups en Angular", new DateTime(2023, 10, 12, 12, 41, 47, 275, DateTimeKind.Local).AddTicks(6172), 2, "Hacer le front en Angular" },
                    { new Guid("ae6f2420-78ac-4145-b2d9-6de49e108663"), new Guid("b1b0b0a0-78ac-4145-b2d9-6de49e10867e"), "Ordenar la cocina", new DateTime(2023, 10, 12, 12, 41, 47, 275, DateTimeKind.Local).AddTicks(6175), 0, "Hacer le front en React" },
                    { new Guid("ae6f2420-78ac-4145-b2d9-6de49e108664"), new Guid("c2c0c0a0-78ac-4145-b2d9-6de49e10867e"), "Ordenar la pecera y alimentar a los peces", new DateTime(2023, 10, 12, 12, 41, 47, 275, DateTimeKind.Local).AddTicks(6178), 1, "dar de comer a los peces" },
                    { new Guid("ae6f2420-78ac-4145-b2d9-6de49e108665"), new Guid("c2c0c0a0-78ac-4145-b2d9-6de49e10867e"), "Realizar el front segun mokups en Vue", new DateTime(2023, 10, 12, 12, 41, 47, 275, DateTimeKind.Local).AddTicks(6180), 2, "Hacer le front en Vue" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tarea_CategoriaId",
                table: "Tarea",
                column: "CategoriaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tarea");

            migrationBuilder.DropTable(
                name: "Categoria");
        }
    }
}
