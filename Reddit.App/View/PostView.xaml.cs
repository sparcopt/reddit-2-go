using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Reddit.App.ViewModel;
using Windows.System;
using Microsoft.Phone.Tasks;

namespace Reddit.App.View
{
    public partial class PostView : PhoneApplicationPage
    {
        public PostView()
        {
            InitializeComponent();
            this.DataContext = new PostViewModel();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var postId = this.NavigationContext.QueryString["id"];
            await (this.DataContext as PostViewModel).LoadDataAsync(postId);
        }

        private async void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            var url = (this.DataContext as PostViewModel).Url;
            await Launcher.LaunchUriAsync(new Uri(url));
        }

        private void ApplicationBarIconButton_Click_1(object sender, EventArgs e)
        {
            var shareLinkTask = new ShareLinkTask();
            shareLinkTask.Title = (this.DataContext as PostViewModel).Title;
            shareLinkTask.LinkUri = new Uri((this.DataContext as PostViewModel).Url);
            shareLinkTask.Show();
        }
    }
}