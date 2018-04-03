﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Models
{
    class MessageType
    {
        public int Id { get; set; }

        public string Type { get; set; }


        public ICollection<Message> Messages { get; set; }
    }
}
