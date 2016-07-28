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
using System.Windows.Data;

namespace Reddit.App.View
{
    public partial class HomeView : PhoneApplicationPage
    {
        public HomeView()
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

        private async void Button_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            await(this.DataContext as HomeViewModel).SearchForSubredditsAsync();
        }

        private void OnTextBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            // Update the binding source
            BindingExpression bindingExpr = textBox.GetBindingExpression(TextBox.TextProperty);
            bindingExpr.UpdateSource();
        }
    }
}