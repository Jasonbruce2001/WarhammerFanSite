namespace Warhammer40KFanSite.QuizModel;

public class Quiz
{
    public int QuizID { get; set; }
    private List<Question> _questions = new List<Question>();

    public Quiz()
    {
        _questions.Add(new Question()
        {
            QuestionText = "What is the longest book?",
            AnswerText = "In Search of Lost Time",
            UserAnswer = ""
        });
        
        _questions.Add(new Question()
        {
            QuestionText = "Who is the author of Harry Potter?",
            AnswerText = "J.K. Rowling",
            UserAnswer = ""
        });
        
        _questions.Add(new Question()
        {
            QuestionText = "Who is the author of Pride and Prejudice?",
            AnswerText = "Jane Austen",
            UserAnswer = ""
        });
        
        _questions.Add(new Question()
        {
            QuestionText = "In the Hunger Games series, what is the name of the country where the story takes place?",
            AnswerText = "Panem",
            UserAnswer = ""
        });
        
        _questions.Add(new Question()
        {
            QuestionText = "Who wrote the Game of Thrones books?",
            AnswerText = "George R.R. Martin",
            UserAnswer = ""
        });
    }

    public List<Question> Questions
    {
        get
        {
            return _questions;
        }
    }

    public bool CheckAnswer(Question q)
    {
        return q.AnswerText == q.UserAnswer;
    }
    
}