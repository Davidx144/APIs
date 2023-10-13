using proyectoef.Models;
namespace proyectoef.Services;
public class CategoryService : ICategoryService
{
    APIContext context;
    public CategoryService(APIContext dbcontext)
    {
        context = dbcontext;
    }
    public IEnumerable<Category> Get()
    {
        return context.Categories;
    }

    public Category GetById(Guid id)
    {
        return context.Categories.Find(id);
    }

    public async Task Save(Category category)
    {
        context.Add(category);
        await context.SaveChangesAsync();
    }


    public async Task Update(Guid id, Category category)
    {
        var actualCategory = context.Categories.Find(id);
        if (actualCategory != null)
        {
            actualCategory.Name = category.Name;
            actualCategory.Descripcion = category.Descripcion;
            actualCategory.StatusCategory = category.StatusCategory;
            await context.SaveChangesAsync();
        }
    }

    public async Task Delete(Guid id)
    {
        var actualCategory = context.Categories.Find(id);
        if (actualCategory != null)
        {
            context.Categories.Remove(actualCategory);
            await context.SaveChangesAsync();
        }
    }
}

public interface ICategoryService
{
    IEnumerable<Category> Get();
    Category GetById(Guid id);
    Task Save(Category category);
    Task Update(Guid id, Category category);
    Task Delete(Guid id);
}