using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using WindowsApp.ViewModels;
using Windows.UI.Xaml.Navigation;
using System.Collections.ObjectModel;


namespace WindowsApp.Views
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
        }

        private void button2_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Frame.Navigate(typeof(YelpPage));
        }

        private async void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var d = new ContentDialog();
            d.ContentTemplate = Resources["RestaurantDetailTemplate"] as DataTemplate;
            d.DataContext = e.ClickedItem;
            d.PrimaryButtonText = "Close";
            await d.ShowAsync();
        }

        
    }
}
