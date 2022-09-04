
using Microsoft.Extensions.DependencyInjection;

public static class TreeModule
{
    public static void AddTreeView( this IServiceCollection services)
    {
        services.AddScoped<TreeBuilder>();
        services.AddScoped<TreeConvert<BusinessResource>>();
    
    }
}