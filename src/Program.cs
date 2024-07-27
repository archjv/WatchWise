// This file meets the code guidelines. Therefore code standards are achieved for this file.

using Microsoft.AspNetCore.Hosting;

using Microsoft.Extensions.Hosting;

namespace ContosoCrafts.WebSite
{
    /// <summary>
    /// Program class contains the Main method, creates host builder 
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Building and running Host builder
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Creates default builder
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    // Use Startup class methods
                    webBuilder.UseStartup<Startup>();
                });
    }
}