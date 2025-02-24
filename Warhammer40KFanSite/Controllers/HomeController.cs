using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Warhammer40KFanSite.Data;
using Warhammer40KFanSite.Models;

namespace Warhammer40KFanSite.Controllers;

public class HomeController : Controller
{
    // private field
    IStoryRepository _storyRepo;
    ICommentRepository _commentRepo;
    private UserManager<AppUser> _userManager; 
    private SignInManager<AppUser> _signInManager;
    public HomeController(UserManager<AppUser> userMngr, SignInManager<AppUser> signInMngr, IStoryRepository r, ICommentRepository c)
    {
        _userManager = userMngr; _signInManager = signInMngr;
        _storyRepo = r;
        _commentRepo = c;
    } 

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult History()
    {
        return View();
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

    public IActionResult Stories()
    {
        List<Story> stories = _storyRepo.GetStories();
        return View(stories);
    }
    
    public IActionResult Filter(string title, string author)
    {
        var stories = _storyRepo.GetStories()
            .Where(s => title == null || s.StoryTitle == title)
            .Where(s => author == null || s.StoryAuthor.UserName == author)
            .ToList();
            
        return View("Stories", stories);
    }

    public IActionResult FilterNewest()
    {
        var stories = _storyRepo.GetStories()
            .OrderByDescending(s => s.StoryDate)
            .ToList();
        
        return View("Stories", stories);
    }
    public IActionResult FilterOldest()
    {
        var stories = _storyRepo.GetStories()
            .OrderBy(s => s.StoryDate)
            .ToList();
        
        return View("Stories", stories);
    }

    public IActionResult ViewComments(int storyId)
    {
        Story story = _storyRepo.GetStoryById(storyId);
        List<Comment> comments = _commentRepo.GetCommentsByStoryId(storyId);
        
        var tuple = new Tuple<Story,List<Comment>>(story,comments);
        return View("StoryDetailed", tuple);
    }

    public IActionResult DeleteStory(int storyId)
    {
        //First, delete comments attached to story
        List<Comment> comments = _commentRepo.GetCommentsByStoryId(storyId);
        _commentRepo.DeleteComments(comments);
        
        //Next, delete desired story
        _storyRepo.DeleteStory(storyId);

        //since in detailed view, return user to main story page after deletion
        List<Story> stories = _storyRepo.GetStories();
        return RedirectToAction("stories", stories);
    }
    
    [HttpPost]
    public async Task<IActionResult> Stories(Story model)
    {
        //AppUser user1 = new AppUser() { AccountAge = DateOnly.FromDateTime(DateTime.Now), UserName = "Test" };
        model.StoryAuthor = await _userManager.GetUserAsync(User);
        
        if (_storyRepo.StoreStoryAsync(model).Result > 0)
        {
            return View( _storyRepo.GetStories());
        }
        else
        {
            ViewBag.ErrorMessage = "There was an error saving the story.";
            return View();
        }
    }
    
    [HttpPost]
    public async Task<IActionResult> Comment(Comment model, int storyId)
    {
        model.Author = await _userManager.GetUserAsync(User);
        
        if (_commentRepo.StoreCommentAsync(model).Result > 0)
        {
            Story story = _storyRepo.GetStoryById(storyId);
            List<Comment> comments = _commentRepo.GetCommentsByStoryId(storyId);
        
            var tuple = new Tuple<Story,List<Comment>>(story,comments);
            
            return View("StoryDetailed", tuple);
        }
        else
        {
            ViewBag.ErrorMessage = "There was an error saving the Comment.";
            return View();
        }
    }
}

