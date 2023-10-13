using proyectoef.Models;
namespace proyectoef.Services;

public class DesignService : IDesignService
{
    APIContext context;
    public DesignService(APIContext dbcontext)
    {
        context = dbcontext;
    }
    public IEnumerable<Design> Get()
    {
        return context.Designs;
    }

    public Design GetById(Guid id)
    {
        return context.Designs.Find(id);
    }

    public IEnumerable<Design> GetByProductId(Guid productId)
    {
        return context.Designs.Where(p => p.ProductId == productId);
    }


    public async Task Save(Design design)
    {
        design.CreationDate = DateTime.Now;
        context.Add(design);
        await context.SaveChangesAsync();
    }

    public async Task Update(Guid id, Design design)
    {
        var actualDesign = context.Designs.Find(id);
        if (actualDesign != null)
        {
            actualDesign.Name = design.Name;
            actualDesign.Descripcion = design.Descripcion;
            actualDesign.ImageUrl = design.ImageUrl;
            actualDesign.StatusDesign = design.StatusDesign;
            await context.SaveChangesAsync();
        }
    }

    public async Task Delete(Guid id)
    {
        var actualDesign = context.Designs.Find(id);
        if (actualDesign != null)
        {
            context.Designs.Remove(actualDesign);
            await context.SaveChangesAsync();
        }
    }
}
public interface IDesignService
{
    IEnumerable<Design> Get();
    Design GetById(Guid id);
    IEnumerable<Design> GetByProductId(Guid categoryId);
    Task Save(Design design);
    Task Update(Guid id, Design design);
    Task Delete(Guid id);
}