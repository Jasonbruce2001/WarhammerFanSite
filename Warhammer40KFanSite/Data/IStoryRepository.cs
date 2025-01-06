using Warhammer40KFanSite.Models;

namespace Warhammer40KFanSite.Data;

public interface IStoryRepository
{
    public List<Story> GetStories();
    public Story GetStoryById(int id); // Returns a model object
    public int StoreStory(Story model);   
}