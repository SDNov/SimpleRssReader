using SimpleRssReader.Domain.Model;
using System;

namespace SimpleRssReader.Domain.DAL
{
    public class FeedAddedEventArgs : EventArgs
    {
        public FeedAddedEventArgs(RssFeed newFeed)
        {
            this.NewFeed = newFeed;
        }

        public RssFeed NewFeed { get; private set; }
    }
}
