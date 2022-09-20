namespace BeachBum.Core;

public sealed class Question
{
    public int QuestionId { get; set; }
    public string Prompt { get; set; } = string.Empty;
    public string Answer { get; set; } = string.Empty;
}