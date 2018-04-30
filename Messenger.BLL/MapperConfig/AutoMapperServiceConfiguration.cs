﻿using AutoMapper;
using Messenger.BLL.DTO;
using Messenger.DAL.Models;

namespace Messenger.BLL.MapperConfig
{
    public static class AutoMapperServiceConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                ConfigureChatMapping(cfg);
                ConfigureMessageMapping(cfg);
                ConfigureUserMapping(cfg);
            });
        }

        private static void ConfigureChatMapping(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<ChatDTO, Chat>();
            cfg.CreateMap<Chat, ChatDTO>()
                    .ForMember("AdminId", opt => opt.MapFrom(c => c.Admin.Id));
            cfg.CreateMap<Chat, FullChatDTO>()
                    .ForMember("AdminId", opt => opt.MapFrom(c => c.Admin.Id));
        }

        private static void ConfigureMessageMapping(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Message, MessageDTO>()
                    .ForMember("Author", opt => opt.MapFrom(m => m.Author.GetFullName()))
                    .ForMember("Type", opt => opt.MapFrom(m => m.Type.Type));
        }

        private static void ConfigureUserMapping(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<User, UserDTO>();
            cfg.CreateMap<UserAccountDTO, User>();
            cfg.CreateMap<UserDTO, User>();
        }
    }
}
