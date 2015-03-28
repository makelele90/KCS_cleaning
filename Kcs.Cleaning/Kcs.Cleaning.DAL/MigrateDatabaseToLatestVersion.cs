using Kcs.Cleaning.Datacontainer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Kcs.Cleaning.DAL
{
    public class MigrateDatabaseToLatestVersion : DropCreateDatabaseAlways<KcsContext>
    {
        protected override void Seed(KcsContext context)
        {
            var users = new List<User>()
            {
                new User(){Username="admin",Password="123456",PasswordSalt="123456",
                    CreatedOn=DateTime.UtcNow,UpadtedOn=DateTime.UtcNow,IsActive=true,IsPaswordLocked=false}

            };
            base.Seed(context);
        }
    }
}
