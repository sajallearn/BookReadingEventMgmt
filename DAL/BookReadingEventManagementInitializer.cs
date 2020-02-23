using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

using DAL.Entity;

namespace DAL
{
    public class BookReadingEventManagementInitializer:DropCreateDatabaseAlways<BookReadingEventManagementContext>
    {
        protected override void Seed(BookReadingEventManagementContext context)
        {
            User User = new User();
            User.UserID =  1;
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
