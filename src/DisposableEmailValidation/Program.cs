using DisposableEmailValidation.Interfaces;
using DisposableEmailValidation.Models;
using DisposableEmailValidation.Repositories;
using DisposableEmailValidation.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.IO;

namespace DisposableEmailValidation
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // create service collection
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            // create service provider
            var serviceProvider = serviceCollection.BuildServiceProvider();

            // entry to run app
            serviceProvider.GetService<App>().Run();
        }

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            var currentDir = Directory.GetCurrentDirectory();

            // build configuration
            var configuration = new ConfigurationBuilder()
              .AddJsonFile($"{currentDir}/appsettings.json", false, true)
              .Build();

            // add logging
            serviceCollection.AddLogging(configure => configure.AddConsole());

            serviceCollection.AddOptions();
            serviceCollection.Configure<AppSettings>(configuration.GetSection("Configuration"));

            // add repository
            serviceCollection.AddTransient<IUtilsRepository, UtilsRepository>();
            serviceCollection.AddTransient<IUserRepository, UserRepository>();

            // add services
            serviceCollection.AddTransient<ITestService, TestService>();
            serviceCollection.AddTransient<IValidateEmailService, ValidateEmailService>();

            // add app
            serviceCollection.AddTransient<App>();
        }
    }
}