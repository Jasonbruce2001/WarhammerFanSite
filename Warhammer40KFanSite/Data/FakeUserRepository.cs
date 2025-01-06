using Warhammer40KFanSite.Models;

namespace Warhammer40KFanSite.Data;

public class FakeUserRepository
{
    public class FakeUser : IUserRepository
    {
        private List<User> Users { get; set; } = new List<User>();
        
        public List<User> GetUsers()
        {
            return Users;
        }

        public User GetUserById(int id)
        {
            return Users[id];
        }

        public int StoreUser(User model)
        {
            int status = 0;
            
            if (model != null)
            {
                model.UserId = Users.Count + 1;
                Users.Add(model);
                status = 1;
            }

            return status;
        }
    }
}