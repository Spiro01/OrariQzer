using OrariQzer.Domain.Entities;

namespace OraiQzer.Api.Extensions;

public static class StringExtensions
{
    public static Schedule ToSchedule(this string row)
    {
        string[] columns = row.Split(',');
        try
        {
            return new Schedule(columns[6], columns[5], columns[7], columns[3], columns[1], columns[2]);
        }
        catch { return null; }
    }
}