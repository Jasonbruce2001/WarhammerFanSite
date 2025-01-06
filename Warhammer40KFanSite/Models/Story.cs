namespace Warhammer40KFanSite.Models;

public class Story
{
    public int StoryID { get; set; }
    public string StoryTitle { get; set; }
    public string StoryTopic { get; set; }
    public User StoryAuthor { get; set; }
    public string StoryText { get; set; }
    public DateTime StoryDate { get; set; }
}