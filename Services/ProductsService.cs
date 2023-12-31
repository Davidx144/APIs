using proyectoef.Models;
namespace proyectoef.Services;

public class ProductsService : IProductsService
{
    APIContext context;
    public ProductsService(APIContext dbcontext)
    {
        context = dbcontext;
    }
    public IEnumerable<Products> Get()
    {
        return context.Products;
    }


    public Products GetById(Guid id)
    {
        return context.Products.Find(id);
    }

    public IEnumerable<Products> GetByCategoryId(Guid categoryId)
    {
        return context.Products.Where(p => p.CategoryId == categoryId);
    }

    public async Task Save(Products products)
    {
        products.CreationDate = DateTime.Now;
        context.Add(products);
        await context.SaveChangesAsync();
    }

    public async Task Update(Guid id, Products products)
    {
        var actualProducts = context.Products.Find(id);
        if (actualProducts != null)
        {
            actualProducts.Name = products.Name;
            actualProducts.Descripcion = products.Descripcion;
            actualProducts.ImageUrl = products.ImageUrl;
            actualProducts.StatusProduct = products.StatusProduct;
            await context.SaveChangesAsync();
        }
    }

    public async Task Delete(Guid id)
    {
        var actualProducts = context.Products.Find(id);
        if (actualProducts != null)
        {
            context.Products.Remove(actualProducts);
            await context.SaveChangesAsync();
        }
    }

}
public interface IProductsService
{
    IEnumerable<Products> Get();
    Products GetById(Guid id);
    IEnumerable<Products> GetByCategoryId(Guid categoryId);
    Task Save(Products products);
    Task Update(Guid id, Products products);
    Task Delete(Guid id);
}