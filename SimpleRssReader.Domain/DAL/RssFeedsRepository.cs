using System;
using SimpleRssReader.Domain.Model;
using SimpleRssReader.Domain.DAL;
using System.Data.Entity;

namespace SimpleRssReader.Domain.DAL
{
    public class RssFeedsRepository : Repository<RssFeed>
    {
        public RssFeedsRepository(DbContext context)
            : base(context)
        {

        }
        public event EventHandler<FeedAddedEventArgs> FeedAdded;
    }
}
