using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    class DatabaseHelper
    {
        public static void AddChannelsToDatabase()
        {
            
        }
        public static void AddFeedsToDatabase(string channelUrl)
        {

        }
        public static bool CheckIfChannelIsInDatabase(string channelUrl)
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
        public static bool CheckIfFeedIsInDatabase(string feedUrl, string channelUrl)
        {
            bool checker = true;
            using (var context = new RSSFeedDatabaseModel())
            {
                var channel = context.Channel.Where(x => x.Address == channelUrl).First();
                var feedsOnChannel = context.Feed.Where(x => x.ChannelID == channel.ChannelID);
                foreach (var feed in feedsOnChannel)
                {
                    if(feed.Link == feedUrl)
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
