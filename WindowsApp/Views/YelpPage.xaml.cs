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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using static WindowsApp.YelpPage;




// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace WindowsApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class YelpPage : Page
    {
        //MainPage rootPage = MainPage.Current;


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

            string ZOMATO_URL = ZOMATO_API + CUISINE_TYPE.Replace(" ", "%20") + LOCATION;

            // Add a new Request Message
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Put, ZOMATO_URL);
            // Add our custom headers
            requestMessage.Headers.Add("user-key", "d22a78b458553d4677780d0d8e287df9");
            requestMessage.Headers.Add("Accept", "application/json");

            // Send the request to the server
            HttpResponseMessage response = await httpClient.SendAsync(requestMessage);

       
            string responseAsString = await response.Content.ReadAsStringAsync();
            //OutputField.Text = responseAsString;

            RootObject rootObject = null;

            rootObject = JsonConvert.DeserializeObject<RootObject>(responseAsString);


            //Info for Restaurant 0
            if(rootObject.results_found > 0)
                {
                    name0.Text = rootObject.restaurants[0].restaurant.name;
                    address0.Text = rootObject.restaurants[0].restaurant.location.address;
                    average_cost_for_two0.Text = "Cost for two: $" + rootObject.restaurants[0].restaurant.average_cost_for_two.ToString();
                    image0.Source = new BitmapImage(new Uri(rootObject.restaurants[0].restaurant.thumb, UriKind.Absolute));
                }
            else
                {
                    resultsNum.Text = "There are no matches in the area";
                }


            //Info for Restaurant 1
            if (rootObject.results_found > 1)
            {
                name1.Text = rootObject.restaurants[1].restaurant.name;
                address1.Text = rootObject.restaurants[1].restaurant.location.address;
                average_cost_for_two1.Text = "Cost for two: $" + rootObject.restaurants[1].restaurant.average_cost_for_two.ToString();
                image1.Source = new BitmapImage(new Uri(rootObject.restaurants[1].restaurant.thumb, UriKind.Absolute));

            }
            else
            {
                resultsNum.Text = "There were only " + rootObject.results_found.ToString() + " restaurants that were a match.";
            }

            //Info for Restaurant 2
            if (rootObject.results_found > 2)
            {
                name2.Text = rootObject.restaurants[2].restaurant.name;
                address2.Text = rootObject.restaurants[2].restaurant.location.address;
                average_cost_for_two2.Text = "Cost for two: $" + rootObject.restaurants[2].restaurant.average_cost_for_two.ToString();
                image2.Source = new BitmapImage(new Uri(rootObject.restaurants[2].restaurant.thumb, UriKind.Absolute));
            }
            else
            {
                resultsNum.Text = "There were only " + rootObject.results_found.ToString() + " restaurants that were a match.";
            }
            //Info for Restaurant 3
            if (rootObject.results_found > 3)
            {
                name3.Text = rootObject.restaurants[3].restaurant.name;
                address3.Text = rootObject.restaurants[3].restaurant.location.address;
                average_cost_for_two3.Text = "Cost for two: $" + rootObject.restaurants[3].restaurant.average_cost_for_two.ToString();
                image3.Source = new BitmapImage(new Uri(rootObject.restaurants[3].restaurant.thumb, UriKind.Absolute));
            }
            else
            {
                resultsNum.Text = "There were only " + rootObject.results_found.ToString() + " restaurants that were a match.";
            }

            //Info for Restaurant 4
            if (rootObject.results_found > 4)
            {
                name4.Text = rootObject.restaurants[4].restaurant.name;
                address4.Text = rootObject.restaurants[4].restaurant.location.address;
                average_cost_for_two4.Text = "Cost for two: $" + rootObject.restaurants[4].restaurant.average_cost_for_two.ToString();
                image4.Source = new BitmapImage(new Uri(rootObject.restaurants[4].restaurant.thumb, UriKind.Absolute));
            }
            else
            {
                resultsNum.Text = "There were only " + rootObject.results_found.ToString() + " restaurants that were a match.";
            }

            //Info for Restaurant 5
            if (rootObject.results_found > 5)
            {
                name5.Text = rootObject.restaurants[5].restaurant.name;
                address5.Text = rootObject.restaurants[5].restaurant.location.address;
                average_cost_for_two5.Text = "Cost for two: $" + rootObject.restaurants[5].restaurant.average_cost_for_two.ToString();
                image5.Source = new BitmapImage(new Uri(rootObject.restaurants[5].restaurant.thumb, UriKind.Absolute));
            }
            else
            {
                resultsNum.Text = "There were only " + rootObject.results_found.ToString() + " restaurants that were a match.";
            }

            //Info for Restaurant 6
            if (rootObject.results_found > 6)
            {
                name6.Text = rootObject.restaurants[6].restaurant.name;
                address6.Text = rootObject.restaurants[6].restaurant.location.address;
                average_cost_for_two6.Text = "Cost for two: $" + rootObject.restaurants[6].restaurant.average_cost_for_two.ToString();
                image6.Source = new BitmapImage(new Uri(rootObject.restaurants[6].restaurant.thumb, UriKind.Absolute));
            }
            else
            {
                resultsNum.Text = "There were only " + rootObject.results_found.ToString() + " restaurants that were a match.";
            }

            //Info for Restaurant 7
            if (rootObject.results_found > 7)
            {
                name7.Text = rootObject.restaurants[7].restaurant.name;
                address7.Text = rootObject.restaurants[7].restaurant.location.address;
                average_cost_for_two7.Text = "Cost for two: $" + rootObject.restaurants[7].restaurant.average_cost_for_two.ToString();
                image7.Source = new BitmapImage(new Uri(rootObject.restaurants[7].restaurant.thumb, UriKind.Absolute));
                
            }
            else
            {
                resultsNum.Text = "There were only " + rootObject.results_found.ToString() + " restaurants that were a match.";
            }

            if(rootObject.results_found > 8)
            {
                resultsNum.Text = "";
            }



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
