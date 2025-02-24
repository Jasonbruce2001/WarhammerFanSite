using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Warhammer40KFanSite.Controllers;
using Warhammer40KFanSite.Data;
using Warhammer40KFanSite.Models;

namespace FakeStoryRepoTests
{
    public class FakeStoryRepoTests
    {
        readonly IStoryRepository _repo = new FakeStoryRepository();
        readonly HomeController _controller;
        readonly UserManager<AppUser> _userManager;
        readonly SignInManager<AppUser> _signInManager;
        readonly Story _story = new Story();
        
        public FakeStoryRepoTests()
        {
            //_controller = new HomeController(_userManager, _signInManager, _repo);
        }

        [Fact]
        public void Story_PostTest_Success()
        {
            _story.StoryDate = DateTime.Now;
            _story.StoryTitle = "Test Story Title";
            Task<IActionResult> result = _controller.Stories(_story);
            
            Assert.True(result.GetType() == typeof(Task<IActionResult>));
        }


        [Fact]
        public void Review_PostTest_Failure()
        {
            Task<IActionResult> result = _controller.Stories(_story);
            
            Assert.True(result.GetType() == typeof(Task<IActionResult>));
        }
    }
}