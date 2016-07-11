using System;
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
    }
}
