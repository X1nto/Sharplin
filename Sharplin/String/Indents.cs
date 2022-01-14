namespace Sharplin.String;

public static class Indents
{
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

    public static string TrimWhiteSpace(this string source) =>
        string.Join("", source.Where(c => !char.IsWhiteSpace(c)));

    /// <summary>
    ///     Detects a common minimal indent and replaces it with the specified <paramref name="newIndent" />.
    /// </summary>
    public static string ReplaceIndent(this string source, string newIndent = "")
    {
        string[] lines = source.Lines();

        int minCommonIndent = lines
            .Where(line => !string.IsNullOrWhiteSpace(line))
            .Select(line => line.IndentWidth())
            .Min();

        return lines.Reindent(
            Util.GetIndentAddFunction(newIndent),
            line => line.Remove(0, minCommonIndent));
    }
}