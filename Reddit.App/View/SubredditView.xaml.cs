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
using Sparcopt.Reddit.Api;
using Sparcopt.Reddit.Api.Domain;
using Windows.System;

namespace Reddit.App.View
{
    public partial class SubredditView : PhoneApplicationPage
    {
        public SubredditView()
        {
            InitializeComponent();
            this.DataContext = new SubredditViewModel();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var subredditName = this.NavigationContext.QueryString["name"];
            await (this.DataContext as SubredditViewModel).LoadDataAsync(subredditName);       
        }

        private void LongListSelector_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            var id = ((sender as LongListSelector).SelectedItem as Post).Id;
            this.NavigationService.Navigate(new Uri("/View/PostView.xaml?id=" + id, UriKind.Relative));

            //await Launcher.LaunchUriAsync(new Uri(url));
        }
    }
}