using System.Net.Http.Json;
using OrariQzer.ApplicationCore.Interfaces.Repository;
using OrariQzer.Domain.Entities;

namespace OrariQzer.Domain.Repository;

public class ClientReportRepository : IClientReportRepository
{
    private readonly string _baseUrl;

    public ClientReportRepository(IConfiguration configuration)
    {
        _baseUrl = configuration.GetConnectionString("BaseUrl")!;
    }

    public async Task ReportError(Exception ex)
    {

        var report = new ErrorReport
        {
            Date = DateTime.Now,
            Message = ex.Message,
            InnerException = ex.InnerException?.ToString()
        };

        using var httpClient = new HttpClient();



        await httpClient.PostAsJsonAsync(_baseUrl + "/reports/error", report);
    }
}