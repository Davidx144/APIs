﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using proyectoef;

#nullable disable

namespace APIs.Migrations
{
    [DbContext(typeof(TareasContext))]
    partial class TareasContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("proyectoef.Models.Categoria", b =>
                {
                    b.Property<Guid>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("Peso")
                        .HasColumnType("int");

                    b.HasKey("CategoriaId");

                    b.ToTable("Categoria", (string)null);

                    b.HasData(
                        new
                        {
                            CategoriaId = new Guid("ae6f2420-78ac-4145-b2d9-6de49e10867e"),
                            Descripcion = "Tareas relacionadas con el trabajo",
                            Nombre = "Trabajo",
                            Peso = 60
                        },
                        new
                        {
                            CategoriaId = new Guid("b1b0b0a0-78ac-4145-b2d9-6de49e10867e"),
                            Descripcion = "Tareas personales",
                            Nombre = "Personal",
                            Peso = 30
                        },
                        new
                        {
                            CategoriaId = new Guid("c2c0c0a0-78ac-4145-b2d9-6de49e10867e"),
                            Descripcion = "Tareas de ocio",
                            Nombre = "Ocio",
                            Peso = 10
                        },
                        new
                        {
                            CategoriaId = new Guid("d3d0d0a0-78ac-4145-b2d9-6de49e10867e"),
                            Descripcion = "Tareas relacionadas con los estudios",
                            Nombre = "Estudios",
                            Peso = 20
                        });
                });

            modelBuilder.Entity("proyectoef.Models.Tarea", b =>
                {
                    b.Property<Guid>("TareaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoriaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("PrioridadTarea")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("TareaId");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Tarea", (string)null);

                    b.HasData(
                        new
                        {
                            TareaId = new Guid("ae6f2420-78ac-4145-b2d9-6de49e108661"),
                            CategoriaId = new Guid("ae6f2420-78ac-4145-b2d9-6de49e10867e"),
                            Descripcion = "Realizar el back segun mokups en .Net y C#",
                            FechaCreacion = new DateTime(2023, 10, 12, 12, 41, 47, 275, DateTimeKind.Local).AddTicks(6156),
                            PrioridadTarea = 2,
                            Titulo = "Hacer le back en .Net"
                        },
                        new
                        {
                            TareaId = new Guid("ae6f2420-78ac-4145-b2d9-6de49e108662"),
                            CategoriaId = new Guid("ae6f2420-78ac-4145-b2d9-6de49e10867e"),
                            Descripcion = "Realizar el front segun mokups en Angular",
                            FechaCreacion = new DateTime(2023, 10, 12, 12, 41, 47, 275, DateTimeKind.Local).AddTicks(6172),
                            PrioridadTarea = 2,
                            Titulo = "Hacer le front en Angular"
                        },
                        new
                        {
                            TareaId = new Guid("ae6f2420-78ac-4145-b2d9-6de49e108663"),
                            CategoriaId = new Guid("b1b0b0a0-78ac-4145-b2d9-6de49e10867e"),
                            Descripcion = "Ordenar la cocina",
                            FechaCreacion = new DateTime(2023, 10, 12, 12, 41, 47, 275, DateTimeKind.Local).AddTicks(6175),
                            PrioridadTarea = 0,
                            Titulo = "Hacer le front en React"
                        },
                        new
                        {
                            TareaId = new Guid("ae6f2420-78ac-4145-b2d9-6de49e108664"),
                            CategoriaId = new Guid("c2c0c0a0-78ac-4145-b2d9-6de49e10867e"),
                            Descripcion = "Ordenar la pecera y alimentar a los peces",
                            FechaCreacion = new DateTime(2023, 10, 12, 12, 41, 47, 275, DateTimeKind.Local).AddTicks(6178),
                            PrioridadTarea = 1,
                            Titulo = "dar de comer a los peces"
                        },
                        new
                        {
                            TareaId = new Guid("ae6f2420-78ac-4145-b2d9-6de49e108665"),
                            CategoriaId = new Guid("c2c0c0a0-78ac-4145-b2d9-6de49e10867e"),
                            Descripcion = "Realizar el front segun mokups en Vue",
                            FechaCreacion = new DateTime(2023, 10, 12, 12, 41, 47, 275, DateTimeKind.Local).AddTicks(6180),
                            PrioridadTarea = 2,
                            Titulo = "Hacer le front en Vue"
                        });
                });

            modelBuilder.Entity("proyectoef.Models.Tarea", b =>
                {
                    b.HasOne("proyectoef.Models.Categoria", "Categoria")
                        .WithMany("Tareas")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("proyectoef.Models.Categoria", b =>
                {
                    b.Navigation("Tareas");
                });
#pragma warning restore 612, 618
        }
    }
}
