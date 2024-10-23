using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Grid;

namespace MonApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            PlayGrid gameGrid = new PlayGrid(10, 10);
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
