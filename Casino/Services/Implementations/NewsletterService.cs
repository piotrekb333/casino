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
        public bool SaveToNewsletter(string email)
        {
            _newsletterRepository.Insert(new Newsletter { Email = email, RegisterDate = DateTime.UtcNow });
            return true;
        }
    }
}