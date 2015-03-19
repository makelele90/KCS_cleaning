using System.Collections.Generic;
using Kcs.Cleaning.Datacontainer.Entities;
using Kcs.Cleaning.DAL.Repository;
using Kcs.Cleaning.Services.Interfaces;
using Kcs.Cleaning.Utility;

namespace Kcs.Cleaning.Services.Classes
{
    public class AuthenticationService : IAuthenticationService
  {
    private readonly IRepository<User> _userRepository;

    public AuthenticationService(IRepository<User> userRepository)
    {
      _userRepository = userRepository;
    }

    public bool Login(string username, string password)
    {
     //check if user with user name is available in database
     var user = _userRepository.Single(u => u.Username == username);

      if (user != null)
      {
        //create a hash of the password
        var passwordHash = PasswordHash.CreateHash(password, user.PasswordSalt);

        user = _userRepository.Single(u => u.Username == username && u.Password == passwordHash);

      }
     

      return user != null;
    }

    public IEnumerable<User> FindAll()
    {
      return _userRepository.FindAll();
    }

    public User Find(string username)
    {
      return _userRepository.Single(u => u.Username == username);
    }

    public User GetSingle(int id)
    {
      return _userRepository.Single(u => u.UserId == id);
    }

    public bool CreateUser(User user)
    {
      var passwordSalt = PasswordHash.GenerateHexSaltString();
      var hashedPassword = PasswordHash.CreateHash(user.Password, passwordSalt);

      user.PasswordSalt = passwordSalt;
      user.Password = hashedPassword;

      var result = _userRepository.Create(user);

      return result.Status;
    }

    public bool UpdateUser(User user)
    {
      var result = _userRepository.Update(user);

      return result.Status;
    }

    public bool RemoveUser(int id)
    {
      var user = _userRepository.Single(u => u.UserId == id);
      
      var result = _userRepository.Delete(user);

      return result.Status;
    }
  }
}
