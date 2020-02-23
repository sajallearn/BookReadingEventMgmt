namespace DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using DAL.Entity;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.BookReadingEventManagementContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.BookReadingEventManagementContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            User User = new User();
            User.UserID = 1;
            User.Password = "Admin";
            User.FullName = "Admin";
            User.IsAdmin = true;
            User.Email = "myadmin@bookevents.com";
            context.Users.Add(User);
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
