using BlazorShop.Models.DTOs;

namespace BlazorShop.Web.Services;

public interface IManageLocalStorageProducts
{
    Task<IEnumerable<ProductDto>> GetCollection();
    Task RemoveCollection();
}
