using Casino.Models.CasinoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace Casino.Services.Implementations
{
    public class SearchService
    {
        private readonly UmbracoHelper _umbracoHelper;
        public SearchService(UmbracoContext context)
        {
            _umbracoHelper = new UmbracoHelper(context);
        }

        public List<CasinoModel> GetAllCasinos()
        {
            List<CasinoModel> newsList = new List<CasinoModel>();
            IPublishedContent allHomeNodes = _umbracoHelper.Content(1168);
            allHomeNodes.Children.ToList().ForEach(m =>
            {
                newsList.Add(new CasinoModel
                {
                    Body = m.GetProperty("bodyCasino")?.Value?.ToString(),
                    Title = m.GetProperty("titleCasino")?.Value?.ToString(),
                    SiteUrl = m.Url
                });
            });
            return newsList;
        }
    }
}