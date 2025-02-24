namespace Warhammer40KFanSite.Models;

public class Comment
{
    public int Id { get; set; }         //id of comment
    public int StoryId { get; set; }    //id of story comment is related to
    public AppUser Author { get; set; }
    public string Content { get; set; }
    public DateTime DatePosted { get; set; }
}