using Casino.Models.NewsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Core.Logging;
using Umbraco.Web.Mvc;

namespace Casino.Controllers
{
    public class NewsController : SurfaceController
    {
        public ActionResult RenderNews()
        {
            try
            {
                List<News> newsList = new List<News>();
                var list=CurrentPage?.Children.Where(m=>!m.IsDraft).ToList();
                if (list != null)
                {
                    list.ForEach(m =>
                    {
                        int idbanner = 0;
                        newsList.Add(new News {
                            Body = m.GetProperty("articleBody")?.Value?.ToString(),
                            Title = m.GetProperty("articleTitle")?.Value?.ToString(),
                            ImagePath = int.TryParse(m.GetProperty("articleBanner")?.Value?.ToString(), out idbanner) ? Umbraco.TypedMedia(idbanner).Url : "",
                            DatePublished = m.GetProperty("articlePublishedDate").HasValue ? DateTime.Parse(m.GetProperty("articlePublishedDate").Value.ToString()) : new DateTime?()
                        });
                    });
                }
                return PartialView("News/_News",newsList);
            }
            catch(Exception ex)
            {
                LogHelper.Error(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, "News error", ex);
            }
            return Content("");
        }
    }
}