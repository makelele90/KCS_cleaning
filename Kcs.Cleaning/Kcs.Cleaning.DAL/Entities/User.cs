using System;
namespace Kcs.Cleaning.DAL.Entities
{

    public class User
    {
        public virtual int UserId { get; set; }
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
        public virtual string PasswordSalt { get; set; }
        public virtual DateTime CreatedOn { get; set; }
        public virtual DateTime LastUpadted { get; set; }
        public virtual DateTime LastLogin { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual bool IsPaswordLocked { get; set; }
        public virtual Profile Profile { get; set; }
    }

}

