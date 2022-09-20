namespace BeachBum.Core;

public sealed class Game
{
    public int GameId { get; set; }
    public string Description { get; set; } = string.Empty;
    public Venue Venue { get; set; } = null!;
    public DateTimeOffset Schedule { get; set; }
    public ICollection<Round> Rounds { get; set; } = null!;
}
