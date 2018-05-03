using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Messenger.DAL.Models;

namespace Messenger.DAL.Context
{
    public class DbInitializer : DropCreateDatabaseIfModelChanges<MessengerContext>
    {
        protected override void Seed(MessengerContext db)
        {
            MessageType type1 = new MessageType { Type = "Text" };
            MessageType type2 = new MessageType { Type = "Image" };

            User user1 = new User
            {
                FirstName = "Sam",
                LastName = "Owen",
                PasswordHash = "Qwerty",
                PhoneNumber = "23423423",
                Email = "SOSOSO@mail.ru"
            };
            User user2 = new User
            {
                FirstName = "Karl",
                LastName = "Lrak",
                PasswordHash = "Qazwsx",
                PhoneNumber = "111111111",
                Email = "KkkLll@mail.ru",
                Contacts = new List<User>() { user1 }
            };

            Chat chat1 = new Chat
            {
                CreatedAt = DateTime.Now,
                Admin = user1,
                IsPrivate = true,
                PhotoUrl = "/someUrl",
                Title = "FirstChat",
                Participants = new List<User> { user1, user2 }
            };


            db.MessageTypes.Add(type1);
            db.MessageTypes.Add(type2);

            db.Users.Add(user1);
            db.Users.Add(user2);

            db.Chats.Add(chat1);

            db.Messages.Add(new Message { Author = user1, Chat = chat1, Type = type1, Content = "Hello", CreatedAt = DateTime.Now });
            db.Messages.Add(new Message { Author = user1, Chat = chat1, Type = type1, Content = "world", CreatedAt = DateTime.Now });
            db.Messages.Add(new Message { Author = user2, Chat = chat1, Type = type1, Content = "Hi", CreatedAt = DateTime.Now });

            db.SaveChanges();
        }
    }
}
