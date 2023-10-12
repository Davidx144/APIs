using Microsoft.EntityFrameworkCore;
using proyectoef.Models;

namespace proyectoef;

public class TareasContext : DbContext
{
    //cada una de estas colecciones representa una tabla en la base de datos
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Tarea> Tareas { get; set; }
    //esto es para que se pueda inyectar el contexto en el controlador
    public TareasContext(DbContextOptions<TareasContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
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
        tareasInit.Add(new Tarea { TareaId = Guid.Parse("ae6f2420-78ac-4145-b2d9-6de49e108661"), CategoriaId = Guid.Parse("ae6f2420-78ac-4145-b2d9-6de49e10867e"), Titulo = "Hacer le back en .Net", Descripcion = "Realizar el back segun mokups en .Net y C#", PrioridadTarea = Prioridad.Alta, FechaCreacion = DateTime.Now});
        tareasInit.Add(new Tarea { TareaId = Guid.Parse("ae6f2420-78ac-4145-b2d9-6de49e108662"), CategoriaId = Guid.Parse("ae6f2420-78ac-4145-b2d9-6de49e10867e"), Titulo = "Hacer le front en Angular", Descripcion = "Realizar el front segun mokups en Angular", PrioridadTarea = Prioridad.Alta, FechaCreacion = DateTime.Now});
        tareasInit.Add(new Tarea { TareaId = Guid.Parse("ae6f2420-78ac-4145-b2d9-6de49e108663"), CategoriaId = Guid.Parse("b1b0b0a0-78ac-4145-b2d9-6de49e10867e"), Titulo = "Hacer le front en React", Descripcion = "Ordenar la cocina", PrioridadTarea = Prioridad.Baja, FechaCreacion = DateTime.Now});
        tareasInit.Add(new Tarea { TareaId = Guid.Parse("ae6f2420-78ac-4145-b2d9-6de49e108664"), CategoriaId = Guid.Parse("c2c0c0a0-78ac-4145-b2d9-6de49e10867e"), Titulo = "dar de comer a los peces", Descripcion = "Ordenar la pecera y alimentar a los peces", PrioridadTarea = Prioridad.Media, FechaCreacion = DateTime.Now});
        tareasInit.Add(new Tarea { TareaId = Guid.Parse("ae6f2420-78ac-4145-b2d9-6de49e108665"), CategoriaId = Guid.Parse("c2c0c0a0-78ac-4145-b2d9-6de49e10867e"), Titulo = "Hacer le front en Vue", Descripcion = "Realizar el front segun mokups en Vue", PrioridadTarea = Prioridad.Alta, FechaCreacion = DateTime.Now});
        
        modelBuilder.Entity<Tarea>(tarea =>
        {
            tarea.ToTable("Tarea");
            tarea.HasKey(t => t.TareaId);
            tarea.HasOne(p=> p.Categoria).WithMany(p=> p.Tareas).HasForeignKey(p=> p.CategoriaId);
            tarea.Property(t => t.Titulo).HasMaxLength(200).IsRequired();
            tarea.Property(t => t.Descripcion).HasMaxLength(500).IsRequired(false);
            tarea.Property(t => t.PrioridadTarea); 
            tarea.Property(t => t.FechaCreacion);
            //tarea.HasOne(t => t.Categoria).WithMany(t => t.Tareas).HasForeignKey(t => t.CategoriaId);
            tarea.Ignore(t => t.Resumen);
            tarea.HasData(tareasInit);
        });
    }
}