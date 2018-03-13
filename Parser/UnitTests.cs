using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Parser;

namespace RSSReader
{
    class UnitTests
    {
        [TestFixture]
        class UnitTestExamples
        {

            [TestCase]
            public void CheckIf_Channel_HaveName()
            {
                var target = new Feed();
                var items = target.Channel;
                Assert.IsNull(items);

            }

            [TestCase]
            // should be failed
            public void CheckIf_ChannelID_HaveID()
            {
                var target = new Feed();
                var items = target.ChannelID;
                Assert.IsNull(items);

            }

            [TestCase]
            public void CheckIf_Date_HaveDate()
            {
                var target = new Feed();
                var items = target.Date;
                Assert.IsNull(items);

            }

            [TestCase]
            public void CheckIf_Description_HaveDescription()
            {
                var target = new Feed();
                var items = target.Description;
                Assert.IsNull(items);

            }

            [TestCase]
            // should be failed
            public void CheckIf_FeedID_HaveFeedID()
            {
                var target = new Feed();
                var items = target.FeedID;
                Assert.IsNull(items);

            }

            [TestCase]
            public void CheckIf_Imagelink_HaveImagelink()
            {
                var target = new Feed();
                var items = target.Imagelink;
                Assert.IsNull(items);

            }

            [TestCase]
            public void CheckIf_Link_HaveURLlink()
            {
                var target = new Feed();
                var items = target.Link;
                Assert.IsNull(items);

            }
            
            [TestCase]
            public void CheckIf_Title_HaveTitle()
            {
                var target = new Feed();
                var items = target.Title;
                Assert.IsNull(items);

            }
        }
    }
}