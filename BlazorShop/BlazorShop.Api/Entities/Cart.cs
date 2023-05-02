namespace BlazorShop.Api.Entities;

public class Cart
{
    public int Id { get; set; }
    public int UserId { get; set; }

    //Propriedade de navegação - Elas nao criam colunas no banco de dados
    public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
}
