using Casino.Models.CasinoModels;
using Casino.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Core.Logging;
using Umbraco.Web;
using Umbraco.Web.Mvc;

namespace Casino.Controllers
{
    public class CasinoController : SurfaceController
    {
        public ActionResult RenderCasinos()
        {
            try
            {
                var list = CurrentPage?.Children.ToList();
                List<CasinoModel> newsList = new List<CasinoModel>();
                if (list != null)
                {                   
                    list.ForEach(m =>
                    {
                        newsList.Add(new CasinoModel
                        {
                            Body = m.GetProperty("bodyCasino")?.Value?.ToString(),
                            Title = m.GetProperty("titleCasino")?.Value?.ToString(),
                            LogoUrl = Url.GetCropUrl(m,"logoCasino").ToString(),
                            SiteUrl=m.Url
                        });
                    });
                }
                return PartialView("Casinos/_RenderCasinos", newsList);
            }
            catch (Exception ex)
            {
                LogHelper.Error(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, "Error", ex);
            }
            return Content("");
        }
    }
}