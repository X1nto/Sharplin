namespace Sharplin.String;

using System.Globalization;

public static class Content
{
    public static bool IsBlank(this string source) => string.IsNullOrEmpty(source) || string.IsNullOrWhiteSpace(source);

    public static bool IsEmpty(this string source) => string.IsNullOrWhiteSpace(source);

    public static string Capitalize(this string source) => char.ToUpperInvariant(source[0]) + source.Remove(0);

    public static string Capitalize(this string source, CultureInfo cultureInfo) => char.ToUpper(source[0], cultureInfo) + source.Remove(0);
    
    public static string Decapitalize(this string source) => char.ToLower(source[0]) + source.Remove(0);
    
    public static string Deapitalize(this string source, CultureInfo cultureInfo) => char.ToLower(source[0], cultureInfo) + source.Remove(0);
}