using System;
using System.Threading.Tasks;
using ExampleWebApi;
using Microsoft.AspNetCore.Hosting;
using Xunit; 
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using WebApiTests.ExampleWebApiService;

namespace WebApiTests
{
    public class ApiUnitTest : IClassFixture<ExampleApiTestContext>
    {
        private readonly ExampleApiTestContext _testContext;

        public ApiUnitTest(ExampleApiTestContext testContext)
        {
            _testContext = testContext; 
        }

        [Fact]
        public async Task Test1()
        {
            var env = await _testContext.Client.GetEnvAsync();
            var conf = await _testContext.Client.GetConfigParameterAsync();
            Assert.Equal("Prod", env);
            
        }
    }


    public class ExampleApiTestContext : TestApiWebApplicationFactory<ExampleApiTestStartup>
    {
        public DataClient Client;

        public ExampleApiTestContext()
        {
            var httpClient = CreateClient();

            Client = new ExampleWebApiService.DataClient(httpClient)
            {
                BaseUrl = httpClient.BaseAddress.ToString()
            };
        }
    }

    public class TestApiWebApplicationFactory<TStartup> : WebApplicationFactory<Startup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Prod");
            builder.UseStartup<ExampleApiTestStartup>();

        }
    }

    public class ExampleApiTestStartup : Startup
    {
        public ExampleApiTestStartup(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
