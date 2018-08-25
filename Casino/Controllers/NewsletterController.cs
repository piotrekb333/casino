using Casino.Models.Requests;
using Casino.Models.Responses;
using Casino.Services.Interfaces;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

using Umbraco.Web.WebApi;

namespace Casino.Controllers
{
    public class NewsletterController : UmbracoApiController
    {
        private readonly INewsletterService _newsletterService;
        public NewsletterController(INewsletterService newsletterService)
        {
            _newsletterService = newsletterService;
        }

        [HttpPost]
        public IHttpActionResult SaveToNewsletter(SaveToNewsletterRequest model)
        {
            SaveToNewsletterResponse response = new SaveToNewsletterResponse();
            response = _newsletterService.SaveToNewsletter(model.Email);
            return Ok(response);
        }
    }
}