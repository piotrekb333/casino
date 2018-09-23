using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Casino.Models.ReviewsModel
{
    public class ReviewModel
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public int Rating { get; set; } = 2;
        public string SiteUrl { get; set; }
    }
}