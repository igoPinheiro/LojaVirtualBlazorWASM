using BlazorShop.Api.Entities;
using BlazorShop.Models.DTOs;

namespace BlazorShop.Api.Mappings;

public static class MappingsDtos
{
    public static IEnumerable<CategoryDto> ConvertCategoryToDto(this IEnumerable<Category> categories)
    {

        return (from c in categories
                select new CategoryDto
                {
                    IconCSS = c.IconCSS,
                    Id = c.Id,
                    Name = c.Name
                }).ToList();

    }

    public static IEnumerable<ProductDto> ConvertProductsToDto(this IEnumerable<Product> products)
    {

        return (from p in products
                select new ProductDto
                {
                    CategoryId = p.Category?.Id ?? 0,
                    CategoryName = p.Category?.Name ?? string.Empty,
                    Description = p.Description,
                    Id = p.Id,
                    ImageUrl = p.ImageUrl,
                    Name = p.Name,
                    Price = p.Price,
                    Qtd = p.Qtd
                }).ToList();
    }

    public static ProductDto ConvertProductToDto(this Product product)
    {
        return new ProductDto
        {
            CategoryId = product.Category?.Id ?? 0,
            CategoryName = product.Category?.Name ?? string.Empty,
            Description = product.Description,
            Id = product.Id,
            ImageUrl = product.ImageUrl,
            Name = product.Name,
            Price = product.Price,
            Qtd = product.Qtd
        };
    }

    public static IEnumerable<CartItemDto> ConvertCartItemsToDto(this IEnumerable<CartItem> cartItems, IEnumerable<Product> products)
    {

        return (from ci in cartItems
                join p in products
                on ci.ProductId equals p.Id
                select new CartItemDto
                {
                    CartId = ci.CartID,
                    ProductDescription = p.Description,
                    ProductId = ci.ProductId,
                    ProductImageUrl = p.ImageUrl,
                    ProductName = p.Name,
                    Id = ci.Id,
                    Price = p.Price,
                    Qtd = ci.Qtd,
                    Total = p.Price * ci.Qtd
                }).ToList();
    }

    public static CartItemDto ConvertCartItemToDto(this CartItem cartItem, Product product)
    {
        return new CartItemDto
        {
            CartId = cartItem.ProductId,
            ProductDescription = product.Description,
            ProductId = cartItem.ProductId,
            ProductImageUrl = product.ImageUrl,
            ProductName = product.Name,
            Id = cartItem.Id,
            Price = product.Price,
            Qtd = cartItem.Qtd,
            Total = product.Price * cartItem.Qtd
        };
    }
}
