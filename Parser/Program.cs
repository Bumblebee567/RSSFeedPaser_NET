using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Timers;

namespace Parser
{
    class Program
    {
        public const string url = "https://www.tvn24.pl/rss.html";
        static void Main(string[] args)
        {
            Timer refreshTimer = new Timer();
            refreshTimer.Elapsed += RefreshTimer_Elapsed;
            refreshTimer.Interval = 300000;
            refreshTimer.Start();
            Console.ReadKey();
        }
        private static void RefreshTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            DatabaseHelper.AddChannelsToDatabase(url);
            DatabaseHelper.AddFeedsToDatabase();
        }
    }
}
