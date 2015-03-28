using System.Collections.Generic;
namespace Kcs.Cleaning.Datacontainer.Entities
{

    public class Role
    {
        public Role()
        {
            Users = new List<User>();
        }
        public virtual int Id { get; set; }
        public virtual string Description { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }

}

