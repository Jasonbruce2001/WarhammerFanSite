using Microsoft.EntityFrameworkCore;
using Warhammer40KFanSite.Models;

namespace Warhammer40KFanSite.Data;

public class CommentRepository : ICommentRepository
{
    private ApplicationDbContext _context;

    public CommentRepository(ApplicationDbContext appDbContext)
    {
        _context = appDbContext;
    }
    
    public List<Comment> GetCommentsByStoryId(int id)
    {
        return _context.Comments.Where(c => c.StoryId == id)
                                .Include(c => c.Author)
                                .ToList();
    }

    public Comment GetCommentById(int id)
    {
        return _context.Comments.Find(id);
    }

    public async Task<int> StoreCommentAsync(Comment c)
    {
        c.DatePosted = DateTime.Now;
        _context.Comments.Add(c);
        
        Task<int> task = _context.SaveChangesAsync();
        int result = await task;
        return result; // returns a positive value if succussful
    }

    public int DeleteComments(List<Comment> comments)
    {
        _context.Comments.RemoveRange(comments);
        return _context.SaveChanges();
    }
}
