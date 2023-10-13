using proyectoef.Models;
//using webapi.Models;
namespace proyectoef.Services;

public class TareasService : ITareasService
{
    //optenemos el contexto de la base de datos
    APIContext context;
    //pasamos el contexto a al constructor
    public TareasService(APIContext dbcontext)
    {
        context = dbcontext;
    }
    //creamos un metodo para obtener todas las tareas
    public IEnumerable<Tarea> Get()
    {
        return context.Tareas;
    }

    //creamos un metodo para guardar una tarea
    public async Task Save(Tarea Tarea)
    {
        Tarea.FechaCreacion = DateTime.Now;
        context.Add(Tarea);
        await context.SaveChangesAsync();
    }

    //creamos un metodo para actualizar una tarea
    public async Task Update(Guid id, Tarea tarea)
    {
        var tareaActual = context.Tareas.Find(id);
        if (tareaActual != null)
        {
            tareaActual.Titulo = tarea.Titulo;
            tareaActual.Descripcion = tarea.Descripcion;
            tareaActual.PrioridadTarea = tarea.PrioridadTarea;
            tareaActual.FechaCreacion = tarea.FechaCreacion;
            tareaActual.CategoriaId = tarea.CategoriaId;
            tareaActual.CategoriaId = tarea.CategoriaId;
            await context.SaveChangesAsync();
        }
    }
    //creamos un metodo para eliminar una tarea
    public async Task Delete(Guid id)
    {
        var tareaActual = context.Tareas.Find(id);
        if (tareaActual != null)
        {
            context.Tareas.Remove(tareaActual);
            await context.SaveChangesAsync();
        }
    }
}
public interface ITareasService
{
    IEnumerable<Tarea> Get();
    Task Save(Tarea tarea);
    Task Update(Guid id, Tarea tarea);
    Task Delete(Guid id);
}
