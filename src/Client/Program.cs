using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Blazor.Hosting;
using Microsoft.Extensions.DependencyInjection;
using DeckOfCards.Client.Services;

namespace DeckOfCards.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            //A Singleton allows the same instance of a service class to be shared across components.
            builder.Services.AddSingleton<AppData>();

            builder.RootComponents.Add<App>("app");

            await builder.Build().RunAsync();
        }
    }
}
