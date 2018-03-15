using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Parser
{
    class FeedParserHelper
    {
        public static List<Feed> ParseFeed(string channelUrl)
        {
            XDocument rssDocument;
            try
            {
                rssDocument = XDocument.Load(channelUrl);
            }
            catch (Exception)
            {
                rssDocument = null;
            }
            if (rssDocument != null)
            {
                List<Feed> parsedFeeds = new List<Feed>();
                var feeds = rssDocument.Descendants("item");
                foreach (var feed in feeds)
                {
                    var link = feed.Element("link").Value;
                    bool databaseChecker = DatabaseHelper.IsFeedInDatabase(link, channelUrl);
                    if (databaseChecker == true)
                    {
                        continue;
                    }
                    var title = feed.Element("title").Value;
                    if (title == "")
                    {
                        title = "brak tytułu";
                    }
                    string pubdate = "brak daty";
                    if (feed.Element("pubDate") != null)
                    {
                        pubdate = feed.Element("pubDate").Value;
                    }
                    var descirptionInHtmlCode = feed.Element("description").Value;
                    var description = Regex.Replace(descirptionInHtmlCode, @"<.+?>", String.Empty).TrimStart();
                    if (description == "")
                    {
                        description = "brak opisu";
                    }
                    var imageInHtmlCode = Regex.Match(descirptionInHtmlCode, @"<.+?>");
                    var image = GetImageDirectUrl(imageInHtmlCode.ToString());
                    if (image == "")
                    {
                        image = "brak zdjęcia";
                    }
                    parsedFeeds.Add(new Feed
                    {
                        Title = title,
                        Link = link,
                        Date = pubdate,
                        Description = description,
                        Imagelink = image
                    });
                }
                return parsedFeeds;
            }
            else
            {
                return null;
            }
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
        public static List<string> GetChannelTitles(string url)
        {
            var web = new HtmlWeb();
            var doc = web.Load(url);

            var channels = doc.DocumentNode.Descendants("td");
            List<string> channelContent = ConvertHtmlToString(channels);
            var names = channelContent.Where(x => !x.EndsWith(".xml") && x != String.Empty);

            return names.ToList();

        }
        public static List<string> GetChannelUrls(string url)
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
