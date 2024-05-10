using Klir.TechChallenge.Catalog.Application.Configuration;
using Klir.TechChallenge.Sales.Application.Configuration;
using Klir.TechChallenge.Web.API;
using Klir.TechChallenge.Catalog.Application;
using Klir.TechChallenge.Sales.Application;
using Klir.TechChallenge.Sales.Application.ViewModels;
using Microsoft.AspNetCore.Http.HttpResults;
using Klir.TechChallenge.Web.API.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCatalogServices();
builder.Services.AddSalesServices();

var app = builder.Build();


app.UseSeedData();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/products", async (IProductAppService productAppService) =>
{
    return await productAppService.GetAllAsync();
})
.WithName("GetProducts")
.WithOpenApi();


app.MapPost("/cart/{cartId}/add", async (ICartAppService cartAppService, 
                                            IProductAppService productAppService, 
                                            Guid cartId, Item item) =>
{
    var product = await productAppService.GetAsync(item.ProductId);
    if (product is null)
        return Results.BadRequest("Product does not exists");

    var cartItem = new CartItemViewModel(cartId, product.Id, product.Name, product.Price, item.Quantity);
    await cartAppService.AddItem(cartItem);
    return Results.Ok();
})
.WithName("CartAddItem")
.WithOpenApi();


app.Run();



