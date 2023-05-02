using Blazored.LocalStorage;
using BlazorShop.Web;
using BlazorShop.Web.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var baseUrl = "https://localhost:7057";

builder.Services.AddScoped(sp => new HttpClient 
{ 
    BaseAddress = new Uri(baseUrl) 
});

builder.Services.AddScoped<IProductService,ProductService>();
builder.Services.AddScoped<IShoppingCartService, ShoppingCartService>();

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<IManageLocalStorageProducts,ManageLocalStorageProducts>();
builder.Services.AddScoped<IManageLocalStorageShoppingCart,ManageLocalStorageShoppingCart>();

await builder.Build().RunAsync();
