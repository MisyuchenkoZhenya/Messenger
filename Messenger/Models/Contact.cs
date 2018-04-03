using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Models
{
    class Contact
    {
        public User Owner { get; set; }

        public User Target { get; set; }

        public ContactStatus Status { get; set; }
    }
}
