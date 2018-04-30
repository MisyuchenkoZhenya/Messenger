using Messenger.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.BLL.DatabaseInitializer
{
    public static class DatabaseInitializer
    {
        public static void Initialize()
        {
            using (MessengerContext db = new MessengerContext())
            {
                db.Database.Initialize(false);
                db.SaveChanges();
            }
        }
    }
}
