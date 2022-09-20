namespace BeachBum.Core;

public sealed class Round
{
    public int RoundId { get; set; }
    public  int RoundNumber { get; set; }
    public ICollection<RoundQuestion> Questions { get; set; } = null!;
    public BonusQuestion? BonusQuestion { get; set; }
}

public sealed class RoundQuestion
{
    public int RoundQuestionId { get; set; }
    public Round Round { get; set; } = null!;
    public Question Question { get; set; } = null!;
    public int QuestionNumber { get; set; }
}
