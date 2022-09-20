using System.Net.Http.Json;

namespace BeachBum.Core.Client;

public interface IBeachBumApiClient
{
    Task AddVenue(string name, string location, CancellationToken cancellationToken = default);
    Task<IEnumerable<Venue>> GetVenuesAsync(CancellationToken cancellationToken = default);
}

internal sealed class BeachBumApiClient : IBeachBumApiClient 
{
    public BeachBumApiClient(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }

    public async Task<IEnumerable<Venue>> GetVenuesAsync(CancellationToken cancellationToken = default)
    {
        using var client = _clientFactory.CreateClient();
        return await client.GetFromJsonAsync<IEnumerable<Venue>>("/venues", cancellationToken) ?? Enumerable.Empty<Venue>();
    }

    public async Task AddVenue(string name, string location, CancellationToken cancellationToken = default)
    {
        var venue = new Venue()
        {
            Name = name,
            Location = location
        };
        using var client = _clientFactory.CreateClient();
        await client.PutAsJsonAsync("/venue", venue, cancellationToken);
    }

    private IHttpClientFactory _clientFactory;
}
