using Sparcopt.Reddit.Api;
using Reddit.App.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reddit.App.ViewModel
{
    public class PostViewModel : BindableBase
    {
        private string _title;

        public string Title
        {
            get { return _title; }
            set { _title = value; RaisePropertyChanged(); }
        }

        private string _author;

        public string Author
        {
            get { return _author; }
            set { SetProperty(ref _author, value); }
        }

        private string _url;

        public string Url
        {
            get { return _url; }
            set { SetProperty(ref _url, value); }
        }
        
        public async Task LoadDataAsync(string id)
        {
            var redditService = new RedditService();
            var post = await redditService.GetPostAsync(id);
            Title = post.Title;
            Author = post.Author;
            Url = post.Url;
        }
    }
}
