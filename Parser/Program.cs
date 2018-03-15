using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Timers;
using System.Threading.Tasks;
using System.Threading;

namespace Parser
{
    class Program
    {
        public const string url = "https://www.tvn24.pl/rss.html";
        static void Main(string[] args)
        {
            while (true)
            {
                Thread.Sleep(300000);
                //DatabaseHelper.AddChannelsToDatabase(url);
                //DatabaseHelper.AddFeedsToDatabase();
                Console.WriteLine("done");
            }
        }
    }
}
