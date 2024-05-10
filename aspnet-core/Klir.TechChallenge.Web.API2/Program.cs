using Klir.TechChallenge.Catalog.Application.Services;
using Klir.TechChallenge.Catalog.Application.Configuration;
using Klir.TechChallenge.Web.API2;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCatalogServices();

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


app.Run();



