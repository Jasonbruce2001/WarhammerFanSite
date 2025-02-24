using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Warhammer40KFanSite.Data;
using Warhammer40KFanSite.Models;

namespace Warhammer40KFanSite.Data;

public class StoryRepository : IStoryRepository
{
    private readonly ApplicationDbContext _context;

    public StoryRepository(ApplicationDbContext appDbContext)
    {
        _context = appDbContext;
    }
    
    //Synchronous because of where clauses  
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
   
    //async methods
    public async Task<int> StoreStoryAsync(Story model)
    {
        model.StoryDate = DateTime.Now;
        _context.Stories.Add(model);
        
        Task<int> task = _context.SaveChangesAsync();
        int result = await task;
        return result; // returns a positive value if successful
    }
    
    public int DeleteStory(int id)
    {
        Story story = GetStoryById(id);
        _context.Stories.Remove(story);
        
        return _context.SaveChanges();
    }
}