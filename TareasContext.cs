using Microsoft.EntityFrameworkCore;
using proyectoef.Models;

namespace proyectoef;

public class APIContext : DbContext
{
    //cada una de estas colecciones representa una tabla en la base de datos
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Tarea> Tareas { get; set; }
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
        List<Categoria> categoriasInit = new List<Categoria>();
        categoriasInit.Add(new Categoria { CategoriaId = Guid.Parse("ae6f2420-78ac-4145-b2d9-6de49e10867e"), Nombre = "Trabajo", Descripcion = "Tareas relacionadas con el trabajo", Peso = 60 });
        categoriasInit.Add(new Categoria { CategoriaId = Guid.Parse("b1b0b0a0-78ac-4145-b2d9-6de49e10867e"), Nombre = "Personal", Descripcion = "Tareas personales", Peso = 30 });
        categoriasInit.Add(new Categoria { CategoriaId = Guid.Parse("c2c0c0a0-78ac-4145-b2d9-6de49e10867e"), Nombre = "Ocio", Descripcion = "Tareas de ocio", Peso = 10 });
        categoriasInit.Add(new Categoria { CategoriaId = Guid.Parse("d3d0d0a0-78ac-4145-b2d9-6de49e10867e"), Nombre = "Estudios", Descripcion = "Tareas relacionadas con los estudios", Peso = 20 });

        modelBuilder.Entity<Categoria>(categoria =>
        {
            categoria.ToTable("Categoria");
            categoria.HasKey(c => c.CategoriaId);
            categoria.Property(c => c.Nombre).HasMaxLength(200).IsRequired();
            categoria.Property(c => c.Descripcion).HasMaxLength(500).IsRequired(false);
            categoria.Property(c => c.Peso);
            categoria.HasData(categoriasInit);
        });


        List<Tarea> tareasInit = new List<Tarea>();
        tareasInit.Add(new Tarea { TareaId = Guid.Parse("ae6f2420-78ac-4145-b2d9-6de49e108661"), CategoriaId = Guid.Parse("ae6f2420-78ac-4145-b2d9-6de49e10867e"), Titulo = "Hacer le back en .Net", Descripcion = "Realizar el back segun mokups en .Net y C#", PrioridadTarea = Prioridad.Alta, FechaCreacion = DateTime.Now });
        tareasInit.Add(new Tarea { TareaId = Guid.Parse("ae6f2420-78ac-4145-b2d9-6de49e108662"), CategoriaId = Guid.Parse("ae6f2420-78ac-4145-b2d9-6de49e10867e"), Titulo = "Hacer le front en Angular", Descripcion = "Realizar el front segun mokups en Angular", PrioridadTarea = Prioridad.Alta, FechaCreacion = DateTime.Now });
        tareasInit.Add(new Tarea { TareaId = Guid.Parse("ae6f2420-78ac-4145-b2d9-6de49e108663"), CategoriaId = Guid.Parse("b1b0b0a0-78ac-4145-b2d9-6de49e10867e"), Titulo = "Hacer le front en React", Descripcion = "Ordenar la cocina", PrioridadTarea = Prioridad.Baja, FechaCreacion = DateTime.Now });
        tareasInit.Add(new Tarea { TareaId = Guid.Parse("ae6f2420-78ac-4145-b2d9-6de49e108664"), CategoriaId = Guid.Parse("c2c0c0a0-78ac-4145-b2d9-6de49e10867e"), Titulo = "dar de comer a los peces", Descripcion = "Ordenar la pecera y alimentar a los peces", PrioridadTarea = Prioridad.Media, FechaCreacion = DateTime.Now });
        tareasInit.Add(new Tarea { TareaId = Guid.Parse("ae6f2420-78ac-4145-b2d9-6de49e108665"), CategoriaId = Guid.Parse("c2c0c0a0-78ac-4145-b2d9-6de49e10867e"), Titulo = "Hacer le front en Vue", Descripcion = "Realizar el front segun mokups en Vue", PrioridadTarea = Prioridad.Alta, FechaCreacion = DateTime.Now });

        modelBuilder.Entity<Tarea>(tarea =>
        {
            tarea.ToTable("Tarea");
            tarea.HasKey(t => t.TareaId);
            tarea.HasOne(p => p.Categoria).WithMany(p => p.Tareas).HasForeignKey(p => p.CategoriaId);
            tarea.Property(t => t.Titulo).HasMaxLength(200).IsRequired();
            tarea.Property(t => t.Descripcion).HasMaxLength(500).IsRequired(false);
            tarea.Property(t => t.PrioridadTarea);
            tarea.Property(t => t.FechaCreacion);
            tarea.Ignore(t => t.Resumen);
            tarea.HasData(tareasInit);
        });

        List<Category> categoriesInit = new List<Category>();
        categoriesInit.Add(new Category { CategoryId = Guid.Parse("ae6f2420-78ac-4145-b2d9-6de49e10867e"), Name = "Products", Descripcion = "Products of exp marketing center", StatusCategory = Status.Active });
        categoriesInit.Add(new Category { CategoryId = Guid.Parse("b1b0b0a0-78ac-4145-b2d9-6de49e10867e"), Name = "Designs", Descripcion = "Designs of exp marketing center", StatusCategory = Status.Active });
        categoriesInit.Add(new Category { CategoryId = Guid.Parse("c2c0c0a0-78ac-4145-b2d9-6de49e10867e"), Name = "Marketing", Descripcion = "Marketing of exp marketing center", StatusCategory = Status.Active });
        categoriesInit.Add(new Category { CategoryId = Guid.Parse("c2c0c0a0-78ac-4145-b2d9-6de49e10867e"), Name = "Intentions", Descripcion = "Intentions of exp marketing center", StatusCategory = Status.Inactive });

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
        productsInit.Add(new Products { ProductId = Guid.Parse("ae6f2420-78ac-4145-b2d9-6de49e108661"), CategoryId = Guid.Parse("ae6f2420-78ac-4145-b2d9-6de49e10867e"), Name = "Flyers", Descripcion = "Provide a memorable takeaway with our collection of professionally-designed flyers.", CreationDate = DateTime.Now ,StatusProduct = Status.Active, ImageUrl = "https://gmbb20.s3.amazonaws.com/home/crop_crop_Flyer_650x650.png" });
        productsInit.Add(new Products { ProductId = Guid.Parse("d6f8c9a2-4d5f-4a7c-9c3d-3e7f7e8d2a1a"), CategoryId = Guid.Parse("ae6f2420-78ac-4145-b2d9-6de49e10867e"), Name = "PostCards", Descripcion = "Explore a variety of postcards designed for every occasion.", CreationDate = DateTime.Now , StatusProduct = Status.Active, ImageUrl = "https://gmbb20.s3.amazonaws.com/home/crop_crop_Postcard_650x650_1.png" });
        productsInit.Add(new Products { ProductId = Guid.Parse("b6f8c9a2-4d5f-4a7c-9c3d-3e7f7e8d2a1a"), CategoryId = Guid.Parse("ae6f2420-78ac-4145-b2d9-6de49e10867e"), Name = "Brochures", Descripcion = "Advertise your listing with our luxury 8-page booklets and classic brochures.", CreationDate = DateTime.Now , StatusProduct = Status.Active, ImageUrl = "https://gmbb20.s3.amazonaws.com/home/crop_crop_Brochure_650x650_1.png" });
        productsInit.Add(new Products { ProductId = Guid.Parse("a6f8c9a2-4d5f-4a7c-9c3d-3e7f7e8d2a1a"), CategoryId = Guid.Parse("ae6f2420-78ac-4145-b2d9-6de49e10867e"), Name = "Social Media", Descripcion = "Engage with your audience by using our ready-to-share social media items.", CreationDate = DateTime.Now , StatusProduct = Status.Active, ImageUrl = "https://gmbb20.s3.amazonaws.com/home/crop_crop_Social_Media_650x650.png" });
        productsInit.Add(new Products { ProductId = Guid.Parse("96f8c9a2-4d5f-4a7c-9c3d-3e7f7e8d2a1a"), CategoryId = Guid.Parse("ae6f2420-78ac-4145-b2d9-6de49e10867e"), Name = "FaceBook Ads", Descripcion = "Walled Garden integration to automate and easily launch Facebook ads.", CreationDate = DateTime.Now , StatusProduct = Status.Active, ImageUrl = "https://gmbb20.s3.amazonaws.com/home/crop_thumb-ref3.png" });
        productsInit.Add(new Products { ProductId = Guid.Parse("86f8c9a2-4d5f-4a7c-9c3d-3e7f7e8d2a1a"), CategoryId = Guid.Parse("ae6f2420-78ac-4145-b2d9-6de49e10867e"), Name = "Single Property Sites", Descripcion = "Level up your marketing using single property sites.", CreationDate = DateTime.Now , StatusProduct = Status.Active, ImageUrl = "https://gmbb20.s3.amazonaws.com/home/crop_crop_Laptop_650x650.png" });
        productsInit.Add(new Products { ProductId = Guid.Parse("76f8c9a2-4d5f-4a7c-9c3d-3e7f7e8d2a1a"), CategoryId = Guid.Parse("ae6f2420-78ac-4145-b2d9-6de49e10867e"), Name = "Door Hangers", Descripcion = "Attract attention to your listings, open house, or yourself with a customizable door hanger.", CreationDate = DateTime.Now, StatusProduct = Status.Active, ImageUrl = "https://gmbb20.s3.amazonaws.com/home/crop_crop_Doorhanger_650x650.png" });
        productsInit.Add(new Products { ProductId = Guid.Parse("66f8c9a2-4d5f-4a7c-9c3d-3e7f7e8d2a1a"), CategoryId = Guid.Parse("ae6f2420-78ac-4145-b2d9-6de49e10867e"), Name = "Presentations", Descripcion = "Make an impression on your clients with our elegant presentations.", CreationDate = DateTime.Now, StatusProduct = Status.Active, ImageUrl = "https://gmbb20.s3.amazonaws.com/home/crop_crop_Presentation_650x650.png" });
        productsInit.Add(new Products { ProductId = Guid.Parse("56f8c9a2-4d5f-4a7c-9c3d-3e7f7e8d2a1a"), CategoryId = Guid.Parse("ae6f2420-78ac-4145-b2d9-6de49e10867e"), Name = "Videos", Descripcion = "Educate your sphere about the real estate industry with our informative videos.", CreationDate = DateTime.Now, StatusProduct = Status.Active, ImageUrl = "https://gmbb20.s3.amazonaws.com/home/crop_crop_Video_Mockup_650x650.png" });
        productsInit.Add(new Products { ProductId = Guid.Parse("46f8c9a2-4d5f-4a7c-9c3d-3e7f7e8d2a1a"), CategoryId = Guid.Parse("ae6f2420-78ac-4145-b2d9-6de49e10867e"), Name = "Letter/LetterHeads", Descripcion = "Connect with past and future clients with pre-written letters and customizable letterheads.", CreationDate = DateTime.Now, StatusProduct = Status.Active, ImageUrl = "https://gmbb20.s3.amazonaws.com/home/crop_crop_Letter_650x650.png" });
        productsInit.Add(new Products { ProductId = Guid.Parse("36f8c9a2-4d5f-4a7c-9c3d-3e7f7e8d2a1a"), CategoryId = Guid.Parse("ae6f2420-78ac-4145-b2d9-6de49e10867e"), Name = "Helpful Documents", Descripcion = "Cover your bases with the help of these branded documents.", CreationDate = DateTime.Now, StatusProduct = Status.Active, ImageUrl = "https://gmbb20.s3.amazonaws.com/home/crop_crop_Helpful_Docs_650x650.png" });
        productsInit.Add(new Products { ProductId = Guid.Parse("26f8c9a2-4d5f-4a7c-9c3d-3e7f7e8d2a1a"), CategoryId = Guid.Parse("ae6f2420-78ac-4145-b2d9-6de49e10867e"), Name = "Business Cards", Descripcion = "Create a first and lasting impression by using one of a variety of branded business cards.", CreationDate = DateTime.Now, StatusProduct = Status.Active, ImageUrl = "https://gmbb20.s3.amazonaws.com/home/crop_crop_Business_Card_650x650.png" });
        productsInit.Add(new Products { ProductId = Guid.Parse("16f8c9a2-4d5f-4a7c-9c3d-3e7f7e8d2a1a"), CategoryId = Guid.Parse("ae6f2420-78ac-4145-b2d9-6de49e10867e"), Name = "Email Signatures", Descripcion = "Keep your communications branded with the information your contacts need.", CreationDate = DateTime.Now, StatusProduct = Status.Active, ImageUrl = "https://gmbb20.s3.amazonaws.com/home/crop_crop_Email_Signature_650x650.png" });
        productsInit.Add(new Products { ProductId = Guid.Parse("06f8c9a2-4d5f-4a7c-9c3d-3e7f7e8d2a1a"), CategoryId = Guid.Parse("ae6f2420-78ac-4145-b2d9-6de49e10867e"), Name = "NewsLetters", Descripcion = "Keep your sphere informed and updated with industry insights and other helpful topics.", CreationDate = DateTime.Now, StatusProduct = Status.Active, ImageUrl = "https://gmbb20.s3.amazonaws.com/home/crop_crop_Newsletter_650x650.png" });
        productsInit.Add(new Products { ProductId = Guid.Parse("f6f8c9a2-4d5f-4a7c-9c3d-3e7f7e8d2a1a"), CategoryId = Guid.Parse("ae6f2420-78ac-4145-b2d9-6de49e10867e"), Name = "Spanish Materials", Descripcion = "Appeal to Spanish-speaking audiences with our variety of Spanish marketing items.", CreationDate = DateTime.Now, StatusProduct = Status.Active, ImageUrl = "https://gmbb20.s3.amazonaws.com/home/crop_crop_Spanish_Marketing_650x650.png" });
        productsInit.Add(new Products { ProductId = Guid.Parse("e6f8c9a2-4d5f-4a7c-9c3d-3e7f7e8d2a1a"), CategoryId = Guid.Parse("ae6f2420-78ac-4145-b2d9-6de49e10867e"), Name = "eXp Solutions", Descripcion = "Download partner resources to provide your clients with valuable information.", CreationDate = DateTime.Now, StatusProduct = Status.Active, ImageUrl = "https://gmbb20.s3.amazonaws.com/home/crop_eXp_Solutions_650x650.png" });

        
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
        designsInit.Add(new Design { DesignId = Guid.Parse("ae6f2420-78ac-4145-b2d9-6de49e108661"), ProductId = Guid.Parse("b1b0b0a0-78ac-4145-b2d9-6de49e10867e"), Name = "Flyers", Descripcion = "Provide a memorable takeaway with our collection of professionally-designed flyers.", StatusProduct = Status.Active, CreationDate = DateTime.Now });
    }
}