using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Spotify.API.NetCore;
using Spotify.API.NetCore.Auth;
using System.Linq;

namespace VinilEcommerce
{
    public class Program
    {
        public static void Main(string[] args)
        {

            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
