using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Messenger.DAL.Models
{
    public class Message
    {
        public int Id { get; set; }
        public User Author { get; set; }
        public string Content { get; set; }
        public MessageType Type { get; set; }
        public DateTime CreatedAt { get; set; }
        public Chat Chat { get; set; }
    }
}
