using Blazored.LocalStorage;
using BlazorShop.Models.DTOs;

namespace BlazorShop.Web.Services;

public class ManageLocalStorageProducts : IManageLocalStorageProducts
{
    private const string Key = "ProductColletion";

    private readonly ILocalStorageService _localStorageService;
    private readonly IProductService _productService;

    public ManageLocalStorageProducts(ILocalStorageService localStorageService, IProductService productService)
    {
        _localStorageService = localStorageService;
        _productService = productService;
    }

    public async Task<IEnumerable<ProductDto>> GetCollection()
    {
        return await this._localStorageService.GetItemAsync<IEnumerable<ProductDto>>(Key)
                         ?? await AddCollection();
    }

    public async Task RemoveCollection()
    {
        await this._localStorageService.RemoveItemAsync(Key);
    }

    private async Task<IEnumerable<ProductDto>> AddCollection()
    {
        var productCollection = await this._productService.GetItems();

        if (productCollection != null)
            await this._localStorageService.SetItemAsync(Key, productCollection);

        return productCollection;
    }
}
