using Klir.TechChallenge.Catalog.Application;
using Klir.TechChallenge.Sales.Application;
using Klir.TechChallenge.Sales.Application.Dtos;
using Klir.TechChallenge.Sales.Application.Mappings;
using Klir.TechChallenge.Web.API.Models;

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


                return Results.Ok(cart.ToDto());

            }).Produces<CartViewModel>()
           .WithName("GetCart")
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


            app.MapPost("/cart/{cartId}/items", async (ICartAppService cartAppService,
                                                        IProductAppService productAppService,
                                                        Guid cartId, ProductViewModel productViewModel ) =>
            {                
                var product = await productAppService.GetAsync(productViewModel.ProductId);
                if (product is null)
                    return Results.BadRequest("Invalid data!");

                var cartItem = new CartAddItemViewModel(cartId, product.Id, product.Name, product.Price, 1);
                await cartAppService.AddItem(cartItem);
                
                return Results.Ok();
            })
            .WithName("CartAddItem")
            .WithOpenApi();


            app.MapPatch("/cart/{cartId}/items/{productId}/quantity/{quantity}", async (ICartAppService cartAppService,
                                                      IProductAppService productAppService,
                                                      Guid cartId, int productId, int quantity) =>
            {
                var cart = await cartAppService.GetAsync(cartId);

                if (cart is null)
                    return Results.NotFound();

                var cartItem = cart.GetItem(productId);
                if (cartItem is null)
                    return Results.NotFound();

                cartItem.SetQuantity(quantity);
                await cartAppService.UpdateItem(cartItem);

                return Results.Ok(cartItem.TotalWithDiscount());
            })
          .WithName("CartSetItemQuantity")
          .WithOpenApi();


            app.MapDelete("/cart/{cartId}/items/{productId}", async (ICartAppService cartAppService,
                                                    IProductAppService productAppService,
                                                    Guid cartId, int productId) =>
            {
                var cart = await cartAppService.GetAsync(cartId);

                if (cart is null)
                    return Results.NotFound();

                var cartItem = cart.GetItem(productId);
                if (cartItem is null)
                    return Results.NotFound();

                await cartAppService.RemoveItem(cartItem);

                return Results.NoContent();
            })
            .WithName("CartRemoveItem")
            .WithOpenApi();

            #endregion

        }
    }
}
