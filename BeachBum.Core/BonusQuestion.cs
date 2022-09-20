namespace BeachBum.Core;

public sealed class BonusQuestion
{
    public int BonusQuestionId { get; set; }
    public string Prompt { get; set; } = null!;
    public ICollection<BonusAnswer> Answers { get; set; } = null!;
}

public sealed class BonusAnswer
{
    public int BonusAnswerId { get; set; }

    public BonusQuestion Question { get; set; } = null!;

    public string Answer { get; set; } = string.Empty;
}