using Microsoft.AspNetCore.Identity;
using Warhammer40KFanSite.Data;
using Warhammer40KFanSite.Models;

namespace Warhammer40KFanSite;

public class SeedData
{
    public static void Seed(ApplicationDbContext context, IServiceProvider provider)
    {
        var userManager = provider
            .GetRequiredService<UserManager<AppUser>>();
        
        if (!context.Stories.Any())  // this is to prevent adding duplicate data
        {
            // Create User objects
            const string SECRET_PASSWORD = "Pass!123";
            AppUser jasonBruce = new AppUser { UserName = "Jason Bruce" };
            var result = userManager.CreateAsync(jasonBruce, SECRET_PASSWORD);
            
            AppUser wyattQualiana = new AppUser { UserName = "Wyatt Qualiana" };
            result = userManager.CreateAsync(wyattQualiana, SECRET_PASSWORD);
             
            //create object literals for stories
            Story story1 = new Story() { StoryTitle = "Painting Marines", StoryTopic = "Seeded Topic 1", StoryAuthor = jasonBruce, StoryText = "akjsdflkjasldjf", StoryDate = DateTime.Now};
            Story story2 = new Story() { StoryTitle = "Beginners Airbrush Tutorial", StoryTopic = "Seeded Topic 2", StoryAuthor = wyattQualiana, StoryText = "asdflkajsdfsdf", StoryDate = DateTime.Now};
            
            // Save stories to db context
            context.Stories.Add(story1);
            context.Stories.Add(story2);
            context.SaveChanges(); 
        }
    }
}
