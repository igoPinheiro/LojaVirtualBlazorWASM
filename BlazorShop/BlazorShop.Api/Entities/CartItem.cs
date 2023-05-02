namespace BlazorShop.Api.Entities;

public class CartItem
{
    public int Id { get; set; }
    public int CartID { get; set; }
    public int ProductId { get; set; }
    public int Qtd { get; set; }

    //Propriedade de navegação - Elas nao criam colunas no banco de dados
    public Cart? Cart { get; set; }
    public Product? Product { get; set; }
}
