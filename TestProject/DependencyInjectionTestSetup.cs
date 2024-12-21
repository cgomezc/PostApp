using Microsoft.Extensions.DependencyInjection;
using PosApp.Application.Interfaces;
using PosApp.Application.Services;
using PosApp.Persistence;
using PostApp.Domain.Interfaces;
using PostApp.Domain.Services;

namespace TestProject
{
    public static class DependencyInjectionTestSetup
    {
        public static ServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            // Register Services
            services.AddTransient<ChangeCalculatorService>();
            services.AddTransient<IChangeService, ChangeService>();

            // Register Repositories
            services.AddSingleton<ICurrencyRepository, InMemoryCurrencyRepository>();

            return services.BuildServiceProvider();
        }
    }
}
