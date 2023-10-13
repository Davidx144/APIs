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
    [DbContext(typeof(APIContext))]
    partial class APIContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("proyectoef.Models.Category", b =>
                {
                    b.Property<Guid>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("StatusCategory")
                        .HasColumnType("int");

                    b.HasKey("CategoryId");

                    b.ToTable("Category", (string)null);

                    b.HasData(
                        new
                        {
                            CategoryId = new Guid("ae6f2420-78ac-4145-b2d9-6de49e108671"),
                            Descripcion = "Products of exp marketing center",
                            Name = "Products",
                            StatusCategory = 0
                        },
                        new
                        {
                            CategoryId = new Guid("b1b0b0a0-78ac-4145-b2d9-6de49e108672"),
                            Descripcion = "Designs of exp marketing center",
                            Name = "Designs",
                            StatusCategory = 0
                        },
                        new
                        {
                            CategoryId = new Guid("c2c0c0a0-78ac-4145-b2d9-6de49e108673"),
                            Descripcion = "Marketing of exp marketing center",
                            Name = "Marketing",
                            StatusCategory = 0
                        },
                        new
                        {
                            CategoryId = new Guid("c2c0c0a0-78ac-4145-b2d9-6de49e108674"),
                            Descripcion = "Intentions of exp marketing center",
                            Name = "Intentions",
                            StatusCategory = 1
                        });
                });

            modelBuilder.Entity("proyectoef.Models.Design", b =>
                {
                    b.Property<Guid>("DesignId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("ImageUrl")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("StatusDesign")
                        .HasColumnType("int");

                    b.HasKey("DesignId");

                    b.HasIndex("ProductId");

                    b.ToTable("Design", (string)null);

                    b.HasData(
                        new
                        {
                            DesignId = new Guid("ae6f2420-78ac-4145-b2d9-6de49e108678"),
                            CreationDate = new DateTime(2023, 10, 13, 13, 1, 16, 570, DateTimeKind.Local).AddTicks(3069),
                            Descripcion = "Provide a memorable takeaway with our collection of professionally-designed flyers.",
                            ImageUrl = "https://gmbb20.s3.amazonaws.com/Interior/Captura+de+pantalla+2023-09-26+111128.png",
                            Name = "Listing",
                            ProductId = new Guid("ae6f2420-78ac-4145-b2d9-6de49e108661"),
                            StatusDesign = 0
                        },
                        new
                        {
                            DesignId = new Guid("d6f8c9a2-4d5f-4a7c-9c3d-3e7f7e8d2a96"),
                            CreationDate = new DateTime(2023, 10, 13, 13, 1, 16, 570, DateTimeKind.Local).AddTicks(3089),
                            Descripcion = "Explore a variety of postcards designed for every occasion.",
                            ImageUrl = "https://gmbb20.s3.amazonaws.com/Interior/openhouse.jpg",
                            Name = "Open House",
                            ProductId = new Guid("ae6f2420-78ac-4145-b2d9-6de49e108661"),
                            StatusDesign = 0
                        });
                });

            modelBuilder.Entity("proyectoef.Models.Flyes", b =>
                {
                    b.Property<Guid>("FlyesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<Guid>("DesignId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ImageUrl")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("StatusFlyes")
                        .HasColumnType("int");

                    b.HasKey("FlyesId");

                    b.HasIndex("DesignId");

                    b.ToTable("Flyes", (string)null);

                    b.HasData(
                        new
                        {
                            FlyesId = new Guid("d6f869a2-4d5f-4a7c-9c3d-3e7f7e8d2a96"),
                            CreationDate = new DateTime(2023, 10, 13, 13, 1, 16, 570, DateTimeKind.Local).AddTicks(3883),
                            Descripcion = "Royal Blue 2 Sided Flyes",
                            DesignId = new Guid("ae6f2420-78ac-4145-b2d9-6de49e108678"),
                            ImageUrl = "https://gmbb20.s3.amazonaws.com/Interior/Captura+de+pantalla+2023-09-26+111128.png",
                            Name = "Royal",
                            StatusFlyes = 0
                        },
                        new
                        {
                            FlyesId = new Guid("d658c9a2-4d5f-4a7c-9c3d-3e7f7e8d2a96"),
                            CreationDate = new DateTime(2023, 10, 13, 13, 1, 16, 570, DateTimeKind.Local).AddTicks(3890),
                            Descripcion = "Nova Flyes",
                            DesignId = new Guid("ae6f2420-78ac-4145-b2d9-6de49e108678"),
                            ImageUrl = "https://gmbb20.s3.amazonaws.com/Interior/Captura+de+pantalla+2023-09-26+111128.png",
                            Name = "Nova",
                            StatusFlyes = 0
                        },
                        new
                        {
                            FlyesId = new Guid("d1f8c9a2-4d5f-4a7c-9c3d-3e7f7e8d2a96"),
                            CreationDate = new DateTime(2023, 10, 13, 13, 1, 16, 570, DateTimeKind.Local).AddTicks(3897),
                            Descripcion = "Suave Flyes",
                            DesignId = new Guid("ae6f2420-78ac-4145-b2d9-6de49e108678"),
                            ImageUrl = "https://gmbb20.s3.amazonaws.com/Interior/Captura+de+pantalla+2023-09-26+111128.png",
                            Name = "Suave",
                            StatusFlyes = 0
                        });
                });

            modelBuilder.Entity("proyectoef.Models.Products", b =>
                {
                    b.Property<Guid>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("ImageUrl")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("StatusProduct")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products", (string)null);

                    b.HasData(
                        new
                        {
                            ProductId = new Guid("ae6f2420-78ac-4145-b2d9-6de49e108661"),
                            CategoryId = new Guid("ae6f2420-78ac-4145-b2d9-6de49e108671"),
                            CreationDate = new DateTime(2023, 10, 13, 13, 1, 16, 569, DateTimeKind.Local).AddTicks(8845),
                            Descripcion = "Provide a memorable takeaway with our collection of professionally-designed flyers.",
                            ImageUrl = "https://gmbb20.s3.amazonaws.com/home/crop_crop_Flyer_650x650.png",
                            Name = "Flyers",
                            StatusProduct = 0
                        },
                        new
                        {
                            ProductId = new Guid("d6f8c9a2-4d5f-4a7c-9c3d-3e7f7e8d2a1a"),
                            CategoryId = new Guid("ae6f2420-78ac-4145-b2d9-6de49e108671"),
                            CreationDate = new DateTime(2023, 10, 13, 13, 1, 16, 569, DateTimeKind.Local).AddTicks(8866),
                            Descripcion = "Explore a variety of postcards designed for every occasion.",
                            ImageUrl = "https://gmbb20.s3.amazonaws.com/home/crop_crop_Postcard_650x650_1.png",
                            Name = "PostCards",
                            StatusProduct = 0
                        },
                        new
                        {
                            ProductId = new Guid("b6f8c9a2-4d5f-4a7c-9c3d-3e7f7e8d2a1a"),
                            CategoryId = new Guid("ae6f2420-78ac-4145-b2d9-6de49e108671"),
                            CreationDate = new DateTime(2023, 10, 13, 13, 1, 16, 569, DateTimeKind.Local).AddTicks(8870),
                            Descripcion = "Advertise your listing with our luxury 8-page booklets and classic brochures.",
                            ImageUrl = "https://gmbb20.s3.amazonaws.com/home/crop_crop_Brochure_650x650_1.png",
                            Name = "Brochures",
                            StatusProduct = 0
                        },
                        new
                        {
                            ProductId = new Guid("a6f8c9a2-4d5f-4a7c-9c3d-3e7f7e8d2a1a"),
                            CategoryId = new Guid("ae6f2420-78ac-4145-b2d9-6de49e108671"),
                            CreationDate = new DateTime(2023, 10, 13, 13, 1, 16, 569, DateTimeKind.Local).AddTicks(8874),
                            Descripcion = "Engage with your audience by using our ready-to-share social media items.",
                            ImageUrl = "https://gmbb20.s3.amazonaws.com/home/crop_crop_Social_Media_650x650.png",
                            Name = "Social Media",
                            StatusProduct = 0
                        },
                        new
                        {
                            ProductId = new Guid("96f8c9a2-4d5f-4a7c-9c3d-3e7f7e8d2a1a"),
                            CategoryId = new Guid("ae6f2420-78ac-4145-b2d9-6de49e108671"),
                            CreationDate = new DateTime(2023, 10, 13, 13, 1, 16, 569, DateTimeKind.Local).AddTicks(8878),
                            Descripcion = "Walled Garden integration to automate and easily launch Facebook ads.",
                            ImageUrl = "https://gmbb20.s3.amazonaws.com/home/crop_thumb-ref3.png",
                            Name = "FaceBook Ads",
                            StatusProduct = 0
                        },
                        new
                        {
                            ProductId = new Guid("86f8c9a2-4d5f-4a7c-9c3d-3e7f7e8d2a1a"),
                            CategoryId = new Guid("ae6f2420-78ac-4145-b2d9-6de49e108671"),
                            CreationDate = new DateTime(2023, 10, 13, 13, 1, 16, 569, DateTimeKind.Local).AddTicks(8885),
                            Descripcion = "Level up your marketing using single property sites.",
                            ImageUrl = "https://gmbb20.s3.amazonaws.com/home/crop_crop_Laptop_650x650.png",
                            Name = "Single Property Sites",
                            StatusProduct = 0
                        },
                        new
                        {
                            ProductId = new Guid("76f8c9a2-4d5f-4a7c-9c3d-3e7f7e8d2a1a"),
                            CategoryId = new Guid("ae6f2420-78ac-4145-b2d9-6de49e108671"),
                            CreationDate = new DateTime(2023, 10, 13, 13, 1, 16, 569, DateTimeKind.Local).AddTicks(8887),
                            Descripcion = "Attract attention to your listings, open house, or yourself with a customizable door hanger.",
                            ImageUrl = "https://gmbb20.s3.amazonaws.com/home/crop_crop_Doorhanger_650x650.png",
                            Name = "Door Hangers",
                            StatusProduct = 0
                        },
                        new
                        {
                            ProductId = new Guid("66f8c9a2-4d5f-4a7c-9c3d-3e7f7e8d2a1a"),
                            CategoryId = new Guid("ae6f2420-78ac-4145-b2d9-6de49e108671"),
                            CreationDate = new DateTime(2023, 10, 13, 13, 1, 16, 569, DateTimeKind.Local).AddTicks(8892),
                            Descripcion = "Make an impression on your clients with our elegant presentations.",
                            ImageUrl = "https://gmbb20.s3.amazonaws.com/home/crop_crop_Presentation_650x650.png",
                            Name = "Presentations",
                            StatusProduct = 0
                        },
                        new
                        {
                            ProductId = new Guid("56f8c9a2-4d5f-4a7c-9c3d-3e7f7e8d2a1a"),
                            CategoryId = new Guid("ae6f2420-78ac-4145-b2d9-6de49e108671"),
                            CreationDate = new DateTime(2023, 10, 13, 13, 1, 16, 569, DateTimeKind.Local).AddTicks(8898),
                            Descripcion = "Educate your sphere about the real estate industry with our informative videos.",
                            ImageUrl = "https://gmbb20.s3.amazonaws.com/home/crop_crop_Video_Mockup_650x650.png",
                            Name = "Videos",
                            StatusProduct = 0
                        },
                        new
                        {
                            ProductId = new Guid("46f8c9a2-4d5f-4a7c-9c3d-3e7f7e8d2a1a"),
                            CategoryId = new Guid("ae6f2420-78ac-4145-b2d9-6de49e108671"),
                            CreationDate = new DateTime(2023, 10, 13, 13, 1, 16, 569, DateTimeKind.Local).AddTicks(8907),
                            Descripcion = "Connect with past and future clients with pre-written letters and customizable letterheads.",
                            ImageUrl = "https://gmbb20.s3.amazonaws.com/home/crop_crop_Letter_650x650.png",
                            Name = "Letter/LetterHeads",
                            StatusProduct = 0
                        },
                        new
                        {
                            ProductId = new Guid("36f8c9a2-4d5f-4a7c-9c3d-3e7f7e8d2a1a"),
                            CategoryId = new Guid("ae6f2420-78ac-4145-b2d9-6de49e108671"),
                            CreationDate = new DateTime(2023, 10, 13, 13, 1, 16, 569, DateTimeKind.Local).AddTicks(8912),
                            Descripcion = "Cover your bases with the help of these branded documents.",
                            ImageUrl = "https://gmbb20.s3.amazonaws.com/home/crop_crop_Helpful_Docs_650x650.png",
                            Name = "Helpful Documents",
                            StatusProduct = 0
                        },
                        new
                        {
                            ProductId = new Guid("26f8c9a2-4d5f-4a7c-9c3d-3e7f7e8d2a1a"),
                            CategoryId = new Guid("ae6f2420-78ac-4145-b2d9-6de49e108671"),
                            CreationDate = new DateTime(2023, 10, 13, 13, 1, 16, 569, DateTimeKind.Local).AddTicks(8914),
                            Descripcion = "Create a first and lasting impression by using one of a variety of branded business cards.",
                            ImageUrl = "https://gmbb20.s3.amazonaws.com/home/crop_crop_Business_Card_650x650.png",
                            Name = "Business Cards",
                            StatusProduct = 0
                        },
                        new
                        {
                            ProductId = new Guid("16f8c9a2-4d5f-4a7c-9c3d-3e7f7e8d2a1a"),
                            CategoryId = new Guid("ae6f2420-78ac-4145-b2d9-6de49e108671"),
                            CreationDate = new DateTime(2023, 10, 13, 13, 1, 16, 569, DateTimeKind.Local).AddTicks(8919),
                            Descripcion = "Keep your communications branded with the information your contacts need.",
                            ImageUrl = "https://gmbb20.s3.amazonaws.com/home/crop_crop_Email_Signature_650x650.png",
                            Name = "Email Signatures",
                            StatusProduct = 0
                        },
                        new
                        {
                            ProductId = new Guid("06f8c9a2-4d5f-4a7c-9c3d-3e7f7e8d2a1a"),
                            CategoryId = new Guid("ae6f2420-78ac-4145-b2d9-6de49e108671"),
                            CreationDate = new DateTime(2023, 10, 13, 13, 1, 16, 569, DateTimeKind.Local).AddTicks(8922),
                            Descripcion = "Keep your sphere informed and updated with industry insights and other helpful topics.",
                            ImageUrl = "https://gmbb20.s3.amazonaws.com/home/crop_crop_Newsletter_650x650.png",
                            Name = "NewsLetters",
                            StatusProduct = 0
                        },
                        new
                        {
                            ProductId = new Guid("f6f8c9a2-4d5f-4a7c-9c3d-3e7f7e8d2a1a"),
                            CategoryId = new Guid("ae6f2420-78ac-4145-b2d9-6de49e108671"),
                            CreationDate = new DateTime(2023, 10, 13, 13, 1, 16, 569, DateTimeKind.Local).AddTicks(8925),
                            Descripcion = "Appeal to Spanish-speaking audiences with our variety of Spanish marketing items.",
                            ImageUrl = "https://gmbb20.s3.amazonaws.com/home/crop_crop_Spanish_Marketing_650x650.png",
                            Name = "Spanish Materials",
                            StatusProduct = 0
                        },
                        new
                        {
                            ProductId = new Guid("e6f8c9a2-4d5f-4a7c-9c3d-3e7f7e8d2a1a"),
                            CategoryId = new Guid("ae6f2420-78ac-4145-b2d9-6de49e108671"),
                            CreationDate = new DateTime(2023, 10, 13, 13, 1, 16, 569, DateTimeKind.Local).AddTicks(8927),
                            Descripcion = "Download partner resources to provide your clients with valuable information.",
                            ImageUrl = "https://gmbb20.s3.amazonaws.com/home/crop_eXp_Solutions_650x650.png",
                            Name = "eXp Solutions",
                            StatusProduct = 0
                        });
                });

            modelBuilder.Entity("proyectoef.Models.Design", b =>
                {
                    b.HasOne("proyectoef.Models.Products", "Product")
                        .WithMany("Designs")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("proyectoef.Models.Flyes", b =>
                {
                    b.HasOne("proyectoef.Models.Design", "Design")
                        .WithMany("Flyes")
                        .HasForeignKey("DesignId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Design");
                });

            modelBuilder.Entity("proyectoef.Models.Products", b =>
                {
                    b.HasOne("proyectoef.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("proyectoef.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("proyectoef.Models.Design", b =>
                {
                    b.Navigation("Flyes");
                });

            modelBuilder.Entity("proyectoef.Models.Products", b =>
                {
                    b.Navigation("Designs");
                });
#pragma warning restore 612, 618
        }
    }
}
