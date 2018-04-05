using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Messenger.Core.Models;

namespace Messenger.Core.DAL
{
    public class MessengerContext : DbContext
    {
        public MessengerContext()
            : base("DbConnection")
        {
            
        }

        public DbSet<Chat> Chats { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<MessageType> MessageTypes { get; set; }
        public DbSet<User> Users { get; set; }
    }

    public class DbInitializer : CreateDatabaseIfNotExists<MessengerContext>
    {
        protected override void Seed(MessengerContext db)
        {
            db.SaveChanges();
        }
    }
}
