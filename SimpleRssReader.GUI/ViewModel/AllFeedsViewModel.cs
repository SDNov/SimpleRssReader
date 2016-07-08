using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleRssReader.Domain.DAL;

namespace SimpleRssReader.GUI.ViewModel
{
    public class AllFeedsViewModel : ViewModelBase
    {
        readonly RssFeedsRepository _feedsRepository;
        public ObservableCollection<FeedViewModel> AllFeeds { get; private set; }

        public AllFeedsViewModel(RssFeedsRepository feedsRepository)
        {
            if (feedsRepository == null)
                throw new ArgumentNullException("feeds repository");
            base.DisplayName = "All feedds";
            _feedsRepository = feedsRepository;

            _feedsRepository.FeedAdded += this.OnFeedAddedToRepository;

            this.CreateAllFeeds();
        }

        private void CreateAllFeeds()
        {
            List<FeedViewModel> all =
                (from f in _feedsRepository.GetAll()
                 select new FeedViewModel(f, _feedsRepository)).ToList();
            foreach (FeedViewModel fvm in all)
            {
                fvm.PropertyChanged += this.OnFeedViewModelPropertyChanged;
            }

            this.AllFeeds = new ObservableCollection<FeedViewModel>(all);
            this.AllFeeds.CollectionChanged += this.OnCollectionChanged;
        }

        private void OnCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (FeedViewModel fvm in e.NewItems)
                    fvm.PropertyChanged += this.OnFeedViewModelPropertyChanged;
            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (FeedViewModel fvm in e.OldItems)
                    fvm.PropertyChanged -= this.OnFeedViewModelPropertyChanged;
        }

        private void OnFeedViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            string IsSelected = "IsSelected";
            if (e.PropertyName == IsSelected)
            {
                // TODO 
                // Реализовать вывод новостей
            }
                
        }

        void OnFeedAddedToRepository(object sender, FeedAddedEventArgs e)
        {
            var viewModel = new FeedViewModel(e.NewFeed, _feedsRepository);
            this.AllFeeds.Add(viewModel);
        }
    }
}
