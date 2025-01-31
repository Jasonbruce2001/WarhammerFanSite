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

    /* OLD - Synchronous methods, delete when finished
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
    }*/
    
    //async methods
    public List<Story> GetStories()
    {
        return _context.Stories
            .Include(story => story.StoryAuthor)    
            .ToList();
    }

    public Story GetStoryById(int id)
    {
        if (_context.Stories.Any())
        {
            var story = _context.Stories    
                .Include(story => story.StoryAuthor)
                .SingleOrDefault(story => story.StoryID == id);
            return story;
        }
        
        return new Story();
    }
   
    public async Task<int> StoreStoryAsync(Story model)
    {
        model.StoryDate = DateTime.Now;
        _context.Stories.Add(model);
        
        Task<int> task = _context.SaveChangesAsync();
        int result = await task;
        return result; // returns a positive value if succussful
    }
}