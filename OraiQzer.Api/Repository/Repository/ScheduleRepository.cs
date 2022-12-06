using OrariQzer.ApplicationCore.Interfaces.Repository;
using OrariQzer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OraiQzer.Api.Extensions;

namespace OrariQzer.Domain.Repository
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly string url;
        private readonly IConfiguration _configuration;

        public ScheduleRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            url = _configuration.GetConnectionString("DriveSheet")!;
        }


        public async Task<IEnumerable<Schedule>> getSchedule(bool fromToday = false)
        {
            using var client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string worksheet = await response.Content.ReadAsStringAsync();

            return worksheet.Split('\n')
                .Skip(1)
                .Select(x => x.ToSchedule())
                .Where(x => !fromToday || x.WeekDay.DayOfYear >= DateTime.Now.DayOfYear);

        }

    }
}
