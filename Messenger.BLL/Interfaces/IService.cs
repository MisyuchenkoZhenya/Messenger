﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messenger.DAL.Interfaces;

namespace Messenger.BLL.Interfaces
{
    interface IService
    {
        IUnitOfWork Database { get; set; }

        void Dispose();
    }
}
