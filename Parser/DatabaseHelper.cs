﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    class DatabaseHelper
    {
        public static void AddChannelsToDatabase(string websiteUrl)
        {
            var channelTitles = FeedParserHelper.GetChannelTitles(websiteUrl);
            var channelUrls = FeedParserHelper.GetChannelUrls(websiteUrl);
            List<Channel> channelsToAdd = new List<Channel>();
            bool checker;
            using (var context = new RSSFeedDatabaseModel())
            {
                for (int i = 0; i < channelUrls.Count; i++)
                {
                    checker = IsChannelInDatabase(channelUrls[i]);
                    if(checker == true)
                    {
                        continue;
                    }
                    else
                    {
                        channelsToAdd.Add(new Channel
                        {
                            Address = channelUrls[i],
                            Title = channelTitles[i]
                        });
                    }
                }
                if (channelsToAdd.Count != 0)
                {
                    context.Channel.AddRange(channelsToAdd);
                }
            }
        }
        private static bool IsChannelInDatabase(string channelUrl)
        {
            bool checker;
            using (var context = new RSSFeedDatabaseModel())
            {
                if (context.Channel.Any(x => x.Address == channelUrl) == true)
                {
                    checker = true;
                }
                else
                {
                    checker = false;
                }
            }
            return checker;
        }
        public static void AddFeedsToDatabase(string channelUrl)
        {

        }
        private static bool IsFeedInDatabase(string feedUrl, string channelUrl)
        {
            bool checker = true;
            using (var context = new RSSFeedDatabaseModel())
            {
                var channel = context.Channel.Where(x => x.Address == channelUrl).First();
                var feedsOnChannel = context.Feed.Where(x => x.ChannelID == channel.ChannelID);
                foreach (var feed in feedsOnChannel)
                {
                    if (feed.Link == feedUrl)
                    {
                        checker = false;
                        break;
                    }
                }
            }
            return checker;
        }
    }
}
