using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Template10.Mvvm;
using System.Collections.ObjectModel;
using WindowsApp.Models;
using System.Threading;
using Template10.Utils;

namespace WindowsApp.Models
{

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

}