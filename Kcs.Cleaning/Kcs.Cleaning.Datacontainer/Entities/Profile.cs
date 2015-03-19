namespace Kcs.Cleaning.Datacontainer.Entities
{

    public class Profile
    {
        public virtual int UserId { get; set; }
        public virtual string Email { get; set; }
        public virtual User User { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual int Age { get; set; }
    }

}

