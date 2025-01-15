using System.Diagnostics;
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Warhammer40KFanSite.Data;
using Warhammer40KFanSite.Models;
using Warhammer40KFanSite.QuizModel;

namespace Warhammer40KFanSite.Controllers;

public class HomeController : Controller
{
    // private field
    IStoryRepository _storyRepo;
    private UserManager<AppUser> _userManager; 
    private SignInManager<AppUser> _signInManager;
    public HomeController(UserManager<AppUser> userMngr, SignInManager<AppUser> signInMngr, IStoryRepository r)
    {
        _userManager = userMngr; _signInManager = signInMngr;
        _storyRepo = r;
    } 

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult History()
    {
        return View();
    }

    public IActionResult Stories()
    {
        List<Story> stories = _storyRepo.GetStories();
        return View(stories);
    }
    
    public IActionResult Filter(string title, string date)
    {
        var stories = _storyRepo.GetStories()
            .Where(s => title == null || s.StoryTitle == title)
            .Where(s => date == null || s.StoryDate == DateTime.Parse(date))
            .ToList();
        
        return View("Stories", stories);
    }
    
    [HttpPost]
    public IActionResult Stories(Story model)
    {
        //AppUser user1 = new AppUser() { AccountAge = DateOnly.FromDateTime(DateTime.Now), UserName = "Test" };
        
        model.StoryAuthor = _userManager.GetUserAsync(User).Result;
        
        if (_storyRepo.StoreStory(model) > 0)
        {
            return View(_storyRepo.GetStories());
        }
        else
        {
            ViewBag.ErrorMessage = "There was an error saving the story.";
            return View();
        }
    }
    
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public IActionResult Quiz()
    {
        Quiz model = new Quiz();
        return View(model);
    }
    
    [HttpPost]
    public IActionResult Quiz(string answer1, string answer2, string answer3, string answer4, string answer5)
    {
        Quiz model = new Quiz();
        
        model.Questions[0].UserAnswer = answer1;
        model.Questions[0].IsCorrect = model.CheckAnswer(model.Questions[0]);
        
        model.Questions[1].UserAnswer = answer2;
        model.Questions[1].IsCorrect = model.CheckAnswer(model.Questions[1]);
        
        model.Questions[2].UserAnswer = answer3;
        model.Questions[2].IsCorrect = model.CheckAnswer(model.Questions[2]);
        
        model.Questions[3].UserAnswer = answer4;
        model.Questions[3].IsCorrect = model.CheckAnswer(model.Questions[3]);

        model.Questions[4].UserAnswer = answer5;
        model.Questions[4].IsCorrect = model.CheckAnswer(model.Questions[4]);
        
        
        return View(model);
    }
}

