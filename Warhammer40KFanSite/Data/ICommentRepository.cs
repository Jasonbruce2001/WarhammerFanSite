using Warhammer40KFanSite.Models;

namespace Warhammer40KFanSite.Data;

public interface ICommentRepository
{
    public List<Comment> GetCommentsByStoryId(int id);
    public Comment GetCommentById(int id);
    public Task<int> StoreCommentAsync(Comment c); //need to make async
}