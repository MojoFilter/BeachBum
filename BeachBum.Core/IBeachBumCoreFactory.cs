namespace BeachBum.Core;

public interface IBeachBumCoreFactory
{
    public Venue CreateVenue(string name, string location) =>
        new Venue()
        {
            Name = name,
            Location = location
        };
}
