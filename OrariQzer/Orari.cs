using System.Globalization;
namespace OrariQzer
{
    internal class Orari
    {
        private string _nome;
        public string nome { get => "📕" + _nome; set => _nome = value; }

        private string _data;
        public string data { get => giornoSettimana(); set => _data = value; }
        public DateTime parsed_date { get => DateTime.ParseExact(_data, "dd-MMM-yy", CultureInfo.CreateSpecificCulture("it-IT")); }

        
        private string _professore;
        public string professore { get => "👷‍" + _professore;  set => _professore = value; }

        public string aula { get; set; }
        public string inizio { get; set; }
        public string fine { get; set; }

        public string ora { get => inizio + " - " + fine; }
        public string aulaora { get => "🕗" + ora + " | " + "📌" + aula; }

        private string giornoSettimana()
        {
            string result;
            try { 
            //DateTime date = DateTime.ParseExact(_data, "dd-MMM-yy", CultureInfo.CreateSpecificCulture("it-IT"));
            

            if (parsed_date.DayOfYear == DateTime.Now.DayOfYear)
            { result = "Oggi"; }
            else if (parsed_date.DayOfYear == DateTime.Now.DayOfYear + 1) 
            { result = "Domani"; }
            else 
            { result = parsed_date.ToString("dddd"); }

            result = "📆 " + result[0].ToString().ToUpper() + result.Substring(1);
            }
            catch { result = ""; }
             return result; 
            
        }

        public static Orari Parse(string row)
        {
            string[] columns = row.Split(',');
            try { 
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



}
