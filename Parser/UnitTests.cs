using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using Parser;

namespace RSSReader
{
    class UnitTests
    {
        [TestFixture]
        class UnitTestExamplesForIDs
        {
            [TestCase]
            // should be failed
            public void CheckIf_ChannelID_HaveID()
            {
                var target = new Feed();
                var items = target.ChannelID;
                Assert.IsNotNull(items, " shouldn't be a null.");

            }

            [TestCase]
            // should be failed
            public void CheckIf_FeedID_HaveFeedID()
            {
                var target = new Feed();
                var items = target.FeedID;
                Assert.IsNotNull(items, " shouldn't be a null.");

            }
        }

        [TestFixture]
        class UnitTestExamples
        {

            [TestCase]
            public void CheckIf_Channel_HaveName()
            {
                var target = new Feed();
                var items = target.Channel;
                Assert.IsNull(items, " should be a null.");

            }

            [TestCase]
            public void CheckIf_Date_HaveDate()
            {
                var target = new Feed();
                var items = target.Date;
                Assert.IsNull(items, " should be a null.");

            }

            [TestCase]
            public void CheckIf_Description_HaveDescription()
            {
                var target = new Feed();
                var items = target.Description;
                Assert.IsNull(items, " should be a null.");

            }

            [TestCase]
            public void CheckIf_Imagelink_HaveImagelink()
            {
                var target = new Feed();
                var items = target.Imagelink;
                Assert.IsNull(items, " should be a null.");

            }

            [TestCase]
            public void CheckIf_Link_HaveURLlink()
            {
                var target = new Feed();
                var items = target.Link;
                Assert.IsNull(items, " should be a null.");

            }

            [TestCase]
            public void CheckIf_Title_HaveTitle()
            {
                var target = new Feed();
                var items = target.Title;
                Assert.IsNull(items, " should be a null.");

            }

            [TestCase]
            public void CheckIf_Channel_HaveRequiredTitleAndAddress()
            {
                int result = 0;
                var target = new Channel();
                var item1 = target.Title;
                var item2 = target.Address;

                SomeItemsConstraint condition1 = Contains.Item(item1);
                SomeItemsConstraint condition2 = Contains.Item(item2);
                if ((condition1 != null) && condition2 != null)
                {
                    result = 1;
                }
                Assert.That(result, Is.EqualTo(1));
            }
        }
    }
}