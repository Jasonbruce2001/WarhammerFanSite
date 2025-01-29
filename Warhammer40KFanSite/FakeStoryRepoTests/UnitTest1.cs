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
        readonly Story _story = new Story();

        public FakeStoryRepoTests()
        {
            //_controller = new HomeController(_repo);
        }

        [Fact]
        public void Story_PostTest_Success()
        {
            _story.StoryDate = DateTime.Now;
            IActionResult result = _controller.Stories(_story);
            
            Assert.True(result.GetType() == typeof(ViewResult));
        }


        [Fact]
        public void Review_PostTest_Failure()
        {
            IActionResult result = _controller.Stories(_story);
            
            Assert.True(result.GetType() == typeof(ViewResult));
        }
    }
}