using System.ComponentModel.DataAnnotations;

namespace BlazorShop.Models.DTOs;

public class CartItemAddDto
{
    [Required]
    public int CartId { get; set; }
    [Required]
    public int ProductId { get; set; }
    [Required]
    public int Qtd { get; set; }
}
