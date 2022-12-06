namespace OrariQzer.Domain.Entities;

public record ErrorReport
{
    public required DateTime Date { get; set; }
    public required string Message { get; set; }
    public string? InnerException { get; set; }

}