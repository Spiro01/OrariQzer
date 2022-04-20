
using System.Collections.ObjectModel;

namespace OrariQzer
{


    public partial class MainPage : ContentPage
    {

        ObservableCollection<Orari> orari = new ObservableCollection<Orari>();
        internal ObservableCollection<Orari> Oraris { get { return orari; } }
        GSheet g = new GSheet();

        public MainPage()
        {
            InitializeComponent();

#if __ANDROID__
            Updater();
#endif


            refr.Refreshing += Refr_Refreshing;
        }

        private void Refr_Refreshing(object sender, EventArgs e)
        {

            Refresh();

        }

        public async Task Refresh()
        {


            refr.IsRefreshing = true;
            Oraris.Clear();

            await g.GetFromGs();

            orari = new ObservableCollection<Orari>(g.ParsedList);

            cv.ItemsSource = orari;

            refr.IsRefreshing = false;



        }

        public async void Updater()
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



        }

    }


}

