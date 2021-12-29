using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using WebSite.Models;

namespace WebSite
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (ModelsContext mContext = new ModelsContext())
            {
                 mContext.Database.EnsureCreated();
            }
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                }).Build().Run();
        }
    }
}