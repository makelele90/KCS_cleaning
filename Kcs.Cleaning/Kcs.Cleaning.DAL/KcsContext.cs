using System;
using System.Collections.Generic;
using System.Data.Entity;
using Kcs.Cleaning.Datacontainer.Entities;

namespace Kcs.Cleaning.DAL
{
    public class KcsContext : DbContext
    {
        public KcsContext()
            : base("KcsConnectionString")
        {
            /* Database.SetInitializer<KcsContext>(new BlogDbInitializer());
           Database.SetInitializer(new MigrateDatabaseToLatestVersion<KcsContext, Configuration>("KcsConnectionString"));*/
            Database.SetInitializer<KcsContext>(null);

        }

        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            

        }
    }
}
