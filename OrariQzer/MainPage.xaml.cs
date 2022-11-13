using OrariQzer.ApplicationCore.Interfaces.Repository;
using OrariQzer.Domain.Entities;
using System.Collections.ObjectModel;

namespace OrariQzer
{


    public partial class MainPage : ContentPage
    {
        private readonly IOrariRepository _orariRepository;

        public MainPage(IOrariRepository orariRepository)
        {
            _orariRepository = orariRepository;
            InitializeComponent();
            refr.Refreshing += async (object sender, EventArgs e) => { await Refresh(); };
        }
        public MainPage()
        {
            InitializeComponent();
        }

        ObservableCollection<Orari> orari = new ObservableCollection<Orari>();
        internal ObservableCollection<Orari> Oraris { get { return orari; } }

        public async Task Refresh()
        {
            refr.IsRefreshing = true;
            Oraris.Clear();

            var _orari = await _orariRepository.getOrari();
            orari = new ObservableCollection<Orari>(_orari);

            cv.ItemsSource = orari;

            refr.IsRefreshing = false;

        }

        /* public async void Updater()
         {
             await Refresh();
             string url;
             if (g.UpdateChecker(out url))
             {
                 if (await DisplayAlert("Nuova versione disponibile", "Vuoi aggiornare?", "Si", "No"))
                 {
                     Uri uri = new Uri(url);
                     try
                     {
                         await Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
                     }
                     catch (Exception ex)
                     {
                         // An unexpected error occured. No browser may be installed on the device.
                     }
                 }
             }



         }*/

    }


}
