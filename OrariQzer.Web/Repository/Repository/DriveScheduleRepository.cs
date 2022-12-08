using OrariQzer.ApplicationCore.Interfaces.Repository;
using OrariQzer.Domain.Entities;
using System.Net.Http.Json;
using System;
using OraiQzer.Api.Extensions;

namespace OrariQzer.Domain.Repository;

public class DriveScheduleRepository : IClientScheduleRepository
{

    private readonly string url;


    public DriveScheduleRepository(IConfiguration configuration)
    {
        url = configuration.GetConnectionString("BaseUrl")!;

    }

    public async Task<IEnumerable<Schedule>> getOrari()
    {
        using var client = new HttpClient();

        HttpResponseMessage response = await client.GetAsync(url);
        response.EnsureSuccessStatusCode();
        var rows = await response.Content.ReadFromJsonAsync<IEnumerable<string[]?>>();

        return rows!
            .Select(x => x?.ToSchedule())
            .Where(x => x is not null)!;

    }
}