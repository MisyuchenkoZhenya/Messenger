using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Models
{
    class ChatParticipant
    {
        public Chat Chat { get; set; }
        
        public User User { get; set; }

        public bool IsAdmin { get; set; }
    }
}
