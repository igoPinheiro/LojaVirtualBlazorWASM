using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace BlazorShop.Api.Entities;

public class Category
{
    public int Id { get; set; }
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;
    [MaxLength(100)]
    public string IconCSS { get; set; } = string.Empty;
    
    //Propriedade de navegação - Elas nao criam colunas no banco de dados
    //Relacionamento 1-n.
    public ICollection<Product> Products { get; set; } = new Collection<Product>();
}