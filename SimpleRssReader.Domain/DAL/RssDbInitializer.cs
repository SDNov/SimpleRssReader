using SimpleRssReader.Domain.Model;
using System.Collections.Generic;
using System.Data.Entity;

namespace SimpleRssReader.Domain.DAL
{
    public class RssDbInitializer : DropCreateDatabaseAlways<RssContext>
    {
        protected override void Seed(RssContext context)
        {
            RssFeed feed = new RssFeed
            {
                Link = "http://static.feed.rbc.ru/rbc/internal/rss.rbc.ru/rbc.ru/mainnews.rss",
                Title = "РБК - Главные новости"
            };

            context.RssFeeds.AddRange(new List<RssFeed>{
                
                new RssFeed
                {
                    Link = "http://static.feed.rbc.ru/rbc/internal/rss.rbc.ru/rbc.ru/mainnews.rss",
                    Title = "РБК - Главные новости",
                    Description = ""
                },
                    new RssFeed
                {
                    Link = "http://static.feed.rbc.ru/rbc/internal/rss.rbc.ru/rbc.ru/news.rss",
                    Title = "РБК - Все материалы",
                    Description = ""
                }
            });
            context.SaveChanges();
        }
    }
}
