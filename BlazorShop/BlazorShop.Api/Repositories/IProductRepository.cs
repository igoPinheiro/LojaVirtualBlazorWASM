using BlazorShop.Api.Entities;

namespace BlazorShop.Api.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetItems();
    Task<Product> GetItem(int id);
    Task<IEnumerable<Product>> GetItensByCategory(int id);
    Task<IEnumerable<Category>> GetAllCategories();
}
