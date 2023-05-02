using BlazorShop.Api.Context;
using BlazorShop.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorShop.Api.Repositories
{
    public class ProdutoRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProdutoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
           var categories = await _context.Categories.ToListAsync();
            return categories;
        }

        // Eager loading: é o mecanismo pela qual uma associação, coleção ou atributo é carregado imediatamente quando o objeto principal é carregado 
        // Include: Junto com o produto, sera carregado informações da categoria dele.
        public async Task<Product> GetItem(int id)
        {
            var product = await _context.Products
                          .Include(c => c.Category)
                          .SingleOrDefaultAsync(c=> c.Id == id);

            return product;
        }

        public async Task<IEnumerable<Product>> GetItems()
        {
            var products = await _context.Products
                         .Include(c => c.Category)
                         .ToListAsync();

            return products;
        }

        public async Task<IEnumerable<Product>> GetItensByCategory(int id)
        {
            var products = await _context.Products
                         .Include(c => c.Category)
                         .Where(w => w.CategoryId == id)
                         .ToListAsync();

            return products;
        }
    }
}
