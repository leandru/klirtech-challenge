using Klir.TechChallenge.Sales.Application.Dtos;
using Klir.TechChallenge.Web.API.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Net;
using System.Net.Http.Json;

namespace Klir.TechChallenge.Tests
{
    public class KlirStoreTests
    {
        private readonly WebApplicationFactory<Program> _app;
        private readonly HttpClient _client;

        public KlirStoreTests()
        {
            _app = new WebApplicationFactory<Program>();
            _client = _app.CreateClient();
        }
        [Fact]
        public async Task GetProducts_Endpoint_ReturnsSuccessStatusCode()
        {
            var response = await _client.GetAsync("/products");

            var content = await response.Content.ReadFromJsonAsync<dynamic>();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task CartAddItem_Endpoint_CreateCardAndAddItemAndIncrementQuantity()
        {

            var cartId = Guid.NewGuid(); 
            var productViewModel = new { ProductId = 1 };

            var responseAddItem = await _client.PostAsJsonAsync($"/cart/{cartId}/items", productViewModel);

            Assert.Equal(HttpStatusCode.OK, responseAddItem.StatusCode);

            var cartResponse = await _client.GetAsync($"/cart/{cartId}");

            Assert.Equal(HttpStatusCode.OK, cartResponse.StatusCode);

            var cart = await cartResponse.Content.ReadFromJsonAsync<CartViewModel>();

            Assert.Equal(cart?.Id, cartId);
            Assert.Equal(cart?.Items.Count(), 1);

            await _client.PostAsJsonAsync($"/cart/{cartId}/items", productViewModel);

            var cartResponsev2 = await _client.GetAsync($"/cart/{cartId}");
            var cartv2 = await cartResponsev2.Content.ReadFromJsonAsync<CartViewModel>();

            Assert.Equal(cartv2?.Items.First().Quantity, 2);

        }

        [Fact]
        public async Task GetCart_Endpoint_ShouldReturnNotFoundForNonCar()
        {

            var cartId = Guid.NewGuid();
          
            var cartResponse = await _client.GetAsync($"/cart/{cartId}");

            Assert.Equal(HttpStatusCode.NotFound, cartResponse.StatusCode);
        }

        [Fact]
        public async Task RemoveItem_Endpoint_ShouldRemoveItem()
        {

            var cartId = Guid.NewGuid();
            var productViewModel = new { ProductId = 2 };

            var responseAddItem = await _client.PostAsJsonAsync($"/cart/{cartId}/items", productViewModel);

            Assert.Equal(HttpStatusCode.OK, responseAddItem.StatusCode);

            var cartResponse = await _client.GetAsync($"/cart/{cartId}");

            Assert.Equal(HttpStatusCode.OK, cartResponse.StatusCode);

            var cart = await cartResponse.Content.ReadFromJsonAsync<CartViewModel>();

            var productId = cart?.Items.First().ProductId;

            await _client.DeleteAsync($"/cart/{cartId}/items/{productId}");

            var cartResponsev2 = await _client.GetAsync($"/cart/{cartId}");
            var cartv2 = await cartResponsev2.Content.ReadFromJsonAsync<CartViewModel>();

            Assert.Equal(cartv2?.Items.Count(), 0);
        }

        [Fact]
        public async Task SetQuantity_Endpoint_ShouldSetQuantity()
        {

            var cartId = Guid.NewGuid();
            var productViewModel = new { ProductId = 3 };

            var responseAddItem = await _client.PostAsJsonAsync($"/cart/{cartId}/items", productViewModel);

            Assert.Equal(HttpStatusCode.OK, responseAddItem.StatusCode);

            var cartResponse = await _client.GetAsync($"/cart/{cartId}");

            Assert.Equal(HttpStatusCode.OK, cartResponse.StatusCode);

            var cart = await cartResponse.Content.ReadFromJsonAsync<CartViewModel>();

            var productId = cart?.Items.First().ProductId;

            await _client.PatchAsync($"/cart/{cartId}/items/{productId}/quantity/10", null);

            var cartResponsev2 = await _client.GetAsync($"/cart/{cartId}");
            var cartv2 = await cartResponsev2.Content.ReadFromJsonAsync<CartViewModel>();

            Assert.Equal(cartv2?.Items.First().Quantity, 10);
        }

    }
}