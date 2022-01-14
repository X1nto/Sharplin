namespace Sharplin.String;

public static class Content
{
    /// <returns>true if <paramref name="source" /> is empty or consists solely of whitespace characters.</returns>
    public static bool IsBlank(this string source) => string.IsNullOrEmpty(source) || string.IsNullOrWhiteSpace(source);

    /// <returns>true if <paramref name="source" /> is empty (contains no characters).</returns>
    public static bool IsEmpty(this string source) => string.IsNullOrEmpty(source);

    /// <summary>
    ///     Splits <paramref name="source" /> to an array of lines delimited by any of the following character sequences: CRLF,
    ///     LF or CR.
    /// </summary>
    /// <remarks>The lines returned do not include terminating line separators.</remarks>
    public static string[] Lines(this string source) =>
        source.Split(new[] {"\r\n", "\n", "\r"}, StringSplitOptions.None);
}