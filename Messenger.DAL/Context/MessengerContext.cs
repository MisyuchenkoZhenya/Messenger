﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Messenger.DAL.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Messenger.DAL.Context
{
    public class MessengerContext : IdentityDbContext<User>
    {
        static MessengerContext()
        {
            Database.SetInitializer(new DbInitializer());
        }

        public MessengerContext()
            : base("DbConnection")
        { }

        public DbSet<Chat> Chats { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<MessageType> MessageTypes { get; set; }
        //public DbSet<User> Users { get; set; }
        //public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chat>()
                        .HasMany(c => c.Participants)
                        .WithMany(u => u.Chats)
                        .Map(cu =>
                        {
                            cu.MapLeftKey("Chat_Id");
                            cu.MapRightKey("Participant_Id");
                            cu.ToTable("ChatToParticipant");
                        });

            modelBuilder.Entity<User>()
                        .HasMany(u => u.Contacts)
                        .WithMany()
                        .Map(u =>
                        {
                            u.MapLeftKey("User_Id");
                            u.MapRightKey("Contact_Id");
                            u.ToTable("UserToContact");
                        });
        }
    }
}
