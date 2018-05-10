using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.BLL.DTO
{
    public class ChatDTO
    {
        public int Id { get; set; }

        public string AdminId { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; }

        [Required]
        [MaxLength(16)]
        public string Title { get; set; }

        [DataType(DataType.ImageUrl)]
        public string PhotoUrl { get; set; }

        [Required]
        public bool IsPrivate { get; set; }
    }

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
