using OrariQzer.Domain.Entities;
using System.Linq;

namespace OraiQzer.Api.Extensions;

public static class StringExtensions
{
    public static Schedule ToSchedule(this string[] row)
        => new(row.ElementAtOrDefault(6), row.ElementAtOrDefault(5), row.ElementAtOrDefault(7), row.ElementAtOrDefault(3), row.ElementAtOrDefault(1), row.ElementAtOrDefault(2));

}