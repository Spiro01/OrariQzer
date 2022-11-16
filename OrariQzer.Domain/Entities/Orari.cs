using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrariQzer.Domain.Entities
{
    public class Orari
    {
        public string Materia { get; set; }
        private string _data;
        public string DateStr { get => giornoSettimana(); set => _data = value; }

        public string Professore { get; set; }
        public string Aula { get; set; }
        public string Inizio { get; set; }
        public string Fine { get; set; }
        public string Orario { get => Inizio + " - " + Fine; }

        public DateTime Day
        {
            get
            {
                if (DateTime.TryParseExact(_data, "dd-MMM-yy", CultureInfo.InvariantCulture,
                        DateTimeStyles.None, out DateTime date))
                {
                    return date;
                }
                return DateTime.MinValue;
            }
        }



        private string giornoSettimana()
        {
            string result;
            try
            {
                //DateTime date = DateTime.ParseExact(_data, "dd-MMM-yy", CultureInfo.CreateSpecificCulture("it-IT"));


                if (Day.DayOfYear == DateTime.Now.DayOfYear)
                { result = "Oggi"; }
                else if (Day.DayOfYear == DateTime.Now.DayOfYear + 1)
                { result = "Domani"; }
                else
                { result = Day.ToString("dddd"); }

                return result[0].ToString().ToUpper() + result.Substring(1);
            }
            catch { result = ""; }
            return result;

        }

        public static Orari Parse(string row)
        {
            string[] columns = row.Split(',');
            try
            {
                return new Orari
                {
                    Materia = columns[6],
                    DateStr = columns[3],
                    Aula = columns[7],
                    Professore = columns[5],
                    Inizio = columns[1],
                    Fine = columns[2],
                };
            }
            catch { return null; }
        }
    }
}
