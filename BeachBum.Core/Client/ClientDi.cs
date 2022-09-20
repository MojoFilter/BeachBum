using BeachBum.Core.Client;

namespace Microsoft.Extensions.DependencyInjection;

public static class ClientDi
{
    public static IServiceCollection AddBeachBumClient(this IServiceCollection services, string baseUri)
    {
        services.AddHttpClient("BeachBum")
                .ConfigureHttpClient(client => client.BaseAddress = new Uri(baseUri));

        services.AddTransient<IBeachBumApiClient, BeachBumApiClient>();

        return services;
    }

}
