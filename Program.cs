using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace BetsApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseKestrel();
                    webBuilder.UseUrls("http://*:4000");
                    webBuilder.UseStartup<Startup>();
                });
    }
}
