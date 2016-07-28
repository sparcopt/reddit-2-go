using Sparcopt.Reddit.Api;
using Reddit.App.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Reddit.App.ViewModel
{
    public class HomeViewModel : BindableBase
    {
        private IList<string> _searchResult;

        public IList<string> SearchResult
        {
            get { return _searchResult; }
            set { _searchResult = value; RaisePropertyChanged(); }
        }

        private bool _isLoading;

        public bool IsLoading
        {
            get { return _isLoading; }
            set { SetProperty(ref _isLoading, value); }
        }

        private bool _isSearching;

        public bool IsSearching
        {
            get { return _isSearching; }
            set { SetProperty(ref _isSearching, value); }
        }
        
        
        private IList<string> _subreddits;

        public IList<string> Subreddits
        {
            get { return _subreddits; }
            set { _subreddits = value; RaisePropertyChanged(); }
        }

        private string _query;

        public string Query
        {
            get { return _query; }
            set { SetProperty(ref _query, value); }
        }

        private RedditService redditService;
        
        public HomeViewModel()
        {
            redditService = new RedditService();
        }

        public async Task LoadDataAsync()
        {
            IsLoading = true;
            Subreddits = await redditService.GetSubredditsAsync();
            IsLoading = false;
        }

        public async Task SearchForSubredditsAsync()
        {
            IsSearching = true;
            SearchResult = await redditService.SearchForSubredditsAsync(Query??string.Empty);
            IsSearching = false;
        }
    }
}
