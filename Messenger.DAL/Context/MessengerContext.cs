using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Messenger.DAL.Models;

namespace Messenger.DAL.Context
{
    public class MessengerContext : DbContext
    {
        public MessengerContext()
            : base("DbConnection")
        { }

        public DbSet<Chat> Chats { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<MessageType> MessageTypes { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chat>()
                        .HasMany(c => c.Participants)
                        .WithMany(u => u.Chats)
                        .Map(cu =>
                        {
                            cu.MapLeftKey("Chat_Id");
                            cu.MapRightKey("Participant_Id");
                            cu.ToTable("ChatParticipant");
                        });
        }
    }
}
