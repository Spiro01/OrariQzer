namespace OrariQzer.ApplicationCore.Interfaces.Repository;

public interface IClientReportRepository
{
    public Task ReportError(Exception error);
}