using Casino.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Casino.Services.Interfaces
{
    public interface INewsletterService
    {
        SaveToNewsletterResponse SaveToNewsletter(string email);
    }
}