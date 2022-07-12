using CalculadoraImpostos_SergioDias.Domain;
using CalculadoraImpostos_SergioDias.Presentation.ProgramFlow;
using CalculadoraImpostos_SergioDias.Repositories;
using CalculadoraImpostos_SergioDias.Repositories.Base;
using CalculadoraImpostos_SergioDias.Repositories.Interfaces;
using CalculadoraImpostos_SergioDias.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CalculadoraImpostos_SergioDias.Presentation
{
    public class Program
    {
        public static void Main()
        {
            ServiceCollection services = new();
            ConfigureServices(services);

            var serviceProvider = services.BuildServiceProvider();
            var mainFlow = serviceProvider.GetService<IMainFlow>();

            mainFlow.BeginApp();
        }

        public static void ConfigureServices(IServiceCollection services)
        {
            services
                .AddScoped<IMainFlow, MainFlow>()
                .AddScoped<ITaxCalculator, TaxCalculator>()
                .AddScoped<IPersonTaxInfoRepository, PersonTaxInfoRepository>()
                .AddScoped<IBaseRepository<Person>, BaseRepository<Person>>();
        }
    }
}