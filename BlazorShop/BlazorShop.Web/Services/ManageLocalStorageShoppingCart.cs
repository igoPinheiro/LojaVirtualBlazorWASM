using Blazored.LocalStorage;
using BlazorShop.Models.DTOs;

namespace BlazorShop.Web.Services;

public class ManageLocalStorageShoppingCart : IManageLocalStorageShoppingCart
{
    private const string Key = "CartItemColletion";

    private readonly ILocalStorageService _localStorageService;
    private readonly IShoppingCartService _shoppingCartService;

    public ManageLocalStorageShoppingCart(ILocalStorageService localStorageService, IShoppingCartService shoppingCartService)
    {
        _localStorageService = localStorageService;
        _shoppingCartService = shoppingCartService;
    }

    public async Task<List<CartItemDto>> GetCollection()
    {
        return await this._localStorageService.GetItemAsync<List<CartItemDto>>(Key)
                         ?? await AddCollection();
    }

    public async Task RemoveCollection()
    {
        await this._localStorageService.RemoveItemAsync(Key);
    }

    public async Task SaveCollection(List<CartItemDto> cartItemDto)
    {
       await this._localStorageService.SetItemAsync(Key, cartItemDto);
    }

    private async Task<List<CartItemDto>> AddCollection()
    {
        var cartItem = await this._shoppingCartService.GetItems(LoggedUser.UsuarioId);

        if (cartItem != null)
            await this._localStorageService.SetItemAsync(Key, cartItem);

        return cartItem;
    }
}
