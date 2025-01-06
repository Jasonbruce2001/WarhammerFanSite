namespace Warhammer40KFanSite.Models;

public class User
{
    public int UserId { get; set; }
    public string Username { get; set; }
    public DateOnly AccountAge { get; set; }
}