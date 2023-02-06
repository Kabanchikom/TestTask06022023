namespace TestTask06022023.Cors;

public static class CorsSetupExtensions
{
    public const string FrontEnd = "frontend";
    
    public static IServiceCollection AddCorsConfiguration(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(name: FrontEnd,
                policy =>
                {
                    var a = configuration.GetSection("Frontend:Url").Value;
                    policy.WithOrigins(a)
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
        });

        return services;
    }
}