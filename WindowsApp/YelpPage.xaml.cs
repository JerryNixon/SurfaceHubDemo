using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Net;
using System.Collections.Specialized;
using Windows.Web.Http;
using Windows.Security.Authentication.Web;
using Windows.Web.Http.Headers;
using Windows.Web.Http.Filters;
using Windows.Storage.Streams;
using Windows.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;








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
        private CancellationTokenSource cts;


        






        public YelpPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            // If the navigation is external to the app do not clean up.
            // This can occur on Phone when suspending the app.
            if (e.NavigationMode == NavigationMode.Forward && e.Uri == null)
            {
                return;
            }

            Dispose();
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            cts = new CancellationTokenSource();
        }





        private async void searchYelp_Click(object sender, RoutedEventArgs e)
        {

            Uri resourceAddress;
            

            long epoch = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
            string epoch_string = epoch.ToString();


            //private const string EPOCH = epoch.ToString();
            string API_HOST = "https://api.yelp.com/v2/search/?limit=8&term=Mexican";

            string LOCATION = "&location=SoMa, San Francisco, CA&oauth_consumer_key=dbAVGSsFOrg-Miiuyt0RDA&oauth_timestamp=";

            string EPOCH_TIME = epoch_string;

            string AUTH = "&oauth_signature_method=HMAC-SHA1&oauth_version=1.0&oauth_nonce=24746357509124828851479013443&oauth_token=KCxOhG7HEHe7a6-GKo1uctxeqqmwyEM3&oauth_signature=565WzSxF7shDIAL3hCxPYywkISU=";

            string urlAddress = API_HOST + LOCATION + EPOCH_TIME + AUTH;

            if (!Helpers.TryGetUri(urlAddress, out resourceAddress))
            {
   
                return;
            }

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(resourceAddress).AsTask(cts.Token);

                await Helpers.DisplayTextResultAsync(response, OutputField, cts.Token);
                response.EnsureSuccessStatusCode();


            }
            finally
            {
                button_Search.IsEnabled = true;
            }

        }

        

        private static Task DisplayTextResultAsync(HttpResponseMessage response, TextBox outputField, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            if (httpClient != null)
            {
                httpClient.Dispose();
                httpClient = null;
            }

            if (cts != null)
            {
                cts.Dispose();
                cts = null;
            }
        }

    }
}
