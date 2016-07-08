using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel.Syndication;
using System.Xml;
using System.Xml.Schema;
using SimpleRssReader.Domain.DAL;
using SimpleRssReader.Domain.Model;
using System.Data.Entity.Validation;

namespace SimpleRssReader.ConsoleClient
{
    class Program
    {
        //http://www.rssboard.org/rss-specification
        //https://habrahabr.ru/post/27389/
        //https://msdn.microsoft.com/en-us/library/bb515814.aspx
        //http://rss.rbc.ru

        static void Main(string[] args)
        {
            //XmlReaderSettings settings = new XmlReaderSettings();
            //settings.DtdProcessing = DtdProcessing.Parse;
            //settings.ValidationType = ValidationType.DTD;
            ////settings.ValidationEventHandler += new ValidationEventHandler(ValidationCallBack);
            //XmlReader reader = XmlReader.Create("http://static.feed.rbc.ru/rbc/internal/rss.rbc.ru/rbc.ru/mainnews.rss");
            //SyndicationFeed feed = SyndicationFeed.Load(reader);
            //Console.WriteLine(feed.Links[0].Uri);
            //foreach (SyndicationItem item in feed.Items)
            //{
            //    Console.WriteLine(item.PublishDate + " " + item.Title.Text);
            //    Console.WriteLine("\t" + item.Content);
            //}

            using (var context = new RssContext("RssContext"))
            {

                try
                {
                    var feeds = from f in context.RssFeeds
                                orderby f.Title
                                select f;
                    foreach (var feed in feeds)
                    {
                        Console.WriteLine(feed.Id + " " + feed.Title);
                    }
                }
                catch (Exception ex) 
                    {
                        Console.WriteLine(ex.Message);
                    }
            }
            Console.ReadKey();
        }
        // Display any validation errors.
        private static void ValidationCallBack(object sender, ValidationEventArgs e)
        {
            Console.WriteLine("Validation Error: {0}", e.Message);
        }
    }
}
