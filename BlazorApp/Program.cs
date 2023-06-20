using BlazorApp;
using BlazorApp.Interfaces;
using BlazorApp.Services;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7143") });
builder.Services.AddScoped<IClientService,ClientService>();
builder.Services.AddScoped<IColorService, ColorService>();
builder.Services.AddScoped<IProductService, ProductService> ();
builder.Services.AddScoped<IPromotionService, PromotionService>();
builder.Services.AddScoped<ISellDepartmentService, SellDepartmentService>();
builder.Services.AddSweetAlert2();
await builder.Build().RunAsync();
