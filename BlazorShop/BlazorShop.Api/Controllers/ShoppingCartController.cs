using BlazorShop.Api.Mappings;
using BlazorShop.Api.Repositories;
using BlazorShop.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BlazorShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartRepository shoppingCartRepository;
        private readonly IProductRepository productRepository;
        private ILogger<ShoppingCartController> logger;

        public ShoppingCartController(IShoppingCartRepository shoppingCartRepository, IProductRepository productRepository, ILogger<ShoppingCartController> logger)
        {
            this.shoppingCartRepository = shoppingCartRepository;
            this.productRepository = productRepository;
            this.logger = logger;
        }

        [HttpGet]
        [Route("{usuarioId}/GetItems")]
        public async Task<ActionResult<IEnumerable<CartItemDto>>> GetItems(int usuarioId)
        {
            try
            {
                var cartItems = await shoppingCartRepository.GetItems(usuarioId);
                if (cartItems == null)
                    return NoContent();

                var product = await this.productRepository.GetItems();
                if (product == null)
                    throw new Exception("Não existem produtos ....");

                var cartItemsDto = cartItems.ConvertCartItemsToDto(product);
                return Ok(cartItemsDto);    
            }
            catch (Exception ex)
            {
                logger.LogError("## Erro ao obter itens do carrinho");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CartItemDto>> GetItem(int id)
        {
            try
            {
                var cartItems = await shoppingCartRepository.GetItem(id);
                if (cartItems == null)
                    return NotFound($"Item não encontrado");

                var product = await this.productRepository.GetItem(cartItems.ProductId);
                if (product == null)
                    throw new Exception("Item não existe na fonte de dados ....");

                var cartItemsDto = cartItems.ConvertCartItemToDto(product);
                return Ok(cartItemsDto);
            }
            catch (Exception ex)
            {
                logger.LogError($"## Erro ao obter item = {id} do carrinho");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<CartItemDto>> PostItem([FromBody] CartItemAddDto cartItemDto)
        {
            try
            {
                var newCartItem = await shoppingCartRepository.AddItem(cartItemDto);

                if (newCartItem == null)
                    return NoContent();

                var product = await productRepository.GetItem(newCartItem.ProductId);

                if (product == null)
                    throw new Exception($"Produto não localizado (Id: {cartItemDto.ProductId})");

                var newCartItemDto = newCartItem.ConvertCartItemToDto(product);

                return CreatedAtAction(nameof(GetItem), new { id = newCartItemDto.Id }, newCartItemDto);
            }
            catch (Exception ex)
            {

                logger.LogError($"## Erro criar um novo item no carrinho");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CartItemDto>> DeleteItem(int id)
        {
            try
            {
                var cartItem = await shoppingCartRepository.DeleteItem(id);
                if (cartItem == null)
                    return NotFound($"Item id: {id} não encontrado!");

                var product = await productRepository.GetItem(cartItem.ProductId);
                if (product == null)
                    return NotFound("Produto não encontrado!");

                var cartItemDto = cartItem.ConvertCartItemToDto(product);
                return Ok(cartItemDto);
            }
            catch (Exception ex)
            {

                logger.LogError($"## Erro ao deletar o item no carrinho");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPatch("{id:int}")] // Atualização parcial
        public async Task<ActionResult<CartItemDto>> UpdateQtd(int id, CartItemUpdateQtdDto cartItemUpdateQtdDto)
        {
            try
            {
                var cartItem = await shoppingCartRepository.UpdateQtd(id, cartItemUpdateQtdDto);

                if (cartItem == null)
                    return NotFound();

                var product = await productRepository.GetItem(cartItem.ProductId);
                var cartItemDto = cartItem.ConvertCartItemToDto(product);
                return Ok(cartItemDto);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }

    

}
