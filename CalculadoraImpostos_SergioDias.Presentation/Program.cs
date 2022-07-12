using CalculadoraImpostos_SergioDias.Presentation.ProgramFlow;
using Microsoft.Extensions.DependencyInjection;

namespace CalculadoraImpostos_SergioDias
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
                .AddScoped<IMainFlow, MainFlow>();
        }
    }
}