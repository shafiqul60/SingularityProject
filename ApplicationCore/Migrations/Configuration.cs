namespace ApplicationCore.Migrations
{
    using DomainModels.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationCore.DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationCore.DatabaseContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            Role r1 = new Role { Name = "Admin", Description = "Administrator" };
            Role r2 = new Role { Name = "User", Description = "End User" };

            User u1 = new User
            {
                UserName = "Admin",
                Password = "123456",
                FullName = "Admin",
                PhoneNumber = "987654321",
                Address = "Dhanmondi",
                Email = "admin@gamil.com"

            };

            User u2 = new User
            {
                UserName = "User",
                Password = "123456",
                FullName = "User",
                PhoneNumber = "987654321",
                Address = "Taltola",
                Email = "user@gamil.com"
            };

            u1.Roles.Add(r1);
            u2.Roles.Add(r2);

            context.Users.Add(u1);
            context.Users.Add(u2);
        }
    }
}
