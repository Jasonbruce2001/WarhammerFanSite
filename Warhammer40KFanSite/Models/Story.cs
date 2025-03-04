using System.ComponentModel.DataAnnotations;

namespace Warhammer40KFanSite.Models;

public class Story
{
    public int StoryID { get; set; }
    
    [StringLength(30, MinimumLength = 3)]
    [Required(ErrorMessage = "You must enter a title.")]
    public string StoryTitle { get; set; }
    
    [StringLength(30, MinimumLength = 3)]
    [Required(ErrorMessage = "You must enter a topic.")]
    public string StoryTopic { get; set; }
    
    [StringLength(1000, MinimumLength = 10)]
    [Required(ErrorMessage = "Story text is required.")]
    public string StoryText { get; set; }
    public AppUser StoryAuthor { get; set; }
    public DateTime StoryDate { get; set; }
}