using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using StorageHandler;

namespace UserServiceCore
{
    public class Program
    {
        internal static IStorageService service;

        public static void Main(string[] args)
        {
            service = StorageFactory.GetService();
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
