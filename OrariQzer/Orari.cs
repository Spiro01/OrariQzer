using System.Globalization;
namespace OrariQzer
{
    public class Orari
    {
        private string _nome;
        public string nome { get => "📕" + _nome; set => _nome = value; }

        private string _data;
        public string data { set => _data = value; }
        public DateTime parsed_date { get => DateTime.ParseExact(_data, "dd-MMM-yy", CultureInfo.CreateSpecificCulture("it-IT")); }


        private string _professore;
        public string professore { get => "👷‍" + _professore; set => _professore = value; }

        public string aula { get; set; }
        public string inizio { get; set; }
        public string fine { get; set; }

        public string ora { get => inizio + " - " + fine; }
        public string aulaora { get => ("🕗" + ora + " | " + "📌" + aula).Replace('\r', ' '); }

        public static Orari Parse(string row)
        {
            string[] columns = row.Split(',');
            try
            {
                return new Orari
                {
                    nome = columns[6],
                    data = columns[3],
                    aula = columns[7],
                    professore = columns[5],
                    inizio = columns[1],
                    fine = columns[2],
                };
            }
            catch { return null; }
        }
    }

    public class LOrari : List<Orari>
    {
        public DateTime day { get; set; }
        public string days { get => giornoSettimana(); set => day = DateTime.Parse(value); }

        public LOrari(string days, List<Orari> orari) : base(orari)
        {
            this.days = days;
        }

        public static List<LOrari> groupDay(IEnumerable<Orari> _orari)
        {
            List<LOrari> result = new List<LOrari>();
            var days = _orari.Select(x => x.parsed_date).Distinct().ToList();
            foreach (var day in days) result.Add(new LOrari(day.ToString(), _orari.Where(x => x.parsed_date == day).ToList()));
            return result;
        }

        private string giornoSettimana()
        {
            string result;
            try
            {
                if (day.DayOfYear == DateTime.Now.DayOfYear)
                { result = "Oggi"; }
                else if (day.DayOfYear == DateTime.Now.DayOfYear + 1)
                { result = "Domani"; }
                else
                { result = day.ToString("dddd dd MMMM"); }

                result = " "+ result[0].ToString().ToUpper() + result.Substring(1);
            }
            catch { result = ""; }
            return result;

        }
    }
}
