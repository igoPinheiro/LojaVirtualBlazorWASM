using BlazorShop.Api.Mappings;
using BlazorShop.Api.Repositories;
using BlazorShop.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorShop.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductRepository _productRepository;

    public ProductsController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetItems()
    {
        try
        {
            var products = await _productRepository.GetItems();

            if (products == null)
                return NotFound();

            var productsDtos = products.ConvertProductsToDto();
            return Ok(productsDtos);

        }
        catch (Exception )
        {
            return StatusCode(StatusCodes.Status500InternalServerError,"Erro ao acessar a base de dados");
        }
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ProductDto>> GetItem(int id)
    {
        try
        {
            var product = await _productRepository.GetItem(id);

            if (product == null)
                return NotFound("Produto não encontrado!");

            var productDto = product.ConvertProductToDto();
            return Ok(productDto);

        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao acessar a base de dados");
        }
    }

    [HttpGet]
    [Route("GetItensByCategory/{categoryId}")]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetItensByCategory(int categoryId)
    {
        try
        {
            var products = await _productRepository.GetItensByCategory(categoryId);

            if (products == null)
                return NotFound();

            if (products.Count() == 0)
                return new List<ProductDto>();

            var productsDtos = products.ConvertProductsToDto();
            return Ok(productsDtos);

        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao acessar a base de dados");
        }
    }

    [HttpGet]
    [Route("GetCategories")]
    public async Task<ActionResult<IEnumerable<CategoryDto>>>
        GetCateogories()
    {
        try
        {
            var cateogories = await _productRepository.GetAllCategories();

            var categoriesDto = cateogories.ConvertCategoryToDto();

            return Ok(categoriesDto);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao acessar a base de dados");
        }
    }


}
