using BlazorShop.Models.DTOs;
using System.Net.Http.Json;

namespace BlazorShop.Web.Services
{
    public class ProductService : IProductService
    {
        public HttpClient _httpClient;
        public ILogger<ProductService> _logger;

        public ProductService(HttpClient httpClient, ILogger<ProductService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<IEnumerable<ProductDto>> GetItems()
        {
            try
            {
                
                var productDtos = await _httpClient.GetFromJsonAsync<IEnumerable<ProductDto>>("api/products");

                return productDtos;
            }
            catch (Exception ex)
            {
                _logger.LogError("Erro ao acessar produtos: api/products"+ex.Message);
                throw ;
            }
            
        }

        public async Task<ProductDto> GetItem(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/products/{id}");

                if(response.IsSuccessStatusCode) // Status code 200-299
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent) // Status content 204
                        return default(ProductDto);

                    return await response.Content.ReadFromJsonAsync<ProductDto>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    _logger.LogError($"Erro ao obter produto pelo id = {id} - { message}");
                    throw new Exception($"Status Code: {response.StatusCode} - {message}");
                }

               
            }
            catch (Exception ex)
            {
                _logger.LogError("Erro ao acessar produtos: api/products" + ex.Message);
                throw;
            }

        }

        public async Task<IEnumerable<CategoryDto>> GetCategories()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/Products/GetCategories");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                        return Enumerable.Empty<CategoryDto>();

                    return await response.Content.ReadFromJsonAsync<IEnumerable<CategoryDto>>();
                }
                else
                {
                    var msg = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http Status Code´- {response.StatusCode} Message - {msg}");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<ProductDto>> GetItemsByCategory(int categoryId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/Products/GetItensByCategory/{categoryId}");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                        return Enumerable.Empty<ProductDto>();

                    return await response.Content.ReadFromJsonAsync<IEnumerable<ProductDto>>();
                }
                else
                {
                    var msg = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http Status Code´- {response.StatusCode} Message - {msg}");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
