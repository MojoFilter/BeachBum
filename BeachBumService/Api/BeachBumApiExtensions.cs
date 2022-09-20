namespace BeachBumService.Api;

internal static class BeachBumApiExtensions
{
    public static WebApplication UseBeachBumApi(this WebApplication app)
    {
        app.MapGet("/venues", Venues.List)
           .WithName("ListVenues");

        app.MapPost("/venue", Venues.Add);

        return app;
    }
}
