namespace Sharplin.String;

using System.Globalization;

public static class Capitalization
{
    public static string Capitalize(this string source) => char.ToUpperInvariant(source[0]) + source.Remove(0, 1);

    public static string Capitalize(this string source, CultureInfo cultureInfo) => char.ToUpper(source[0], cultureInfo) + source.Remove(0, 1);
    
    public static string Decapitalize(this string source) => char.ToLower(source[0]) + source.Remove(0, 1);
    
    public static string Decapitalize(this string source, CultureInfo cultureInfo) => char.ToLower(source[0], cultureInfo) + source.Remove(0, 1);

}