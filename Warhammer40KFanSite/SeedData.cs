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
            DateOnly date = DateOnly.FromDateTime(DateTime.Now);
            const string SECRET_PASSWORD = "Pass!123";
            AppUser jasonBruce = new AppUser { UserName = "Jason Bruce", AccountAge = date};
            var result = userManager.CreateAsync(jasonBruce, SECRET_PASSWORD);
            
            AppUser wyattQualiana = new AppUser { UserName = "Wyatt Qualiana", AccountAge = date};
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
    
    public static async Task CreateAdminUser(IServiceProvider serviceProvider) 
    {
        UserManager<AppUser> userManager =
            serviceProvider.GetRequiredService<UserManager<AppUser>>(); 
        RoleManager<IdentityRole> roleManager =
            serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        
        string username = "Administrator"; 
        string password = "Pass1234!"; 
        string roleName = "Admin";
        DateOnly date = DateOnly.FromDateTime(DateTime.Now);
        
        // if role doesn't exist, create it
        if (await roleManager.FindByNameAsync(roleName) == null) 
        { 
            await roleManager.CreateAsync(new IdentityRole(roleName));
        }
        // if username doesn't exist, create it and add it to role
        if (await userManager.FindByNameAsync(username) == null) 
        { 
            AppUser user = new AppUser { UserName = username, AccountAge = date}; 
            var result = await userManager.CreateAsync(user, password); 
            if (result.Succeeded) {
                await userManager.AddToRoleAsync(user, roleName); 
            }
        } 
    }
}
