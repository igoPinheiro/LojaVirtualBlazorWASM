using BlazorShop.Api.Context;
using BlazorShop.Api.Entities;
using BlazorShop.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace BlazorShop.Api.Repositories;

public class ShoppingCartRepository : IShoppingCartRepository
{
    private readonly AppDbContext _context;

    public ShoppingCartRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<CartItem> AddItem(CartItemAddDto cartItemAddDto)
    {
        if (await CartItemExists(cartItemAddDto.CartId, cartItemAddDto.ProductId) == false)
        {
            //verifica se o produto existe e cria um novo item no carrinho
            var item = await (from product in _context.Products
                              where product.Id == cartItemAddDto.ProductId
                              select new CartItem
                              {
                                  CartID = cartItemAddDto.CartId,
                                  ProductId = product.Id,
                                  Qtd= cartItemAddDto.Qtd
                              }).SingleOrDefaultAsync();
            if(item is not null)
            {
                var result =await _context.CartItems.AddAsync(item);
                await _context.SaveChangesAsync();
                return result.Entity;
            }
        }

        return null;
    }

    private async Task<bool> CartItemExists(int cartId, int productId)
    {
        return await _context.CartItems.AnyAsync(c => c.CartID == cartId &&
                                                 c.ProductId == productId);
    }

    public async Task<CartItem> DeleteItem(int id)
    {
        var item =await _context.CartItems.FindAsync(id);

        if(item is not null)
        {
            _context.CartItems.Remove(item);
           await  _context.SaveChangesAsync();
        }


        return item;
    }

    public async Task<CartItem> GetItem(int id)
    {
        return await (from cart in _context.Carts
                      join cartItem in _context.CartItems
                      on cart.Id equals cartItem.CartID
                      where cart.Id == id
                      select new CartItem
                      {
                          Id = cartItem.Id,
                          CartID = cartItem.CartID,
                          ProductId = cartItem.ProductId,
                          Qtd = cartItem.Qtd,
                      }).SingleOrDefaultAsync();
    }

    public async Task<IEnumerable<CartItem>> GetItems(int usuarioId)
    {
        return await (from cart in _context.Carts
                      join cartItem in _context.CartItems
                      on cart.Id equals cartItem.CartID
                      where cart.UserId == usuarioId
                      select new CartItem
                      {
                          Id = cartItem.Id,
                          CartID = cartItem.CartID,
                          ProductId = cartItem.ProductId,
                          Qtd = cartItem.Qtd,
                      }).ToListAsync();
    }

    public async Task<CartItem> UpdateQtd(int id, CartItemUpdateQtdDto cartItemUpdateQtd)
    {
        var cartItem = await _context.CartItems.FindAsync(id);

        if(cartItem != null)
        {
            cartItem.Qtd = cartItemUpdateQtd.Qtd;
            await _context.SaveChangesAsync();
            return cartItem;
        }

        return null;
    }
}
