using System;
using System.Collections.Generic;
using System.Data.Entity;
using Kcs.Cleaning.Datacontainer.Entities;
using Kcs.Cleaning.DAL;

namespace Kcs.Cleaning.DAL
{
    public class KcsContext : DbContext
    {
        public KcsContext()
            : base("KcsConnectionString")
        {

            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<KcsContext, Configuration>("KcsConnectionString"));
            //This is used to migrate the database to the latest version
            //Database.SetInitializer<KcsContext>(new MigrateDatabaseToLatestVersion());
            Database.SetInitializer<KcsContext>(null);

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Role> Roles { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
