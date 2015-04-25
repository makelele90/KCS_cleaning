using System.Collections.Generic;
using Kcs.Cleaning.Datacontainer.DTO;
using Kcs.Cleaning.Datacontainer.Entities;

namespace Kcs.Cleaning.Services.Interfaces
{
    public interface IUserService
    {
        bool Login(string username, string password);
        IEnumerable<User> FindAll();
        User Find(string username);
        User GetSingle(int id);
        bool CreateUser(UserDto userData);
        bool UpdateUser(UserDto userData);
        bool RemoveUser(int id);

    }
}
