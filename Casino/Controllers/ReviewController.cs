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
                            Body = m.GetProperty("ReviewBody")?.Value?.ToString(),
                            Title = m.GetProperty("ReviewTitle")?.Value?.ToString(),
                            Rating = m.GetProperty("ReviewRating").HasValue ? int.Parse(m.GetProperty("ReviewRating").Value.ToString()) : 2,
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