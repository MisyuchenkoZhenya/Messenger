using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Models
{
    class Chat
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Title { get; set; }

        public string Photo { get; set; }

        public bool IsPrivate { get; set; }


        public ICollection<ChatParticipant> Participants { get; set; }

        public ICollection<Message> Messages { get; set; }
    }
}
