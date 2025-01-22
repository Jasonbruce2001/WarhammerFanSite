using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Warhammer40KFanSite.Models;

public class AppUser : IdentityUser
{
    [NotMapped]
    public IList<string> RoleNames { get; set; }
    
    public DateOnly AccountAge { get; set; }
}