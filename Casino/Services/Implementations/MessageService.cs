using Casino.Models.Contact;
using Casino.Services.Interfaces;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Casino.Services.Implementations
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        public MessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public bool Add(ContactViewModel model)
        {
            _messageRepository.Insert(new DAL.Entities.Message
            {
                Body=model.Body,
                Email=model.Email,
                Title=model.Title
            });
            return true;
        }
    }
}