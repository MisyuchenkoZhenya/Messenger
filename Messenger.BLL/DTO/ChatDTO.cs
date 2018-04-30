using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.BLL.DTO
{
    public class ChatDTO
    {
        public int Id { get; set; }
        public string AdminId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Title { get; set; }
        public string PhotoUrl { get; set; }
        public bool IsPrivate { get; set; }
    }
}
