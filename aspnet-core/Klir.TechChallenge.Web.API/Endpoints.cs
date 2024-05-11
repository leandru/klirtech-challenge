using Klir.TechChallenge.Catalog.Application;
using Klir.TechChallenge.Sales.Application;
using Klir.TechChallenge.Sales.Application.Dtos;

namespace Klir.TechChallenge.Web.API
{
    public static class EndPoints
    {
        public static void UseEndpoints(this WebApplication app)
        {
            #region ProductsEndpoints
            
            app.MapGet("/products", async (IProductAppService productAppService) =>
            {
                return Results.Ok(await productAppService.GetAllAsync());
            })
            .WithName("GetProducts")
            .WithOpenApi();

            #endregion

            #region CartEndpoints

            app.MapGet("cart/{cartId}", async (ICartAppService cartAppService,
                                                        Guid cartId) =>
            {
                var cart = await cartAppService.GetAsync(cartId);

                if (cart is null)
                    return Results.NotFound();



                return Results.Ok(cart);

            }).WithName("GetCart")
           .WithOpenApi();


            app.MapGet("cart/{cartId}/checkout", async (ICartAppService cartAppService,
                                                Guid cartId) =>
            {
                if (!await cartAppService.Exists(cartId))
                    return Results.NotFound();

                var checkoutResult = await cartAppService.CalculateTotal(cartId);

                return Results.Ok(checkoutResult);

            }).Produces<CartCheckoutResult>()
           .WithName("GetCartCheckout")
           .WithOpenApi();



            app.MapPost("/cart/{cartId}/items/{productId}", async (ICartAppService cartAppService,
                                                        IProductAppService productAppService,
                                                        Guid cartId, int productId) =>
            {                
                var product = await productAppService.GetAsync(productId);
                if (product is null)
                    return Results.BadRequest("Invalid data!");

                var cartItem = new CartItemViewModel(cartId, product.Id, product.Name, product.Price, 1);
                await cartAppService.AddItem(cartItem);
                
                return Results.Created();
            })
            .WithName("CartAddItem")
            .WithOpenApi();


            app.MapDelete("/cart/{cartId}/items/{productId}", async (ICartAppService cartAppService,
                                                    IProductAppService productAppService,
                                                    Guid cartId, int productId) =>
            {
                if (!await cartAppService.Exists(cartId))
                    return Results.NotFound();

                var product = await productAppService.GetAsync(productId);
                if (product is null)
                    return Results.BadRequest("Invalid data!");

                var cartItem = new CartItemViewModel(cartId, product.Id, product.Name, product.Price, 1);
                await cartAppService.RemoveItem(cartItem);

                return Results.NoContent();
            })
            .WithName("CartRemoveItem")
            .WithOpenApi();


            #endregion

        }
    }
}
