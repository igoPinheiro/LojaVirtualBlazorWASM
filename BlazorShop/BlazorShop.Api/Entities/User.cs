using System.ComponentModel.DataAnnotations;
namespace BlazorShop.Api.Entities;

public class User
{
    public int Id { get; set; }
    [MaxLength(100)]
    public string UserName { get; set; } = string.Empty;

    //Propriedade de navegação - Elas nao criam colunas no banco de dados
    public Cart? Cart { get; set; }
}