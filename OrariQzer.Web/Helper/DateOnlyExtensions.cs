namespace OrariQzer.Domain.Extensions;

public static class DateOnlyExtensions
{
    public static string ToReadableDate(this DateOnly date)
    {
        string result;

        if (date.DayOfYear == DateTime.Now.DayOfYear)
        { result = "Oggi"; }
        else if (date.DayOfYear == DateTime.Now.DayOfYear + 1)
        { result = "Domani"; }
        else
        { result = date.ToString("dddd, dd MMMM"); }

        return result[0].ToString().ToUpper() + result.Substring(1);



    }
}