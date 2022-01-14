namespace Sharplin.String;

using System.Globalization;

public static class Capitalization
{
    /// <summary>Capitalizes the given <paramref name="source"/>.</summary>
    /// <returns>
    ///     A copy of <paramref name="source"/> having its first letter capitalized using the rules of the default
    ///     <see cref="CultureInfo"/>,
    ///     or the original string if it's empty or already starts with a capital letter.
    /// </returns>
    public static string Capitalize(this string source) => char.ToUpperInvariant(source[0]) + source.Remove(0, 1);

    /// <summary>Capitalizes the given <paramref name="source"/>.</summary>
    /// <returns>
    ///     A copy of <paramref name="source"/> having its first letter capitalized using the rules of the provided
    ///     <paramref name="cultureInfo"/>,
    ///     or the original string if it's empty or already starts with a capital letter.
    /// </returns>
    public static string Capitalize(this string source, CultureInfo cultureInfo) =>
        char.ToUpper(source[0], cultureInfo) + source.Remove(0, 1);

    /// <summary>Decapitalizes the given <paramref name="source"/>.</summary>
    /// <returns>
    ///     A copy of <paramref name="source"/> having its first letter decapitalized using the rules of the default
    ///     <see cref="CultureInfo"/>,
    ///     or the original string if it's empty or already starts with a lowercase letter.
    /// </returns>
    public static string Decapitalize(this string source) => char.ToLower(source[0]) + source.Remove(0, 1);

    /// <summary>Decapitalizes the given <paramref name="source"/>.</summary>
    /// <returns>
    ///     A copy of <paramref name="source"/> having its first letter decapitalized using the rules of the provided
    ///     <paramref name="cultureInfo"/>,
    ///     or the original string if it's empty or already starts with a lowercase letter.
    /// </returns>
    public static string Decapitalize(this string source, CultureInfo cultureInfo) =>
        char.ToLower(source[0], cultureInfo) + source.Remove(0, 1);
}