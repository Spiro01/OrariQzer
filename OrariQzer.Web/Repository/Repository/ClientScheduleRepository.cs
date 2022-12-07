using OrariQzer.ApplicationCore.Interfaces.Repository;
using OrariQzer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace OrariQzer.Domain.Repository
{
    public class ClientScheduleRepository : IClientScheduleRepository
    {
        private readonly string url;

        public ClientScheduleRepository (IConfiguration configuration)
        {
            url = configuration.GetConnectionString("BaseUrl")!;
        }


        public async Task<IEnumerable<Schedule>> getOrari()
        {
            using var client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync($"{url}/orari");
            response.EnsureSuccessStatusCode();
            

           var result = await response.Content.ReadFromJsonAsync<IEnumerable<Schedule>>() ?? new List<Schedule>();

           return result;

        }


    }
}
