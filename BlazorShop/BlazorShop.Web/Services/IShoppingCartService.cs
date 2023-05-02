using BlazorShop.Models.DTOs;
using System.Transactions;

namespace BlazorShop.Web.Services;

public interface IShoppingCartService
{
    Task<List<CartItemDto>> GetItems(int usuarioId);
    Task<CartItemDto> AddItem(CartItemAddDto cartItemAddDto);
    Task<CartItemDto> DeleteItem(int id);
    Task<CartItemDto> UpdateQtd(CartItemUpdateQtdDto cartItemUpdateQtdDto);

    /// <summary>
    /// Evento é uma notificação que é enviada para um objeto, no caso aqui será um componente.
    /// Para sinalizar uma ocorrencia de uma ação. Nesse caso a ação será a alteração da quantidade de itens.
    /// 
    /// </summary>
    event Action<int> OnShoppingCartChanged;

    void RaiseEventOnShoppingCartChanged(int totalQtd);
}
