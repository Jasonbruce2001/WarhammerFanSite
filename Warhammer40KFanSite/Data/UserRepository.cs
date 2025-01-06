using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Warhammer40KFanSite.Data;
using Warhammer40KFanSite.Models;

namespace Warhammer40KFanSite.Data;

public class UserRepository : IUserRepository
{
    private ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext appDbContext)
    {
        _context = appDbContext;
    }

    public List<User> GetUsers()
    {
        return _context.Users
            .ToList();
    }

    public User GetUserById(int id)
    {
        var user = _context.Users
            .Where(user => user.UserId == id)
            .SingleOrDefault();
        return user;
    }
   
    public int StoreUser(User model)
    {
        model.AccountAge = DateOnly.MaxValue;
        _context.Users.Add(model);
        return _context.SaveChanges();
        // returns a positive value if succussful
    }
}
