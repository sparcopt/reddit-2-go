using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Reddit.App.Resources;
using System.Collections;
using Reddit.App.ViewModel;

namespace Reddit.App.View
{
    public partial class OldHomeView : PhoneApplicationPage
    {
        // Constructor
        public OldHomeView()
        {
            InitializeComponent();
            this.DataContext = new HomeViewModel();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            await (this.DataContext as HomeViewModel).LoadDataAsync();
        }

        private void list_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/View/SubredditView.xaml?name=" + (sender as LongListSelector).SelectedItem, UriKind.Relative));
        }
    }
}