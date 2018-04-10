﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messenger.DAL.Interfaces;
using Messenger.DAL.Context;

namespace Messenger.DAL.Repository
{
    class MessageRepository : IMessageRepository
    {
        private MessengerContext db;

        public MessageRepository()
        {
            db = new MessengerContext();
        }
    }
}
