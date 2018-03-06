using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Xml;

namespace Parser
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = "https://www.tvn24.pl/rss.html";
            var urls = GetChannelUrls(url);
            var titles = GetChannelNames(url);
        }

        private static void ParseFeed(string feedUrl)
        {
            XmlDocument rss = new XmlDocument();
            rss.Load(feedUrl);
            XmlNodeList rssNodes = rss.SelectNodes("rss/channel/item");
            StringBuilder content = new StringBuilder();

            foreach (XmlNode node in rssNodes)
            {
                XmlNode rssSubNode = node.SelectSingleNode("title");
                var title = rssSubNode.InnerText;
                rssSubNode = node.SelectSingleNode("link");
                var link = rssSubNode.InnerText;
                rssSubNode = node.SelectSingleNode("pubDate");
                var pubdate = rssSubNode.InnerText;
                rssSubNode = node.SelectSingleNode("description");
                var description = rssSubNode.InnerText;

                content.AppendLine(title);
                content.AppendLine(link);
                content.AppendLine(pubdate);
                content.AppendLine(description);
            }
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
