using BlazorShop.Api.Entities;
using BlazorShop.Models.DTOs;

namespace BlazorShop.Api.Repositories;

public interface IShoppingCartRepository
{
    Task<CartItem> AddItem(CartItemAddDto chartItemAddDto);
    Task<CartItem> UpdateQtd(int id, CartItemUpdateQtdDto chartItemUpdateQtd);
    Task<CartItem> DeleteItem(int id);
    Task<CartItem> GetItem(int id);
    Task<IEnumerable<CartItem>> GetItems(int usuarioId);
}
