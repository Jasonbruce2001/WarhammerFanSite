using Warhammer40KFanSite.QuizModel;

namespace Warhammer40KFanSite.xUnitTests;

public class QuizTests
{
    Quiz _quiz = new Quiz();
    
    public QuizTests()
    {
         //Arrange 
        Question qRight = new Question();
        qRight.QuestionText = "Q1";
        qRight.AnswerText = "RightAnswer";
        qRight.UserAnswer = "RightAnswer";
        
        Question qWrong = new Question();
        qWrong.QuestionText = "Q2";
        qWrong.AnswerText = "RightAnswer";
        qWrong.UserAnswer = "WrongAnswer";
        
        _quiz.Questions.Add(qRight);
        _quiz.Questions.Add(qWrong);
    } 
    
    [Fact]
    public void CheckRightAnswerTest()
    {
        //Act and Assert
        Assert.True(_quiz.CheckAnswer(_quiz.Questions[3])); 
    }
    
    [Fact]
    public void CheckWrongAnswerTest()
    {
        //Act and Assert
        Assert.False(_quiz.CheckAnswer(_quiz.Questions[4]));
    }

    [Fact]
    public void CheckNumQuestionsTest()
    {
        Assert.Equal(5, _quiz.Questions.Count);
    }
}