using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Build and run the host using the configured host builder
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Configures and returns the IHostBuilder for the application.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        /// <returns>IHostBuilder instance.</returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    // Specify the Startup class to use
                    webBuilder.UseStartup<Startup>();

                    // Optionally, you can add more configurations here, for example:
                    // webBuilder.UseUrls("http://localhost:5000");
                    // webBuilder.CaptureStartupErrors(true);
                });
    }
}
