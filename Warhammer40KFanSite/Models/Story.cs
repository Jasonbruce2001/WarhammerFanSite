using System.ComponentModel.DataAnnotations;

namespace Warhammer40KFanSite.Models;

public class Story
{
    public int StoryID { get; set; }
    
    [StringLength(30, MinimumLength = 3)]
    [Required]
    public string StoryTitle { get; set; }
    
    [StringLength(30, MinimumLength = 3)]
    [Required]
    public string StoryTopic { get; set; }
    
    [StringLength(500, MinimumLength = 10)]
    [Required]
    public string StoryText { get; set; }
    public AppUser StoryAuthor { get; set; }
    public DateTime StoryDate { get; set; }
}