using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Models
{
    class ContactStatus
    {
        public int Id { get; set; }

        public string Status { get; set; }


        public ICollection<Contact> Contacts { get; set; }
    }
}
