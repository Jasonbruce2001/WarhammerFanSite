using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Warhammer40KFanSite.Models;

namespace Warhammer40KFanSite;

public class ApplicationDbContext : IdentityDbContext
{
    // constructor just calls the base class constructor
    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options) : base(options) { }
    
    // one DbSet for each domain model class
    public DbSet<Story> Stories { get; set; }
    public DbSet<Comment> Comments { get; set; }
}