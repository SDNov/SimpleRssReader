using SimpleRssReader.Domain.DAL;
using SimpleRssReader.Domain.Model;
using System;
using System.Data.Entity;

namespace SimpleRssReader.Domain.DAL
{
    public class RssContext : DbContext, IDisposable
    {
        public RssContext(string connectionString)
            : base(connectionString)
        {
            Database.SetInitializer<RssContext>(new RssDbInitializer());

        }
        public DbSet<RssFeed> RssFeeds { get; set; }
    }
}
