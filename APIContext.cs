using Microsoft.EntityFrameworkCore;
using proyectoef.Models;

namespace proyectoef;

public class APIContext : DbContext
{
    //cada una de estas colecciones representa una tabla en la base de datos
    public DbSet<Category> Categories { get; set; }
    public DbSet<Products> Products { get; set; }
    public DbSet<Design> Designs { get; set; }
    public DbSet<Flyes> Flyes { get; set; }

    //esto es para que se pueda inyectar el contexto en el controlador
    public APIContext(DbContextOptions<APIContext> options) : base(options) { }

    //Aqui se configura el modelo de datos
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //esto es para que se cree la base de datos con los datos de prueba

        List<Category> categoriesInit = new List<Category>();
        categoriesInit.Add(new Category { CategoryId = Guid.Parse("ae6f2420-78ac-4145-b2d9-6de49e108671"), Name = "Products", Descripcion = "Products of exp marketing center", StatusCategory = Status.Active });
        categoriesInit.Add(new Category { CategoryId = Guid.Parse("b1b0b0a0-78ac-4145-b2d9-6de49e108672"), Name = "Designs", Descripcion = "Designs of exp marketing center", StatusCategory = Status.Active });
        categoriesInit.Add(new Category { CategoryId = Guid.Parse("c2c0c0a0-78ac-4145-b2d9-6de49e108673"), Name = "Marketing", Descripcion = "Marketing of exp marketing center", StatusCategory = Status.Active });
        categoriesInit.Add(new Category { CategoryId = Guid.Parse("c2c0c0a0-78ac-4145-b2d9-6de49e108674"), Name = "Intentions", Descripcion = "Intentions of exp marketing center", StatusCategory = Status.Inactive });

        modelBuilder.Entity<Category>(category =>
        {
            category.ToTable("Category");
            category.HasKey(c => c.CategoryId);
            category.Property(c => c.Name).HasMaxLength(200).IsRequired();
            category.Property(c => c.Descripcion).HasMaxLength(500).IsRequired(false);
            category.Property(c => c.StatusCategory);
            category.HasData(categoriesInit);
        });

        List<Products> productsInit = new List<Products>();
        productsInit.Add(new Products { ProductId = Guid.Parse("ae6f2420-78ac-4145-b2d9-6de49e108661"), CategoryId = Guid.Parse("ae6f2420-78ac-4145-b2d9-6de49e108671"), Name = "Flyers", Descripcion = "Provide a memorable takeaway with our collection of professionally-designed flyers.", CreationDate = DateTime.Now ,StatusProduct = Status.Active, ImageUrl = "https://gmbb20.s3.amazonaws.com/home/crop_crop_Flyer_650x650.png" });
        productsInit.Add(new Products { ProductId = Guid.Parse("d6f8c9a2-4d5f-4a7c-9c3d-3e7f7e8d2a1a"), CategoryId = Guid.Parse("ae6f2420-78ac-4145-b2d9-6de49e108671"), Name = "PostCards", Descripcion = "Explore a variety of postcards designed for every occasion.", CreationDate = DateTime.Now , StatusProduct = Status.Active, ImageUrl = "https://gmbb20.s3.amazonaws.com/home/crop_crop_Postcard_650x650_1.png" });
        productsInit.Add(new Products { ProductId = Guid.Parse("b6f8c9a2-4d5f-4a7c-9c3d-3e7f7e8d2a1a"), CategoryId = Guid.Parse("ae6f2420-78ac-4145-b2d9-6de49e108671"), Name = "Brochures", Descripcion = "Advertise your listing with our luxury 8-page booklets and classic brochures.", CreationDate = DateTime.Now , StatusProduct = Status.Active, ImageUrl = "https://gmbb20.s3.amazonaws.com/home/crop_crop_Brochure_650x650_1.png" });
        productsInit.Add(new Products { ProductId = Guid.Parse("a6f8c9a2-4d5f-4a7c-9c3d-3e7f7e8d2a1a"), CategoryId = Guid.Parse("ae6f2420-78ac-4145-b2d9-6de49e108671"), Name = "Social Media", Descripcion = "Engage with your audience by using our ready-to-share social media items.", CreationDate = DateTime.Now , StatusProduct = Status.Active, ImageUrl = "https://gmbb20.s3.amazonaws.com/home/crop_crop_Social_Media_650x650.png" });
        productsInit.Add(new Products { ProductId = Guid.Parse("96f8c9a2-4d5f-4a7c-9c3d-3e7f7e8d2a1a"), CategoryId = Guid.Parse("ae6f2420-78ac-4145-b2d9-6de49e108671"), Name = "FaceBook Ads", Descripcion = "Walled Garden integration to automate and easily launch Facebook ads.", CreationDate = DateTime.Now , StatusProduct = Status.Active, ImageUrl = "https://gmbb20.s3.amazonaws.com/home/crop_thumb-ref3.png" });
        productsInit.Add(new Products { ProductId = Guid.Parse("86f8c9a2-4d5f-4a7c-9c3d-3e7f7e8d2a1a"), CategoryId = Guid.Parse("ae6f2420-78ac-4145-b2d9-6de49e108671"), Name = "Single Property Sites", Descripcion = "Level up your marketing using single property sites.", CreationDate = DateTime.Now , StatusProduct = Status.Active, ImageUrl = "https://gmbb20.s3.amazonaws.com/home/crop_crop_Laptop_650x650.png" });
        productsInit.Add(new Products { ProductId = Guid.Parse("76f8c9a2-4d5f-4a7c-9c3d-3e7f7e8d2a1a"), CategoryId = Guid.Parse("ae6f2420-78ac-4145-b2d9-6de49e108671"), Name = "Door Hangers", Descripcion = "Attract attention to your listings, open house, or yourself with a customizable door hanger.", CreationDate = DateTime.Now, StatusProduct = Status.Active, ImageUrl = "https://gmbb20.s3.amazonaws.com/home/crop_crop_Doorhanger_650x650.png" });
        productsInit.Add(new Products { ProductId = Guid.Parse("66f8c9a2-4d5f-4a7c-9c3d-3e7f7e8d2a1a"), CategoryId = Guid.Parse("ae6f2420-78ac-4145-b2d9-6de49e108671"), Name = "Presentations", Descripcion = "Make an impression on your clients with our elegant presentations.", CreationDate = DateTime.Now, StatusProduct = Status.Active, ImageUrl = "https://gmbb20.s3.amazonaws.com/home/crop_crop_Presentation_650x650.png" });
        productsInit.Add(new Products { ProductId = Guid.Parse("56f8c9a2-4d5f-4a7c-9c3d-3e7f7e8d2a1a"), CategoryId = Guid.Parse("ae6f2420-78ac-4145-b2d9-6de49e108671"), Name = "Videos", Descripcion = "Educate your sphere about the real estate industry with our informative videos.", CreationDate = DateTime.Now, StatusProduct = Status.Active, ImageUrl = "https://gmbb20.s3.amazonaws.com/home/crop_crop_Video_Mockup_650x650.png" });
        productsInit.Add(new Products { ProductId = Guid.Parse("46f8c9a2-4d5f-4a7c-9c3d-3e7f7e8d2a1a"), CategoryId = Guid.Parse("ae6f2420-78ac-4145-b2d9-6de49e108671"), Name = "Letter/LetterHeads", Descripcion = "Connect with past and future clients with pre-written letters and customizable letterheads.", CreationDate = DateTime.Now, StatusProduct = Status.Active, ImageUrl = "https://gmbb20.s3.amazonaws.com/home/crop_crop_Letter_650x650.png" });
        productsInit.Add(new Products { ProductId = Guid.Parse("36f8c9a2-4d5f-4a7c-9c3d-3e7f7e8d2a1a"), CategoryId = Guid.Parse("ae6f2420-78ac-4145-b2d9-6de49e108671"), Name = "Helpful Documents", Descripcion = "Cover your bases with the help of these branded documents.", CreationDate = DateTime.Now, StatusProduct = Status.Active, ImageUrl = "https://gmbb20.s3.amazonaws.com/home/crop_crop_Helpful_Docs_650x650.png" });
        productsInit.Add(new Products { ProductId = Guid.Parse("26f8c9a2-4d5f-4a7c-9c3d-3e7f7e8d2a1a"), CategoryId = Guid.Parse("ae6f2420-78ac-4145-b2d9-6de49e108671"), Name = "Business Cards", Descripcion = "Create a first and lasting impression by using one of a variety of branded business cards.", CreationDate = DateTime.Now, StatusProduct = Status.Active, ImageUrl = "https://gmbb20.s3.amazonaws.com/home/crop_crop_Business_Card_650x650.png" });
        productsInit.Add(new Products { ProductId = Guid.Parse("16f8c9a2-4d5f-4a7c-9c3d-3e7f7e8d2a1a"), CategoryId = Guid.Parse("ae6f2420-78ac-4145-b2d9-6de49e108671"), Name = "Email Signatures", Descripcion = "Keep your communications branded with the information your contacts need.", CreationDate = DateTime.Now, StatusProduct = Status.Active, ImageUrl = "https://gmbb20.s3.amazonaws.com/home/crop_crop_Email_Signature_650x650.png" });
        productsInit.Add(new Products { ProductId = Guid.Parse("06f8c9a2-4d5f-4a7c-9c3d-3e7f7e8d2a1a"), CategoryId = Guid.Parse("ae6f2420-78ac-4145-b2d9-6de49e108671"), Name = "NewsLetters", Descripcion = "Keep your sphere informed and updated with industry insights and other helpful topics.", CreationDate = DateTime.Now, StatusProduct = Status.Active, ImageUrl = "https://gmbb20.s3.amazonaws.com/home/crop_crop_Newsletter_650x650.png" });
        productsInit.Add(new Products { ProductId = Guid.Parse("f6f8c9a2-4d5f-4a7c-9c3d-3e7f7e8d2a1a"), CategoryId = Guid.Parse("ae6f2420-78ac-4145-b2d9-6de49e108671"), Name = "Spanish Materials", Descripcion = "Appeal to Spanish-speaking audiences with our variety of Spanish marketing items.", CreationDate = DateTime.Now, StatusProduct = Status.Active, ImageUrl = "https://gmbb20.s3.amazonaws.com/home/crop_crop_Spanish_Marketing_650x650.png" });
        productsInit.Add(new Products { ProductId = Guid.Parse("e6f8c9a2-4d5f-4a7c-9c3d-3e7f7e8d2a1a"), CategoryId = Guid.Parse("ae6f2420-78ac-4145-b2d9-6de49e108671"), Name = "eXp Solutions", Descripcion = "Download partner resources to provide your clients with valuable information.", CreationDate = DateTime.Now, StatusProduct = Status.Active, ImageUrl = "https://gmbb20.s3.amazonaws.com/home/crop_eXp_Solutions_650x650.png" });

        
        modelBuilder.Entity<Products>(product =>
        {
            product.ToTable("Products");
            product.HasKey(p => p.ProductId);
            product.HasOne(p => p.Category).WithMany(p => p.Products).HasForeignKey(p => p.CategoryId);
            product.Property(p => p.Name).HasMaxLength(200).IsRequired();
            product.Property(p => p.Descripcion).HasMaxLength(500).IsRequired(false);
            product.Property(p => p.ImageUrl).HasMaxLength(500).IsRequired(false);
            product.Property(p => p.StatusProduct);
            product.Property(p => p.CreationDate);
            product.HasData(productsInit);
        });

        List<Design> designsInit = new List<Design>();
        designsInit.Add(new Design { DesignId = Guid.Parse("ae6f2420-78ac-4145-b2d9-6de49e108678"), ProductId = Guid.Parse("ae6f2420-78ac-4145-b2d9-6de49e108661"), Name = "Listing", Descripcion = "Provide a memorable takeaway with our collection of professionally-designed flyers.", StatusDesign = Status.Active, CreationDate = DateTime.Now, ImageUrl = "https://gmbb20.s3.amazonaws.com/Interior/Captura+de+pantalla+2023-09-26+111128.png" });
        designsInit.Add(new Design { DesignId = Guid.Parse("d6f8c9a2-4d5f-4a7c-9c3d-3e7f7e8d2a96"), ProductId = Guid.Parse("ae6f2420-78ac-4145-b2d9-6de49e108661"), Name = "Open House", Descripcion = "Explore a variety of postcards designed for every occasion.", StatusDesign = Status.Active, CreationDate = DateTime.Now, ImageUrl = "https://gmbb20.s3.amazonaws.com/Interior/openhouse.jpg" });

        modelBuilder.Entity<Design>(design =>
        {
            design.ToTable("Design");
            design.HasKey(d => d.DesignId);
            design.HasOne(d => d.Product).WithMany(d => d.Designs).HasForeignKey(d => d.ProductId);
            design.Property(d => d.Name).HasMaxLength(200).IsRequired();
            design.Property(d => d.Descripcion).HasMaxLength(500).IsRequired(false);
            design.Property(d => d.ImageUrl).HasMaxLength(500).IsRequired(false);
            design.Property(d => d.StatusDesign);
            design.Property(d => d.CreationDate);
            design.HasData(designsInit);
        });

        List<Flyes> flyesInit = new List<Flyes>();
        flyesInit.Add(new Flyes { FlyesId = Guid.Parse("d6f869a2-4d5f-4a7c-9c3d-3e7f7e8d2a96"), DesignId = Guid.Parse("ae6f2420-78ac-4145-b2d9-6de49e108678"), Name = "Royal", Descripcion = "Royal Blue 2 Sided Flyes", StatusFlyes = Status.Active, CreationDate = DateTime.Now, ImageUrl = "https://gmbb20.s3.amazonaws.com/Interior/Captura+de+pantalla+2023-09-26+111128.png" });
        flyesInit.Add(new Flyes { FlyesId = Guid.Parse("d658c9a2-4d5f-4a7c-9c3d-3e7f7e8d2a96"), DesignId = Guid.Parse("ae6f2420-78ac-4145-b2d9-6de49e108678"), Name = "Nova", Descripcion = "Nova Flyes", StatusFlyes = Status.Active, CreationDate = DateTime.Now, ImageUrl = "https://gmbb20.s3.amazonaws.com/Interior/Captura+de+pantalla+2023-09-26+111128.png" });
        flyesInit.Add(new Flyes { FlyesId = Guid.Parse("d1f8c9a2-4d5f-4a7c-9c3d-3e7f7e8d2a96"), DesignId = Guid.Parse("ae6f2420-78ac-4145-b2d9-6de49e108678"), Name = "Suave", Descripcion = "Suave Flyes", StatusFlyes = Status.Active, CreationDate = DateTime.Now, ImageUrl = "https://gmbb20.s3.amazonaws.com/Interior/Captura+de+pantalla+2023-09-26+111128.png" });

        modelBuilder.Entity<Flyes>(flyes =>
        {
            flyes.ToTable("Flyes");
            flyes.HasKey(f => f.FlyesId);
            flyes.HasOne(f => f.Design).WithMany(f => f.Flyes).HasForeignKey(f => f.DesignId);
            flyes.Property(f => f.Name).HasMaxLength(200).IsRequired();
            flyes.Property(f => f.Descripcion).HasMaxLength(500).IsRequired(false);
            flyes.Property(f => f.ImageUrl).HasMaxLength(500).IsRequired(false);
            flyes.Property(f => f.StatusFlyes);
            flyes.Property(f => f.CreationDate);
            flyes.HasData(flyesInit);
        });
    }
}