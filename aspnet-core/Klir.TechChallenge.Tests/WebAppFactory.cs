using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace Klir.TechChallenge.Tests
{
    public class WebAppFactory : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(ReplaceDbContextWithInMemoryDb);
        }

        private static void ReplaceDbContextWithInMemoryDb(IServiceCollection services)
        {

        }
    }
}
