namespace Warhammer40KFanSite.QuizModel;

public class Question
{
    public int QuestionId { get; set; }
    public string QuestionText { get; set; } //hard coded questions and answer text
    public string AnswerText { get; set; }
    public string UserAnswer { get; set; } //Users answer
    
    public bool IsCorrect { get; set; }
}