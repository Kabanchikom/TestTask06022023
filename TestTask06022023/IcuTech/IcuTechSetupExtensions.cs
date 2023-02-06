namespace TestTask06022023.IcuTech;

public static class IcuTechSetupExtensions
{
    public static IServiceCollection AddIcuTech(this IServiceCollection services)
    {
        services.AddScoped<IcuTechService>();
        services.AddScoped<IcuTechApiClient>();

        return services;
    }
}