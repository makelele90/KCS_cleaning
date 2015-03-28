namespace Kcs.Cleaning.DAL.Migrations
{
    using Kcs.Cleaning.Datacontainer.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Kcs.Cleaning.DAL.KcsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Kcs.Cleaning.DAL.KcsContext context)
        {
            var users = new List<User>()
            {
                new User(){Username="admin",Password="123456",PasswordSalt="123456",
                    CreatedOn=DateTime.UtcNow,UpadtedOn=DateTime.UtcNow,IsActive=true,IsPaswordLocked=false}

            };

            context.Users.AddRange(users);
            base.Seed(context);
        }
    }
}
