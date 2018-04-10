﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messenger.DAL.Models;

namespace Messenger.DAL.Interfaces
{
    interface IUserRepository : IRepository<User>
    {
        IQueryable<User> GetUsersByChatId(int Id);
        IQueryable<User> GetUsersByContactId(int Id);
    }
}
