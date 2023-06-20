using BlazorAppServer;
using BlazorAppServer.Interfaces;
using BlazorAppServer.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connString = builder.Configuration["ConnectionStrings:Dev"];
builder.Services.AddDbContext<ApplicationDbContext>(o => {
    o.UseLazyLoadingProxies().UseSqlServer(connString);/*.LogTo(Console.WriteLine, LogLevel.Information);*/

});
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IColorRepository, ColorRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IPromotionRepository, PromotionRepository>();
builder.Services.AddScoped<ISellDepartmentRepository, SellDepartmentRepository>();
builder.Services.AddCors(options => {
    options.AddPolicy("newPolicy", app =>
    {
        app.AllowAnyOrigin()
      .AllowAnyHeader()
      .AllowAnyMethod();
      });
    });
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("newPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
