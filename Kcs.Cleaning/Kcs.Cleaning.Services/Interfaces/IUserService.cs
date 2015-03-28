using System.Collections.Generic;
using Kcs.Cleaning.Datacontainer.Entities;

namespace Kcs.Cleaning.Services.Interfaces
{
    public interface IUserService
    {
        bool Login(string username, string password);
        IEnumerable<User> FindAll();
        User Find(string username);
        User GetSingle(int id);
        bool CreateUser(User userData);
        bool UpdateUser(User userData);
        bool RemoveUser(int id);

    }
}
