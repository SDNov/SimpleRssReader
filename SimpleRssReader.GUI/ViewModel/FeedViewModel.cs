using SimpleRssReader.Domain.DAL;
using SimpleRssReader.Domain.Model;
using System;

namespace SimpleRssReader.GUI.ViewModel
{
    public class FeedViewModel : ViewModelBase
    {
        readonly RssFeed _feed;
        readonly RssFeedsRepository _feedsRepository;

        public FeedViewModel(RssFeed feed, RssFeedsRepository feedsRepository)
        {
            if (feed == null)
                throw new ArgumentNullException("feed");
            if (feedsRepository == null)
                throw new ArgumentNullException("feedsRepository");

            _feed = feed;
            _feedsRepository = feedsRepository;
        }
    }
}
