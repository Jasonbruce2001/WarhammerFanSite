using Microsoft.AspNetCore.Identity;

namespace Warhammer40KFanSite.Models;

public class AppUser : IdentityUser
{
    public DateOnly AccountAge { get; set; }
}