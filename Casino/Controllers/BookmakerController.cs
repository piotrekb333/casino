using Casino.Models.BookmakerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Core.Logging;
using Umbraco.Web.Mvc;

namespace Casino.Controllers
{
    public class BookmakerController : SurfaceController
    {
        public ActionResult RenderBookmakers()
        {
            try
            {
                List<BookmakerModel> newsList = new List<BookmakerModel>();
                var list = CurrentPage?.Children.Where(m => !m.IsDraft).ToList();
                if (list != null)
                {
                    list.ForEach(m =>
                    {
                        int idbanner = 0;
                        newsList.Add(new BookmakerModel
                        {
                            ImageUrl = int.TryParse(m.GetProperty("imageUrl")?.Value?.ToString(), out idbanner) ? Umbraco.TypedMedia(idbanner).Url : "",
                            Description = m.GetProperty("bookmakerDescription")?.Value?.ToString(),
                            Title = m.GetProperty("bookmakerTitle")?.Value?.ToString(),
                            //ImagePath = int.TryParse(m.GetProperty("articleBanner")?.Value?.ToString(), out idbanner) ? Umbraco.TypedMedia(idbanner).Url : "",
                            //DatePublished = m.GetProperty("articlePublishedDate").HasValue ? DateTime.Parse(m.GetProperty("articlePublishedDate").Value.ToString()) : new DateTime?()
                        });
                    });
                    //newsList = newsList.OrderByDescending(m => m.DatePublished).ToList();
                }
                return PartialView("Bookmakers/_Bookmakers", newsList);
            }
            catch (Exception ex)
            {
                LogHelper.Error(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, "Bookmakers error", ex);
            }
            return Content("");
        }
    }
}