using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messenger.BLL.DTO;
using Messenger.BLL.Interfaces;
using Messenger.DAL.Interfaces;
using Messenger.DAL.Models;
using AutoMapper;

namespace Messenger.BLL.Services
{
    public class MessageService : IMessageService
    {
        public IUnitOfWork Database { get; set; }

        public MessageService(IUnitOfWork unitOfWork)
        {
            Database = unitOfWork;
        }

        public void DeleteMessage(int messageId)
        {
            Database.Messages.Delete(messageId);
            Database.Save();
        }

        public IEnumerable<MessageDTO> GetMessages(int chatId)
        {
            var messages = Database.Chats.GetWithInclude(chatId, c => c.Messages).Messages;
            Mapper.Initialize(cfg => cfg.CreateMap<Message, MessageDTO>()
                                        .ForMember("Author", opt => opt.MapFrom(m => m.Author.GetFullName()))
                                        .ForMember("Type", opt => opt.MapFrom(m => m.Type.Type)));
            var messagesDto = Mapper.Map<ICollection<Message>, List<MessageDTO>>(messages);

            return messagesDto;
        }

        public void SendMedia(MessageDTO message)
        {
            throw new NotImplementedException();
        }

        public void SendMessage(MessageDTO message)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
