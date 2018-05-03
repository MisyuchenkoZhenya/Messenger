using Messenger.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Messenger.Web.Models
{
    public class ChatContactViewModel
    {
        public IEnumerable<ChatDTO> chats { get; set; }
        public IEnumerable<UserDTO> users { get; set; }
    }
}