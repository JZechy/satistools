using Microsoft.Extensions.DependencyInjection;

namespace Satistools.Calculator.Extensions;

public static class ServiceExtension
{
    public static void AddCalculator(this IServiceCollection services)
    {
        services.AddTransient<IProductionCalculator, ProductionCalculator>();
    }
}