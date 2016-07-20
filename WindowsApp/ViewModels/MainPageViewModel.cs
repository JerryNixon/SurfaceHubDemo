using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Template10.Mvvm;
using System.Collections.ObjectModel;
using WindowsApp.Models;
using System.Threading;
using Template10.Utils;
using Template10.Common;
using Windows.UI.Xaml.Navigation;

namespace WindowsApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        readonly List<CancellationTokenSource> _cancellationTokens = new List<CancellationTokenSource>();
        Services.DataService _dataService;

        public MainPageViewModel()
        {
            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            {
                Restaurants.AddRange(Enumerable.Range(1, 8).Select(x => new Restaurant.Restraunt2.name(x)));
            }
            else
            {
                _dataService = new Services.DataService();
                PropertyChanged += async (s, e) =>
                {
                    _cancellationTokens.ForEach(x => x.Cancel());
                    await SearchAsync();
                };
            }
        }


        //public override async Task OnNavigatedToAsync(object parameter, navigationmode mode, idictionary<string, object> state)
        //{
        //    // defaults
        //    price1checked = true;
        //    price2checked = true;
        //    star2checked = true;
        //    star3checked = true;
        //    selectedcuisine = "indian";
        //    distance = 1;
        //    await searchasync();
        //}

        public async Task SearchAsync()
        {
            var source = _cancellationTokens.AddAndReturn(new CancellationTokenSource());
            await Task.Factory.StartNew(async () =>
            {
                // TODO: convert distance number to kilos
                var restaurants = await _dataService.GetRetaurantsAsync();
                if (!source.Token.IsCancellationRequested)
                {
                    DispatcherWrapper.Current().Dispatch(() =>
                    {
                        Restaurants.Clear();
                        foreach (var restaurant in Restaurant2)
                        {
                            Restaurants.Add(restaurant);
                        }
                    });
                }
            }, source.Token);
        }

        public ObservableCollection<Restaurant> Restaurants { get; } = new ObservableCollection<Restaurant>();

        public string[] Cuisines => new[] { "American", "Mexican", "Chinese", "Indian", "Italian", "Pizza", "Sanwich", "Japanese", "Burger", "Sushi", "BBQ", "Seafood" };

        string _SelectedCuisine = default(string);
        public string SelectedCuisine { get { return _SelectedCuisine; } set { Set(ref _SelectedCuisine, value); } }

        int _Distance = default(int);
        public int Distance { get { return _Distance; } set { Set(ref _Distance, value); } }

        #region Price properties

        bool _Price1Checked = default(bool);
        public bool Price1Checked { get { return _Price1Checked; } set { Set(ref _Price1Checked, value); } }

        bool _Price2Checked = default(bool);
        public bool Price2Checked { get { return _Price2Checked; } set { Set(ref _Price2Checked, value); } }

        bool _Price3Checked = default(bool);
        public bool Price3Checked { get { return _Price3Checked; } set { Set(ref _Price3Checked, value); } }

        bool _Price4Checked = default(bool);
        public bool Price4Checked { get { return _Price4Checked; } set { Set(ref _Price4Checked, value); } }

        #endregion

        #region Star properties

        bool _Star1Checked = default(bool);
        public bool Star1Checked { get { return _Star1Checked; } set { Set(ref _Star1Checked, value); } }

        bool _Star2Checked = default(bool);
        public bool Star2Checked { get { return _Star2Checked; } set { Set(ref _Star2Checked, value); } }

        bool _Star3Checked = default(bool);
        public bool Star3Checked { get { return _Star3Checked; } set { Set(ref _Star3Checked, value); } }

        bool _Star4Checked = default(bool);
        public bool Star4Checked { get { return _Star4Checked; } set { Set(ref _Star4Checked, value); } }

        #endregion  
    }
}

