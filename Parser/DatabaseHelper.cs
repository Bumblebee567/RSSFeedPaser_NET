using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    class DatabaseHelper
    {
        public static void SaveChannelsToDatabase()
        {
            
        }
        public static void SaveFeedsToDatabase(string channelUrl)
        {

        }
        public static bool CheckIfChannelIsInDatabase(string channelUrl)
        {
            return false;
        }
        public static bool CheckIfFeedIsInDatabase(string feedUrl, string channelUrl)
        {
            bool checker = false;
            using (var context = new RSSFeedDatabaseModel())
            {
                var channel = context.Channel.Where(x => x.Address == channelUrl).First();
                var feedsOnChannel = context.Feed.Where(x => x.ChannelID == channel.ChannelID);
                foreach (var feed in feedsOnChannel)
                {
                    if(feed.Link == feedUrl)
                    {
                        checker = true;
                        break;
                    }
                }
            }
            return checker;
        }
    }
}
