using Warhammer40KFanSite.Data;
using Warhammer40KFanSite.Models;

namespace Warhammer40KFanSite;

public class SeedData
{
    public static void Seed(ApplicationDbContext context)
    {
        if (!context.Stories.Any())  // this is to prevent adding duplicate data
        {
            // Create User objects
            User user1 = new User() { AccountAge = DateOnly.FromDateTime(DateTime.Now), Username = "Emma Watson" };
            User user2 = new User() { AccountAge = DateOnly.FromDateTime(DateTime.Now), Username = "Brian Bird" };
            //save users to DB
            context.Users.Add(user1);
            context.Users.Add(user2);
            context.SaveChanges();
            
            //create object literals for stories
            Story story1 = new Story() { StoryTitle = "Painting Marines", StoryTopic = "Seeded Topic 1", StoryAuthor = user1, StoryText = "akjsdflkjasldjf", StoryDate = DateTime.Now};
            Story story2 = new Story() { StoryTitle = "Beginners Airbrush Tutorial", StoryTopic = "Seeded Topic 2", StoryAuthor = user2, StoryText = "asdflkajsdfsdf", StoryDate = DateTime.Now};
            
            // Save stories to db context
            context.Stories.Add(story1);  
            context.Stories.Add(story2);
            context.SaveChanges(); 
        }
    }
}
