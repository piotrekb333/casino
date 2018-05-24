using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Casino.Models.NewsModels
{
    public class News
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public string ImagePath { get; set; }
        public DateTime? DatePublished { get; set; }
    }
}