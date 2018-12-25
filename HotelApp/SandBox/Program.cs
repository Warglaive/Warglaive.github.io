namespace SandBox
{
    using System;
    using System.IO;
    using System.Linq;
    using HotelApp.Web.Data;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine($"{typeof(Program).Namespace} ({string.Join(" ", args)}) starts working...");
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider(true);

            // Seed data on application startup
            using (var serviceScope = serviceProvider.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<HotelAppWebContext>();

                dbContext.Database.Migrate();

                // ApplicationDbContextSeeder.Seed(dbContext, serviceScope.ServiceProvider);
            }

            using (var serviceScope = serviceProvider.CreateScope())
            {
                serviceProvider = serviceScope.ServiceProvider;

                SandBoxCode(serviceProvider);
            }
        }

        private static void SandBoxCode(IServiceProvider serviceProvider)
        {
            var db = serviceProvider.GetService<HotelAppWebContext>();
            Console.WriteLine(db.Users.Count());
        }

        private static void ConfigureServices(ServiceCollection serviceCollection)
        {
            var configuration = new ConfigurationBuilder().SetBasePath(
                Directory.GetParent(Directory.GetCurrentDirectory())
                .Parent.Parent.FullName).AddJsonFile("appsettings.json", false, true)
                .AddEnvironmentVariables()
                .Build();

            serviceCollection.AddDbContext<HotelAppWebContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));
        }
    }
}