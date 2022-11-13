using System.Text.RegularExpressions;

namespace OrariQzer.Domain.Extensions;

public static class StringExtensions
{
    public static string FirstCharToUpper(this string input) =>
        input switch
        {
            null => "",
            "" => "",
            _ => string.Concat(input[0].ToString().ToUpper(), input.AsSpan(1))
        };
}