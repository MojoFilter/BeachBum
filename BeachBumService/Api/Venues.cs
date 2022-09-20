
namespace BeachBumService.Api;

internal static class Venues
{
    public static async Task Add(Venue venue, BeachBumContext context)
    {
        //var venue = coreFactory.CreateVenue(name, location);
        await context.Venues.AddAsync(venue);
        await context.SaveChangesAsync();
    }

    public static async Task<IEnumerable<Venue>> List(BeachBumContext context) => await context.Venues.ToListAsync();
}
