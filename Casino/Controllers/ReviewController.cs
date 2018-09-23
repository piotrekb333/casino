using Casino.Models.ReviewsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Core.Logging;
using Umbraco.Web.Mvc;

namespace Casino.Controllers
{
    public class ReviewController : SurfaceController
    {
        public ActionResult RenderReviews()
        {
            try
            {
                List<ReviewModel> reviewList = new List<ReviewModel>();
                var list = CurrentPage?.Children.Where(m => !m.IsDraft).ToList();
                if (list != null)
                {
                    list.ForEach(m =>
                    {
                        reviewList.Add(new ReviewModel
                        {
                            Body = m.GetProperty("reviewBody")?.Value?.ToString(),
                            Title = m.GetProperty("reviewTitle")?.Value?.ToString(),
                            Rating = m.GetProperty("reviewRating").HasValue ? int.Parse(m.GetProperty("reviewRating").ToString()) : 2,
                            SiteUrl = m.Url
                        });
                    });
                }
                return PartialView("Reviews/_Reviews", reviewList);
            }
            catch (Exception ex)
            {
                LogHelper.Error(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType, "Review error", ex);
            }
            return Content("");
        }
    }
}