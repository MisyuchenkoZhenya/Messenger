using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messenger.DAL.Models;

namespace Messenger.BLL.DTO
{
    public class FullChatDTO
    {
        public int Id { get; set; }
        public int AdminId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Title { get; set; }
        public string PhotoUrl { get; set; }
        public bool IsPrivate { get; set; }

        public IEnumerable<UserDTO> Participants { get; set; }
        public IEnumerable<MessageDTO> Messages { get; set; }
    }
}
