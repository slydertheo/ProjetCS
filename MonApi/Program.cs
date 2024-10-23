using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using main;

namespace MonApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            PlayGrid gameGrid = new PlayGrid(3, 3);
            gameGrid.PrintGrid();
            
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
