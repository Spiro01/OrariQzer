using OrariQzer.Domain.Entities;

namespace OraiQzer.Api.Extensions;

public static class StringExtensions
{
    public static Schedule ToSchedule(this string[] row)
    {
        
        try
        {
            return new Schedule(row[6], row[5], row[7], row[3], row[1], row[2]);
        }
        catch { return null; }
    }
}