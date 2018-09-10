using Casino.Models.Contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Core.Logging;
using Umbraco.Web.Mvc;

namespace Casino.Controllers
{
    public class ContactController : SurfaceController
    {
        [HttpPost]
        public ActionResult Contact(ContactViewModel model)
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                LogHelper.Error(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, "Contact error", ex);
            }
            return View();
        }
    }
}