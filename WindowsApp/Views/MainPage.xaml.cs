using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace WindowsApp.Views
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
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
