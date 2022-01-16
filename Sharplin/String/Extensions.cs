namespace Sharplin.String;

using System.Globalization;
using Array;

public static class Extensions
{
    //TODO implement our own checkers instead of relying on string
    #region Blank and Empty

    /// <returns>true if <paramref name="source"/> is empty or consists solely of whitespace characters.</returns>
    public static bool IsBlank(this string source) => string.IsNullOrEmpty(source) || string.IsNullOrWhiteSpace(source);

    /// <returns>true if <paramref name="source"/> is empty (contains no characters).</returns>
    public static bool IsEmpty(this string source) => string.IsNullOrEmpty(source);

    /// <returns>true if <paramref name="source"/> is not blank.</returns>
    public static bool IsNotBlank(this string source) => !source.IsBlank();

    /// <returns>true if <paramref name="source"/> is not empty.</returns>
    public static bool IsNotEmpty(this string source) => !source.IsEmpty();

    #endregion
    
    /// <summary>
    ///     Splits <paramref name="source"/> to an array of lines delimited by any of the following character sequences: CRLF,
    ///     LF or CR.
    /// </summary>
    /// <remarks>The lines returned do not include terminating line separators.</remarks>
    public static string[] Lines(this string source) =>
        source.Split(new[] {"\r\n", "\n", "\r"}, StringSplitOptions.None);
    
    #region Capitalization

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


    #endregion

    #region Indentation

    private const string DefaultMarginPrefix = "|";
    
    /// <summary>
    ///     Detects a common minimal indent of all the input lines, removes it from every line and also removes the first and
    ///     the last
    ///     lines if they are blank.
    /// </summary>
    /// <remarks>Blank lines do not affect the detected indent level.</remarks>
    /// <remarks>
    ///     In case if there are non-blank lines with no leading whitespace characters (no indent at all) then the
    ///     common indent is 0, and therefore this function doesn't change the indentation.
    /// </remarks>
    /// <remarks>Doesn't preserve the original line endings.</remarks>
    public static string TrimIndent(this string source) => source.ReplaceIndent();

    /// <summary>
    ///     Detects a common minimal indent and replaces it with the specified <paramref name="newIndent"/>.
    /// </summary>
    public static string ReplaceIndent(this string source, string newIndent = "")
    {
        string[] lines = source.Lines();

        int minCommonIndent = lines
            .Where(IsNotBlank)
            .Select(line => line.IndentWidth())
            .Min();

        return lines.Reindent(
            Util.GetIndentAddFunction(newIndent),
            line => line.Remove(0, minCommonIndent));
    }

    /// <summary>
    ///     Trims leading whitespace characters followed by <paramref name="marginPrefix"/> from every line of a source string
    ///     and removes
    ///     the first and the last lines if they are blank.
    /// </summary>
    /// <remarks>
    ///     Doesn't affect a line if it doesn't contain <paramref name="marginPrefix"/> except the first and the last blank
    ///     lines.
    /// </remarks>
    /// <remarks>Doesn't preserve the original line endings.</remarks>
    /// <param name="marginPrefix">
    ///     non-blank string, which is used as a margin delimiter. Default is
    ///     <see cref="DefaultMarginPrefix"/>.
    /// </param>
    public static string TrimMargin(this string source, string marginPrefix = DefaultMarginPrefix) =>
        source.ReplaceIndentByMargin(marginPrefix: marginPrefix);

    /// <summary>
    ///     Detects indent by <paramref name="marginPrefix"/> and replaces it with <paramref name="newIndent"/>.
    /// </summary>
    /// <param name="marginPrefix">
    ///     non-blank string, which is used as a margin delimiter. Default is
    ///     <see cref="DefaultMarginPrefix"/>.
    /// </param>
    /// <exception cref="ArgumentException">If <paramref name="marginPrefix"/> is blank.</exception>
    public static string ReplaceIndentByMargin(this string source, string newIndent = "",
        string marginPrefix = DefaultMarginPrefix)
    {
        if (marginPrefix.IsBlank())
            throw new ArgumentException($"{nameof(marginPrefix)} must be non-blank string.", nameof(marginPrefix));

        return source.Lines().Reindent(Util.GetIndentAddFunction(newIndent), line =>
        {
            int firstNonWhitespaceIndex = line.FindIndex(c => !char.IsWhiteSpace(c));

            if (firstNonWhitespaceIndex == -1)
                return null;

            if (line.Remove(0, firstNonWhitespaceIndex).StartsWith(marginPrefix))
                return line[(firstNonWhitespaceIndex + marginPrefix.Length)..];

            return null;
        });
    }

    #endregion

    #region Indexes

    /// <inheritdoc cref="Array.FindIndex{T}(T[], Predicate{T})"/>
    public static int FindIndex(this string source, Predicate<char> match) =>
        source.ToCharArray().FindIndex(match);

    /// <inheritdoc cref="Array.FindIndex{T}(T[], int, Predicate{T})"/>
    public static int FindIndex(this string source, int startIndex, Predicate<char> match) =>
        source.ToCharArray().FindIndex(startIndex, match);

    /// <inheritdoc cref="Array.FindIndex{T}(T[], int, int, Predicate{T})"/>
    public static int FindIndex(this string source, int startIndex, int count,
        Predicate<char> match) =>
        source.ToCharArray().FindIndex(startIndex, count, match);

    /// <inheritdoc cref="Array.FindLastIndex{T}(T[], Predicate{T})"/>
    public static int FindLastIndex(this string source, Predicate<char> match) =>
        source.ToCharArray().FindLastIndex(match);

    /// <inheritdoc cref="Array.FindLastIndex{T}(T[], int, Predicate{T})"/>
    public static int FindLastIndex(this string source, int startIndex, Predicate<char> match) =>
        source.ToCharArray().FindLastIndex(startIndex, match);

    /// <inheritdoc cref="Array.FindLastIndex{T}(T[], int, int, Predicate{T})"/>
    public static int FindLastIndex(this string source, int startIndex, int count,
        Predicate<char> match) =>
        source.ToCharArray().FindLastIndex(startIndex, count, match);

    #endregion
}