using Warhammer40KFanSite.Models;

namespace Warhammer40KFanSite.Data;

public class FakeStoryRepository: IStoryRepository
{
        public List<Story> Stories { get; set; } = new List<Story>();
        
        public List<Story> GetStories()
        {
            return Stories;
        }

        public Story GetStoryById(int id)
        {
            return  Stories[id];
        }

        public int StoreStory(Story model)
        {
            int status = 0;
            
            if (model != null)
            {
                model.StoryID = Stories.Count + 1;
                Stories.Add(model);
                status = 1;
            }

            return status;
        }
        
        //async methods
        public async Task<List<Story>> GetStoriesAsync()
        {
            return await Task.FromResult(Stories);
        }

        public async Task<Story> GetStoryByIdAsync(int id)
        {
            return await Task.FromResult(Stories[id]);
        }

        public async Task<int> StoreStoryAsync(Story model)
        {
            int status = 0;
            
            if (model != null)
            {
                model.StoryID = Stories.Count + 1;
                Stories.Add(model);
                status = 1;
            }

            return status;
        }

        public int DeleteStory(int id)
        {
            throw new NotImplementedException();
        }
}