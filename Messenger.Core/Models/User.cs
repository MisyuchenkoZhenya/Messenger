using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace Messenger.Core.Models
{
    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Password { get; set; }


        public ICollection<Chat> Chats { get; set; }

        public ICollection<Message> Messages { get; set; }

        public ICollection<User> Contacts { get; set; }
    }
}
