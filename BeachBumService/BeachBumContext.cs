namespace BeachBumService;

public sealed class BeachBumContext : DbContext
{
	public BeachBumContext(DbContextOptions<BeachBumContext> options)
		: base(options)
	{

	}

	public DbSet<Venue> Venues { get; set; } = null!;
	public DbSet<Game> Games { get; set; } = null!;
	public DbSet<Round> Rounds { get; set; } = null!;
	public DbSet<Question> Questions { get; set; } = null!;
	public DbSet<RoundQuestion> RoundQuestions { get; set; } = null!;
	public DbSet<BonusQuestion> BonusQuestions { get; set; } = null!;
	public DbSet<BonusAnswer> BonusAnswers { get; set; } = null!;
}
