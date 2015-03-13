using System;
namespace Kcs.Cleaning.DAL.Entities
{

    public class Profile
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public User User { get; set; }
    }

}

