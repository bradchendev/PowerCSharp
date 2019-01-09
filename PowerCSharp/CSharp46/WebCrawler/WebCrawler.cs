using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Html.Parser;

namespace PowerCSharp.WebCrawler
{
    class WebCrawler
    {
    }

    public class TspaceEvent
    {
        public string EventDay { get; set; }
        public string EventYear { get; set; }
        public string HyperLink { get; set; }
        public string Img { get; set; }
        public string Title { get; set; }

        public List<TspaceEvent> GetTpaceEvents(string url)
        {
            var html = Download(url, Encoding.UTF8);

            var parser = new HtmlParser();

            #region parser
            //var document = parser.Parse("<ul><li>First item<li>Second item<li class='blue'>Third item!<li class='blue red'>Last item!</ul>");
            var document = parser.ParseDocument(html);
            // old version
            //var document = parser.Parse(html);
            #endregion


            #region query and 去除指定的tag region
            // 去除指定的tag region
            // var blueListItemsCssSelector2 = document2.QuerySelector("div.wpcf7");
            // 選取或取得指定的tag region，也就是這個<div role="form" class="wpcf7">
            // blueListItemsCssSelector2.Parent.RemoveChild(blueListItemsCssSelector2);
            // document2 去除指定的tag region
            // 取得去除後的string
            //var s = document2.DocumentElement.OuterHtml;
            #endregion

            #region query and filter 轉成list
            //var blueListItemsCssSelector = document.QuerySelectorAll("div.event_time");
            var blueListItemsCssSelector = document.QuerySelectorAll("a");
            var blueListItemsLinq = blueListItemsCssSelector.Where(m => m.OuterHtml.Contains("event_detail.php")).Take(4);
            #endregion

            var events = new List<TspaceEvent>();
            foreach (var item in blueListItemsLinq)
            {
                var evt = new TspaceEvent()
                {
                    Title = item.QuerySelector("img").GetAttribute("title").Trim(),
                    Img = string.Format("{1}{0}", item.QuerySelector("img").GetAttribute("src"), url),
                    HyperLink = string.Format("{1}{0}", item.Attributes[0].Value, url),
                    EventDay = item.QuerySelector("span.event_day").TextContent,
                    EventYear = item.QuerySelector("span.event_year").TextContent

                };
                events.Add(evt);
            }
            return events;
        }


        /// <summary>
        /// 爬文
        /// </summary>
        /// <param name="url"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        private string Download(string url, Encoding encoding)
        {
            string content = string.Empty;
            using (WebClient client = new WebClient { Encoding = encoding })
            {
                Stream data = client.OpenRead(url);
                using (StreamReader sr = new StreamReader(data, encoding))
                {
                    content = sr.ReadToEnd();
                }
                data.Close();
            }
            return content;
        }
    }

}
