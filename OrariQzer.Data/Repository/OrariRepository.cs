using OrariQzer.ApplicationCore.Interfaces.Repository;
using OrariQzer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrariQzer.Domain.Repository
{
    public class OrariRepository : IOrariRepository
    {
        private readonly string url;
        public OrariRepository()
        {
            url = "https://docs.google.com/spreadsheets/d/1Yn1Hhv-pQivIv7OFeqIKgStzH-Px3vDopVyLrNWb3x4/export?format=csv";
        }
        public async Task<IEnumerable<Orari>> getOrari()
        {
            using var client = new HttpClient();

            
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string worksheet = await response.Content.ReadAsStringAsync();

            string[] worksheetsRows = worksheet.Split('\n');
            return worksheetsRows.Skip(1).Select(x => Orari.Parse(x)).Where(x => x.Day.DayOfYear >= DateTime.Now.DayOfYear);

        }

        public Task<Update> UpdateChecker()
        {
            throw new NotImplementedException();
        }
    }
}
