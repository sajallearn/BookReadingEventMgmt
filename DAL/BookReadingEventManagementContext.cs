using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

using DAL.Entity;

namespace DAL
{
    public class BookReadingEventManagementContext:DbContext
    {
        public BookReadingEventManagementContext() : base("BookReadingEventManagementContext")
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Invite> Invites { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }

   
}
