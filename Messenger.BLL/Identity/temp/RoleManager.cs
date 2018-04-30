using Messenger.DAL.Context;
using Messenger.DAL.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.BLL.Identity
{
    class RoleManager : RoleManager<Role>
    {
        public RoleManager(IRoleStore<Role> store)
            : base(store)
        { }

        public static RoleManager Create(
            IdentityFactoryOptions<RoleManager> options, IOwinContext context)
        {
            var manager = new RoleManager(
                new RoleStore<Role>(context.Get<MessengerContext>()));
            

            return manager;
        }
    }
}
