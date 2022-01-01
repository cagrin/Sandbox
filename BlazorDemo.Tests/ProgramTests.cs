namespace BlazorDemo.Tests
{
    using BlazorDemo;
    using BlazorDemo.Data;
    using Blazorise;
    using Blazorise.Bootstrap5;
    using Blazorise.Icons.FontAwesome;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.TestHost;
    using Microsoft.Extensions.DependencyInjection;

    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void ProgramBuilderShouldRun()
        {
            Program.CreateHostBuilder(args: null!);
        }

        [TestMethod]
        public async Task ErrorPageShouldRun()
        {
            using var server = new TestServer(new WebHostBuilder().UseStartup<Startup>());

            var client = server.CreateClient();
            var response = await client.GetAsync(new Uri("/error"));

            Assert.IsNotNull(response);
        }

        [TestMethod]
        public async Task DefaultPageShouldRun()
        {
            using var server = new TestServer(new WebHostBuilder().UseStartup<Startup>());

            var client = server.CreateClient();
            var response = await client.GetAsync(new Uri("/"));

            Assert.IsNotNull(response);
        }

        [TestMethod]
        public async Task FetchdataPageShouldRun()
        {
            using var server = new TestServer(new WebHostBuilder().UseStartup<Startup>());

            var client = server.CreateClient();
            var response = await client.GetAsync(new Uri("/fetchdata"));
            var actual = await response.Content.ReadAsStringAsync();

            Assert.IsTrue(actual.Contains("<h1>Weather forecast</h1>", StringComparison.Ordinal));
        }
    }
}