using Warhammer40KFanSite.Models;

namespace Warhammer40KFanSite.Data;

public interface IUserRepository
{
    public List<User> GetUsers();
    public User GetUserById(int id); // Returns a model object
    public int StoreUser(User model);   
}