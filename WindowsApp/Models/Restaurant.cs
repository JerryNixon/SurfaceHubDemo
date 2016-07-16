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

    public class Restaurant
    {
        public Restaurant(int sampleIndex)
        {
            Name = $"Restaurant {sampleIndex}";
            Distance = $"Only {sampleIndex} miles away";
            Thumbnail = "ms-appx:///Assets/SampleThumbnail.jpg";
            Stars = "***";
            Price = "$$$";
        }
        public Restaurant(Restaurant2 restaurant)
        {

        }
        public string Name { get; set; }
        public string Thumbnail { get; set; }
        public string Distance { get; set; }
        public string Stars { get; set; }
        public string Price { get; set; }
    }

}