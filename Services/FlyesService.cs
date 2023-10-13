using proyectoef.Models;
namespace proyectoef.Services;

public class FlyesService : IFlyesService
{
    APIContext context;
    public FlyesService(APIContext dbcontext)
    {
        context = dbcontext;
    }
    public IEnumerable<Flyes> Get()
    {
        return context.Flyes;
    }

    public Flyes GetById(Guid id)
    {
        return context.Flyes.Find(id);
    }

    public IEnumerable<Flyes> GetByDesignId(Guid desingId)
    {
        return context.Flyes.Where(p => p.DesignId == desingId);
    }


    public async Task Save(Flyes flyes)
    {
        flyes.CreationDate = DateTime.Now;
        context.Add(flyes);
        await context.SaveChangesAsync();
    }

    public async Task Update(Guid id, Flyes flyes)
    {
        var actualFlyes = context.Flyes.Find(id);
        if (actualFlyes != null)
        {
            actualFlyes.Name = flyes.Name;
            actualFlyes.Descripcion = flyes.Descripcion;
            actualFlyes.ImageUrl = flyes.ImageUrl;
            actualFlyes.StatusFlyes = flyes.StatusFlyes;
            await context.SaveChangesAsync();
        }
    }

    public async Task Delete(Guid id)
    {
        var actualFlyes = context.Flyes.Find(id);
        if (actualFlyes != null)
        {
            context.Flyes.Remove(actualFlyes);
            await context.SaveChangesAsync();
        }
    }
}

public interface IFlyesService
{
    IEnumerable<Flyes> Get();
    Flyes GetById(Guid id);
    IEnumerable<Flyes> GetByDesignId(Guid desingId);
    Task Save(Flyes flyes);
    Task Update(Guid id, Flyes flyes);
    Task Delete(Guid id);
}