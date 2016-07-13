using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Data.Json;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Globalization;
using Windows.Globalization.DateTimeFormatting;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;








// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace WindowsApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class YelpPage : Page
    {
        //MainPage rootPage = MainPage.Current;

        private HttpClient httpClient;
        


        






        public YelpPage()
        {
            this.InitializeComponent();
        }

        private async void searchYelp_Click(object sender, RoutedEventArgs e)
        {

            // Create a client
            HttpClient httpClient = new HttpClient();

            string ZOMATO_API = "https://developers.zomato.com/api/v2.1/search?q=";

            string CUISINE_TYPE = searchInput.Text;

            string LOCATION = "&count=8&lat=37.784627&lon=-122.398458&radius=1600&sort=rating";

            string ZOMATO_URL = ZOMATO_API + CUISINE_TYPE + LOCATION;

            // Add a new Request Message
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Put, ZOMATO_URL);
            // Add our custom headers
            requestMessage.Headers.Add("user-key", "d22a78b458553d4677780d0d8e287df9");
            requestMessage.Headers.Add("Accept", "application/json");

            // Send the request to the server
            HttpResponseMessage response = await httpClient.SendAsync(requestMessage);

            // Just as an example I'm turning the response into a string here
            var responseAsString = await response.Content.ReadAsStringAsync();



            JsonArray root = JsonValue.Parse("[" + responseAsString + "]").GetArray();
            //for (uint i = 0; i < root.count; i++)
            //{
            //    string name1 = root.getobjectat(i).getnamedstring("name");
            //    string description1 = root.getobjectat(i).getnamedstring("description");
            //    string link1 = root.getobjectat(i).getnamedstring("link");
            //    string cat1 = root.getobjectat(i).getnamedstring("cat");
            //    string image1 = root.getobjectat(i).getnamedstring("image");





            //}
        
        }

    }
}
