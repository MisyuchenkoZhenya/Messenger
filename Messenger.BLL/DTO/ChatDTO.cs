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

        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; }

        [Required]
        [MaxLength(16)]
        public string Title { get; set; }

        [DataType(DataType.ImageUrl)]
        [RegularExpression(@"([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg|.gif)$", ErrorMessage = "Only Image files allowed.")]
        public string PhotoUrl { get; set; }

        public bool IsPrivate { get; set; }


        public static ChatDTO CreateDefault(string admin)
        {
            DateTime dateTime = DateTime.Now;

            return new ChatDTO
            {
                AdminId = admin,
                CreatedAt = dateTime,
                Title = $"Default({dateTime})",
                IsPrivate = true
            };
        }
    }

    public class FullChatDTO : ChatDTO
    {
        public IEnumerable<UserDTO> Participants { get; set; }
        public IEnumerable<MessageDTO> Messages { get; set; }
    }
}
