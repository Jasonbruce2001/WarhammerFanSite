using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Warhammer40KFanSite.Models;
using Warhammer40KFanSite.QuizModel;

namespace Warhammer40KFanSite;

public class ApplicationDbContext : IdentityDbContext
{
    // constructor just calls the base class constructor
    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options) : base(options) { }
  
    //seeding roles
    
    
    // one DbSet for each domain model class
    public DbSet<Quiz> Quizzes { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Story> Stories { get; set; }
}