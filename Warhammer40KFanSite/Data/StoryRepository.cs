using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Warhammer40KFanSite.Data;
using Warhammer40KFanSite.Models;

namespace Warhammer40KFanSite.Data;

public class StoryRepository : IStoryRepository
{
    private ApplicationDbContext _context;

    public StoryRepository(ApplicationDbContext appDbContext)
    {
        _context = appDbContext;
    }

    public List<Story> GetStories()
    {
        return _context.Stories
            .Include(story => story.StoryAuthor)    
            .ToList();
    }

    public Story GetStoryById(int id)
    {
        var story = _context.Stories
            .Include(story => story.StoryAuthor)    
            .Where(story => story.StoryID == id)
            .SingleOrDefault();
        return story;
    }
   
    public int StoreStory(Story model)
    {
        model.StoryDate = DateTime.Now;
        _context.Stories.Add(model);
        return _context.SaveChanges();
        // returns a positive value if succussful
    }
}