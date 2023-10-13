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
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    StatusCategory = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
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

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusProduct = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Design",
                columns: table => new
                {
                    DesignId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusDesign = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Design", x => x.DesignId);
                    table.ForeignKey(
                        name: "FK_Design_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Flyes",
                columns: table => new
                {
                    FlyesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DesignId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusFlyes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flyes", x => x.FlyesId);
                    table.ForeignKey(
                        name: "FK_Flyes_Design_DesignId",
                        column: x => x.DesignId,
                        principalTable: "Design",
                        principalColumn: "DesignId",
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
                table: "Category",
                columns: new[] { "CategoryId", "Descripcion", "Name", "StatusCategory" },
                values: new object[,]
                {
                    { new Guid("ae6f2420-78ac-4145-b2d9-6de49e108671"), "Products of exp marketing center", "Products", 0 },
                    { new Guid("b1b0b0a0-78ac-4145-b2d9-6de49e108672"), "Designs of exp marketing center", "Designs", 0 },
                    { new Guid("c2c0c0a0-78ac-4145-b2d9-6de49e108673"), "Marketing of exp marketing center", "Marketing", 0 },
                    { new Guid("c2c0c0a0-78ac-4145-b2d9-6de49e108674"), "Intentions of exp marketing center", "Intentions", 1 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "CreationDate", "Descripcion", "ImageUrl", "Name", "StatusProduct" },
                values: new object[,]
                {
                    { new Guid("06f8c9a2-4d5f-4a7c-9c3d-3e7f7e8d2a1a"), new Guid("ae6f2420-78ac-4145-b2d9-6de49e108671"), new DateTime(2023, 10, 13, 11, 52, 12, 83, DateTimeKind.Local).AddTicks(8722), "Keep your sphere informed and updated with industry insights and other helpful topics.", "https://gmbb20.s3.amazonaws.com/home/crop_crop_Newsletter_650x650.png", "NewsLetters", 0 },
                    { new Guid("16f8c9a2-4d5f-4a7c-9c3d-3e7f7e8d2a1a"), new Guid("ae6f2420-78ac-4145-b2d9-6de49e108671"), new DateTime(2023, 10, 13, 11, 52, 12, 83, DateTimeKind.Local).AddTicks(8719), "Keep your communications branded with the information your contacts need.", "https://gmbb20.s3.amazonaws.com/home/crop_crop_Email_Signature_650x650.png", "Email Signatures", 0 },
                    { new Guid("26f8c9a2-4d5f-4a7c-9c3d-3e7f7e8d2a1a"), new Guid("ae6f2420-78ac-4145-b2d9-6de49e108671"), new DateTime(2023, 10, 13, 11, 52, 12, 83, DateTimeKind.Local).AddTicks(8715), "Create a first and lasting impression by using one of a variety of branded business cards.", "https://gmbb20.s3.amazonaws.com/home/crop_crop_Business_Card_650x650.png", "Business Cards", 0 },
                    { new Guid("36f8c9a2-4d5f-4a7c-9c3d-3e7f7e8d2a1a"), new Guid("ae6f2420-78ac-4145-b2d9-6de49e108671"), new DateTime(2023, 10, 13, 11, 52, 12, 83, DateTimeKind.Local).AddTicks(8711), "Cover your bases with the help of these branded documents.", "https://gmbb20.s3.amazonaws.com/home/crop_crop_Helpful_Docs_650x650.png", "Helpful Documents", 0 },
                    { new Guid("46f8c9a2-4d5f-4a7c-9c3d-3e7f7e8d2a1a"), new Guid("ae6f2420-78ac-4145-b2d9-6de49e108671"), new DateTime(2023, 10, 13, 11, 52, 12, 83, DateTimeKind.Local).AddTicks(8709), "Connect with past and future clients with pre-written letters and customizable letterheads.", "https://gmbb20.s3.amazonaws.com/home/crop_crop_Letter_650x650.png", "Letter/LetterHeads", 0 },
                    { new Guid("56f8c9a2-4d5f-4a7c-9c3d-3e7f7e8d2a1a"), new Guid("ae6f2420-78ac-4145-b2d9-6de49e108671"), new DateTime(2023, 10, 13, 11, 52, 12, 83, DateTimeKind.Local).AddTicks(8703), "Educate your sphere about the real estate industry with our informative videos.", "https://gmbb20.s3.amazonaws.com/home/crop_crop_Video_Mockup_650x650.png", "Videos", 0 },
                    { new Guid("66f8c9a2-4d5f-4a7c-9c3d-3e7f7e8d2a1a"), new Guid("ae6f2420-78ac-4145-b2d9-6de49e108671"), new DateTime(2023, 10, 13, 11, 52, 12, 83, DateTimeKind.Local).AddTicks(8699), "Make an impression on your clients with our elegant presentations.", "https://gmbb20.s3.amazonaws.com/home/crop_crop_Presentation_650x650.png", "Presentations", 0 },
                    { new Guid("76f8c9a2-4d5f-4a7c-9c3d-3e7f7e8d2a1a"), new Guid("ae6f2420-78ac-4145-b2d9-6de49e108671"), new DateTime(2023, 10, 13, 11, 52, 12, 83, DateTimeKind.Local).AddTicks(8696), "Attract attention to your listings, open house, or yourself with a customizable door hanger.", "https://gmbb20.s3.amazonaws.com/home/crop_crop_Doorhanger_650x650.png", "Door Hangers", 0 },
                    { new Guid("86f8c9a2-4d5f-4a7c-9c3d-3e7f7e8d2a1a"), new Guid("ae6f2420-78ac-4145-b2d9-6de49e108671"), new DateTime(2023, 10, 13, 11, 52, 12, 83, DateTimeKind.Local).AddTicks(8694), "Level up your marketing using single property sites.", "https://gmbb20.s3.amazonaws.com/home/crop_crop_Laptop_650x650.png", "Single Property Sites", 0 },
                    { new Guid("96f8c9a2-4d5f-4a7c-9c3d-3e7f7e8d2a1a"), new Guid("ae6f2420-78ac-4145-b2d9-6de49e108671"), new DateTime(2023, 10, 13, 11, 52, 12, 83, DateTimeKind.Local).AddTicks(8689), "Walled Garden integration to automate and easily launch Facebook ads.", "https://gmbb20.s3.amazonaws.com/home/crop_thumb-ref3.png", "FaceBook Ads", 0 },
                    { new Guid("a6f8c9a2-4d5f-4a7c-9c3d-3e7f7e8d2a1a"), new Guid("ae6f2420-78ac-4145-b2d9-6de49e108671"), new DateTime(2023, 10, 13, 11, 52, 12, 83, DateTimeKind.Local).AddTicks(8686), "Engage with your audience by using our ready-to-share social media items.", "https://gmbb20.s3.amazonaws.com/home/crop_crop_Social_Media_650x650.png", "Social Media", 0 },
                    { new Guid("ae6f2420-78ac-4145-b2d9-6de49e108661"), new Guid("ae6f2420-78ac-4145-b2d9-6de49e108671"), new DateTime(2023, 10, 13, 11, 52, 12, 83, DateTimeKind.Local).AddTicks(8667), "Provide a memorable takeaway with our collection of professionally-designed flyers.", "https://gmbb20.s3.amazonaws.com/home/crop_crop_Flyer_650x650.png", "Flyers", 0 },
                    { new Guid("b6f8c9a2-4d5f-4a7c-9c3d-3e7f7e8d2a1a"), new Guid("ae6f2420-78ac-4145-b2d9-6de49e108671"), new DateTime(2023, 10, 13, 11, 52, 12, 83, DateTimeKind.Local).AddTicks(8683), "Advertise your listing with our luxury 8-page booklets and classic brochures.", "https://gmbb20.s3.amazonaws.com/home/crop_crop_Brochure_650x650_1.png", "Brochures", 0 },
                    { new Guid("d6f8c9a2-4d5f-4a7c-9c3d-3e7f7e8d2a1a"), new Guid("ae6f2420-78ac-4145-b2d9-6de49e108671"), new DateTime(2023, 10, 13, 11, 52, 12, 83, DateTimeKind.Local).AddTicks(8680), "Explore a variety of postcards designed for every occasion.", "https://gmbb20.s3.amazonaws.com/home/crop_crop_Postcard_650x650_1.png", "PostCards", 0 },
                    { new Guid("e6f8c9a2-4d5f-4a7c-9c3d-3e7f7e8d2a1a"), new Guid("ae6f2420-78ac-4145-b2d9-6de49e108671"), new DateTime(2023, 10, 13, 11, 52, 12, 83, DateTimeKind.Local).AddTicks(8730), "Download partner resources to provide your clients with valuable information.", "https://gmbb20.s3.amazonaws.com/home/crop_eXp_Solutions_650x650.png", "eXp Solutions", 0 },
                    { new Guid("f6f8c9a2-4d5f-4a7c-9c3d-3e7f7e8d2a1a"), new Guid("ae6f2420-78ac-4145-b2d9-6de49e108671"), new DateTime(2023, 10, 13, 11, 52, 12, 83, DateTimeKind.Local).AddTicks(8726), "Appeal to Spanish-speaking audiences with our variety of Spanish marketing items.", "https://gmbb20.s3.amazonaws.com/home/crop_crop_Spanish_Marketing_650x650.png", "Spanish Materials", 0 }
                });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaId", "Descripcion", "FechaCreacion", "PrioridadTarea", "Titulo" },
                values: new object[,]
                {
                    { new Guid("ae6f2420-78ac-4145-b2d9-6de49e108661"), new Guid("ae6f2420-78ac-4145-b2d9-6de49e10867e"), "Realizar el back segun mokups en .Net y C#", new DateTime(2023, 10, 13, 11, 52, 12, 83, DateTimeKind.Local).AddTicks(5648), 2, "Hacer le back en .Net" },
                    { new Guid("ae6f2420-78ac-4145-b2d9-6de49e108662"), new Guid("ae6f2420-78ac-4145-b2d9-6de49e10867e"), "Realizar el front segun mokups en Angular", new DateTime(2023, 10, 13, 11, 52, 12, 83, DateTimeKind.Local).AddTicks(5662), 2, "Hacer le front en Angular" },
                    { new Guid("ae6f2420-78ac-4145-b2d9-6de49e108663"), new Guid("b1b0b0a0-78ac-4145-b2d9-6de49e10867e"), "Ordenar la cocina", new DateTime(2023, 10, 13, 11, 52, 12, 83, DateTimeKind.Local).AddTicks(5664), 0, "Hacer le front en React" },
                    { new Guid("ae6f2420-78ac-4145-b2d9-6de49e108664"), new Guid("c2c0c0a0-78ac-4145-b2d9-6de49e10867e"), "Ordenar la pecera y alimentar a los peces", new DateTime(2023, 10, 13, 11, 52, 12, 83, DateTimeKind.Local).AddTicks(5667), 1, "dar de comer a los peces" },
                    { new Guid("ae6f2420-78ac-4145-b2d9-6de49e108665"), new Guid("c2c0c0a0-78ac-4145-b2d9-6de49e10867e"), "Realizar el front segun mokups en Vue", new DateTime(2023, 10, 13, 11, 52, 12, 83, DateTimeKind.Local).AddTicks(5669), 2, "Hacer le front en Vue" }
                });

            migrationBuilder.InsertData(
                table: "Design",
                columns: new[] { "DesignId", "CreationDate", "Descripcion", "ImageUrl", "Name", "ProductId", "StatusDesign" },
                values: new object[] { new Guid("ae6f2420-78ac-4145-b2d9-6de49e108678"), new DateTime(2023, 10, 13, 11, 52, 12, 85, DateTimeKind.Local).AddTicks(6251), "Provide a memorable takeaway with our collection of professionally-designed flyers.", "https://gmbb20.s3.amazonaws.com/Interior/Captura+de+pantalla+2023-09-26+111128.png", "Listing", new Guid("ae6f2420-78ac-4145-b2d9-6de49e108661"), 0 });

            migrationBuilder.InsertData(
                table: "Design",
                columns: new[] { "DesignId", "CreationDate", "Descripcion", "ImageUrl", "Name", "ProductId", "StatusDesign" },
                values: new object[] { new Guid("d6f8c9a2-4d5f-4a7c-9c3d-3e7f7e8d2a96"), new DateTime(2023, 10, 13, 11, 52, 12, 85, DateTimeKind.Local).AddTicks(6264), "Explore a variety of postcards designed for every occasion.", "https://gmbb20.s3.amazonaws.com/Interior/openhouse.jpg", "Open House", new Guid("ae6f2420-78ac-4145-b2d9-6de49e108661"), 0 });

            migrationBuilder.InsertData(
                table: "Flyes",
                columns: new[] { "FlyesId", "CreationDate", "Descripcion", "DesignId", "ImageUrl", "Name", "StatusFlyes" },
                values: new object[] { new Guid("d1f8c9a2-4d5f-4a7c-9c3d-3e7f7e8d2a96"), new DateTime(2023, 10, 13, 11, 52, 12, 86, DateTimeKind.Local).AddTicks(4865), "Suave Flyes", new Guid("ae6f2420-78ac-4145-b2d9-6de49e108678"), "https://gmbb20.s3.amazonaws.com/Interior/Captura+de+pantalla+2023-09-26+111128.png", "Suave", 0 });

            migrationBuilder.InsertData(
                table: "Flyes",
                columns: new[] { "FlyesId", "CreationDate", "Descripcion", "DesignId", "ImageUrl", "Name", "StatusFlyes" },
                values: new object[] { new Guid("d658c9a2-4d5f-4a7c-9c3d-3e7f7e8d2a96"), new DateTime(2023, 10, 13, 11, 52, 12, 86, DateTimeKind.Local).AddTicks(4862), "Nova Flyes", new Guid("ae6f2420-78ac-4145-b2d9-6de49e108678"), "https://gmbb20.s3.amazonaws.com/Interior/Captura+de+pantalla+2023-09-26+111128.png", "Nova", 0 });

            migrationBuilder.InsertData(
                table: "Flyes",
                columns: new[] { "FlyesId", "CreationDate", "Descripcion", "DesignId", "ImageUrl", "Name", "StatusFlyes" },
                values: new object[] { new Guid("d6f869a2-4d5f-4a7c-9c3d-3e7f7e8d2a96"), new DateTime(2023, 10, 13, 11, 52, 12, 86, DateTimeKind.Local).AddTicks(4851), "Royal Blue 2 Sided Flyes", new Guid("ae6f2420-78ac-4145-b2d9-6de49e108678"), "https://gmbb20.s3.amazonaws.com/Interior/Captura+de+pantalla+2023-09-26+111128.png", "Royal", 0 });

            migrationBuilder.CreateIndex(
                name: "IX_Design_ProductId",
                table: "Design",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Flyes_DesignId",
                table: "Flyes",
                column: "DesignId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarea_CategoriaId",
                table: "Tarea",
                column: "CategoriaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flyes");

            migrationBuilder.DropTable(
                name: "Tarea");

            migrationBuilder.DropTable(
                name: "Design");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
