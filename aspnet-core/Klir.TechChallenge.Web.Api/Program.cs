using Klir.TechChallenge.Catalog.Application.Configuration;
using Klir.TechChallenge.Sales.Application.Configuration;
using Klir.TechChallenge.Web.API;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCatalogServices();
builder.Services.AddSalesServices();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});


var app = builder.Build();



app.UseSeededData();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

//app.UseHttpsRedirection();


app.UseEndpoints();

app.Run();

public partial class Program { }