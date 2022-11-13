namespace OrariQzer
{


    public partial class MainPage : ContentPage
    {
        public List<LOrari> oraribyday;
        GSheet g = new GSheet();

        public MainPage()
        {

            InitializeComponent();

#if __ANDROID__
            Updater();

#elif WINDOWS10_0_19041_0_OR_GREATER
            Refresh();
#endif


            refr.Refreshing += Refr_Refreshing;
        }

        private async void Refr_Refreshing(object sender, EventArgs e)
        {

            await Refresh();

        }

        public async Task Refresh()
        {
            refr.IsRefreshing = true;

            await g.GetFromGs();
            oraribyday = LOrari.groupDay(g.ParsedList);
            cv.ItemsSource = oraribyday;

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
