using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
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

        private async void ZamatoAPICall()
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
            string responseAsString = await response.Content.ReadAsStringAsync();
            //OutputField.Text = responseAsString;

            Restaurant2 restaurant2 = JsonConvert.DeserializeObject<Restaurant2>(responseAsString);

           

            OutputField.Text = restaurant2.name.ToString();

        }


        private void searchYelp_Click(object sender, RoutedEventArgs e)
        {
            ZamatoAPICall();   
        }

        private void searchInput_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
                ZamatoAPICall();
        }


        
        public class R
        {
            public int res_id { get; set; }
        }

        public class Location
        {
            public string address { get; set; }
            public string locality { get; set; }
            public string city { get; set; }
            public int city_id { get; set; }
            public string latitude { get; set; }
            public string longitude { get; set; }
            public string zipcode { get; set; }
            public int country_id { get; set; }
        }

        public class UserRating
        {
            public string aggregate_rating { get; set; }
            public string rating_text { get; set; }
            public string rating_color { get; set; }
            public string votes { get; set; }
        }

        public class Restaurant2
        {
            public R R { get; set; }
            public string apikey { get; set; }
            public string id { get; set; }
            public string name { get; set; }
            public string url { get; set; }
            public Location location { get; set; }
            public string cuisines { get; set; }
            public int average_cost_for_two { get; set; }
            public int price_range { get; set; }
            public string currency { get; set; }
            public List<object> offers { get; set; }
            public string thumb { get; set; }
            public UserRating user_rating { get; set; }
            public string photos_url { get; set; }
            public string menu_url { get; set; }
            public string featured_image { get; set; }
            public int has_online_delivery { get; set; }
            public int is_delivering_now { get; set; }
            public string deeplink { get; set; }
            public string events_url { get; set; }
            public List<object> establishment_types { get; set; }
        }

        public class Restaurant
        {
            public Restaurant2 restaurant { get; set; }
        }

        public class RootObject
        {
            public int results_found { get; set; }
            public int results_start { get; set; }
            public int results_shown { get; set; }
            public List<Restaurant> restaurants { get; set; }
        }
    }
}
