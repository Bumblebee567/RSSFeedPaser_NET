using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Xml;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.IO;

namespace Parser
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = "https://www.tvn24.pl/rss.html";
            var urls = GetChannelUrls(url);
            var titles = GetChannelNames(url);

            ParseFeed(urls[0]);
        }

        private static void ParseFeed(string feedUrl)
        {
            XDocument rssDocument = XDocument.Load(feedUrl);
            var feeds = rssDocument.Descendants("item");
            StringBuilder sb = new StringBuilder();
            foreach (var feed in feeds)
            {
                var title = feed.Element("title").Value;
                var link = feed.Element("link").Value;
                var pubdate = feed.Element("pubDate").Value;
                var descH = feed.Element("description").Value;
                var description = Regex.Replace(descH, @"<.+?>", String.Empty);
                var img = Regex.Match(descH, @"<.+?>");
                var image = GetImageDirectUrl(img.ToString());

                sb.AppendLine(title);
                sb.AppendLine(link);
                sb.AppendLine(pubdate);
                sb.AppendLine(description.TrimStart().TrimEnd());
                sb.AppendLine(image.ToString());
            }
            Console.WriteLine(sb.ToString());
        }

        private static string GetImageDirectUrl(string imageHtml)
        {
            var str = imageHtml.Replace("<img src=\"", String.Empty)
                .Replace("\"", String.Empty)
                .Replace("/>", String.Empty)
                .Replace("align=right", String.Empty)
                .Replace("quality=80", "quality=100")
                .Replace("50", "300")
                .Replace("&amp;", "&");
            return str;
        }

        static List<string> GetChannelNames(string url)
        {
            var web = new HtmlWeb();
            var doc = web.Load(url);

            var channels = doc.DocumentNode.Descendants("td");
            List<string> channelContent = ConvertHtmlToString(channels);
            var names = channelContent.Where(x => !x.EndsWith(".xml") && x != String.Empty);

            return names.ToList();

        }
        static List<string> GetChannelUrls(string url)
        {
            var web = new HtmlWeb();
            var doc = web.Load(url);

            var channels = doc.DocumentNode.Descendants("td");
            List<string> channelContent = ConvertHtmlToString(channels);
            var addresses = channelContent.Where(x => x.EndsWith(".xml"));

            return addresses.ToList();
        }

        private static List<string> ConvertHtmlToString(IEnumerable<HtmlNode> channels)
        {
            List<string> channelContent = new List<string>();
            foreach (var item in channels)
            {
                channelContent.Add(item.InnerText.ToString());
            }
            return channelContent;
        }
    }
}
