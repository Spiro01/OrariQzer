namespace OrariQzer
{
    internal class GSheet : Orari
    {
        static readonly HttpClient client = new HttpClient();
        public List<Orari> ParsedList = new List<Orari>();
        private string par;

        public async Task GetFromGs()
        {
            string par = "";
            try
            {
                HttpResponseMessage response = await client.GetAsync("https://docs.google.com/spreadsheets/d/1wbo3evHXAm17KoWs9758ujqA6Y4reK6lbhn6CimEZtg/export?format=csv");
                response.EnsureSuccessStatusCode();
                par = await response.Content.ReadAsStringAsync();
            }
            catch { }

            ParsedList.Clear();
            string[] rows = par.Split('\n');
            ParsedList = rows.Skip(1).Select(x => Orari.Parse(x)).Where(x => x.parsed_date.DayOfYear >= DateTime.Now.DayOfYear).ToList();
            this.par = par;

        }

        public bool UpdateChecker(out string url)
        {
                double app_vers = 2.0;
                url = "";
                string updaterow = par.Split('\n')[0];
                url = updaterow.Split(',')[0];
                if (!string.IsNullOrEmpty(url))
                {
                    double current_vers = app_vers;
                    Double.TryParse(updaterow.Split(',')[1], out current_vers);
                    if (app_vers < current_vers) { return true; }
                    else { return false; }
                }
                else return false;
            
        }
    }
}