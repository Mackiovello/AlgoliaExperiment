using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookFinder
{
    public class AdlibrisScraper
    {
        public async Task<IEnumerable<string>> FindTitles()
        {
            var uri = "https://www.adlibris.com/se/sok?&filter=categoryfacet:b%C3%B6cker";

            var web = new HtmlWeb();
            var doc = await web.LoadFromWebAsync(uri);

            var titleNodes = doc.DocumentNode.Descendants().Where(n => n.HasClass("search-result__product__name"));

            var titles = titleNodes
                .Select(n => n.InnerText.Trim())
                .Select(System.Net.WebUtility.HtmlDecode);

            return titles;
        }
    }
}
