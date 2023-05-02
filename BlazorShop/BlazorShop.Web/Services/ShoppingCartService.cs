using BlazorShop.Models.DTOs;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace BlazorShop.Web.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        public HttpClient _httpClient;
        public ILogger<ShoppingCartService> _logger;

        public ShoppingCartService(HttpClient httpClient, ILogger<ShoppingCartService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public event Action<int> OnShoppingCartChanged;

        public async Task<CartItemDto> AddItem(CartItemAddDto cartItemAddDto)
        {
            try
            {
                var response = await _httpClient
                                     .PostAsJsonAsync<CartItemAddDto>("api/ShoppingCart",cartItemAddDto);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                        return default(CartItemDto);

                    return await response.Content.ReadFromJsonAsync<CartItemDto>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"{response.StatusCode} Message: {message}");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<CartItemDto> DeleteItem(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/ShoppingCart/{id}");
                if (response.IsSuccessStatusCode)
                    return await response.Content.ReadFromJsonAsync<CartItemDto>();
              
                return default(CartItemDto);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<CartItemDto>> GetItems(int usuarioId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/ShoppingCart/{usuarioId}/GetItems");
                if (response.IsSuccessStatusCode)
                {
                    if(response.StatusCode == System.Net.HttpStatusCode.NoContent)
                        return Enumerable.Empty<CartItemDto>().ToList();

                    return await response.Content.ReadFromJsonAsync<List<CartItemDto>>();
                }
                else
                {
                    var message = await response.Content.ReadFromJsonAsync<List<CartItemDto>>();
                    throw new Exception($"Http Status Code: {response.StatusCode}");
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void RaiseEventOnShoppingCartChanged(int totalQtd)
        {
            if (OnShoppingCartChanged != null)
                OnShoppingCartChanged.Invoke(totalQtd);
        }

        public async Task<CartItemDto> UpdateQtd(CartItemUpdateQtdDto cartItemUpdateQtdDto)
        {
            try
            {
                var jsonRequest = JsonSerializer.Serialize(cartItemUpdateQtdDto);

                var content = new StringContent(jsonRequest,Encoding.UTF8,"application/json-patch+json");

                var response = await _httpClient.PatchAsync($"api/ShoppingCart/{cartItemUpdateQtdDto.CartItemId}", content);

                if (response.IsSuccessStatusCode)
                    return await response.Content.ReadFromJsonAsync<CartItemDto>();

                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
