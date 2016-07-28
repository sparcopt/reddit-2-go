using Sparcopt.Reddit.Api;
using Sparcopt.Reddit.Api.Domain;
using Reddit.App.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reddit.App.ViewModel
{
    public class SubredditViewModel : BindableBase
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; RaisePropertyChanged(); }
        }

        private IList<Post> _posts;

        public IList<Post> Posts
        {
            get { return _posts; }
            set { _posts = value; RaisePropertyChanged(); }
        } 

        public async Task LoadDataAsync(string name)
        {
            var redditService = new RedditService();
            var subreddit = await redditService.GetSubredditAsync(name);
            Name = subreddit.Name;
            Posts = subreddit.Posts;
        }
    }
}
