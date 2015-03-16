using System;
namespace Kcs.Cleaning.DAL.Entities
{

    public class Request
    {
        public int RequestId { get; set; }
        public DateTime RequestDate { get; set; }
        public int UserId { get; set; }
        public int ServiceId { get; set; }

    }
        
}

