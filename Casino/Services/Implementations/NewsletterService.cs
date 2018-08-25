using Casino.Models.Responses;
using Casino.Services.Interfaces;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Casino.Services.Implementations
{
    public class NewsletterService : INewsletterService
    {
        private readonly INewsletterRepository _newsletterRepository;
        public NewsletterService(INewsletterRepository newsletterRepository)
        {
            _newsletterRepository = newsletterRepository;
        }
        public SaveToNewsletterResponse SaveToNewsletter(string email)
        {
            SaveToNewsletterResponse returnModel = new SaveToNewsletterResponse();
            returnModel.Success = true;
            if (_newsletterRepository.EmailExistsInNewsletter(email))
            {
                returnModel.Success = false;
                returnModel.Message = "Email exists";
            }
            else
                _newsletterRepository.Insert(new Newsletter { Email = email, RegisterDate = DateTime.UtcNow });
            return returnModel;
        }
    }
}