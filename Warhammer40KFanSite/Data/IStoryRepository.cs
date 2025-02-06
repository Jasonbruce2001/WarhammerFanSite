using Warhammer40KFanSite.Models;

namespace Warhammer40KFanSite.Data;

public interface IStoryRepository
{
    public List<Story> GetStories();
    public Story GetStoryById(int id);

    //asynchronous versions
    public Task<int> StoreStoryAsync(Story model);  
}