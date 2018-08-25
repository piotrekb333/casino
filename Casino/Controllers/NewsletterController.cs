using Casino.Models.Requests;
using Casino.Models.Responses;
using Casino.Services.Interfaces;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace Casino.Controllers
{
    public class NewsletterController : SurfaceController
    {
        private readonly INewsletterService _newsletterService;
        public NewsletterController(INewsletterService newsletterService)
        {
            _newsletterService = newsletterService;
        }

        public JsonResult SaveToNewsletter(SaveToNewsletterRequest model)
        {
            SaveToNewsletterResponse response = new SaveToNewsletterResponse();
            response.Success=_newsletterService.SaveToNewsletter(model.Email);
            return Json(response);
        }
    }
}