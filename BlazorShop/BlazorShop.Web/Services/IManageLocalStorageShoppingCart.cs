using BlazorShop.Models.DTOs;

namespace BlazorShop.Web.Services;

public interface IManageLocalStorageShoppingCart
{
    Task<List<CartItemDto>> GetCollection();
    Task SaveCollection(List<CartItemDto> cartItemDto);
    Task RemoveCollection();
}
