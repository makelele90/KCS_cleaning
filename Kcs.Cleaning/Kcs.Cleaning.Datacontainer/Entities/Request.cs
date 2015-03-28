using System;

namespace Kcs.Cleaning.Datacontainer.Entities
{

    public class Request
    {
        public virtual int Id { get; set; }
        public virtual DateTime RequestDate { get; set; }
        public virtual Service Service { get; set; }
        public virtual User User { get; set; }

    }
        
}

