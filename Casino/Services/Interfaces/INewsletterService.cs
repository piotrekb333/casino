using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Casino.Services.Interfaces
{
    public interface INewsletterService
    {
        bool SaveToNewsletter(string email);
    }
}