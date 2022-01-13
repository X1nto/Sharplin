namespace Sharplin.String;

using Collection;

public static class Margins
{
    private const string DefaultMarginPrefix = "|";
    
    /// <summary>
    /// Trims leading whitespace characters followed by <paramref name="marginPrefix"/> from every line of a source string and removes
    /// the first and the last lines if they are blank.
    /// </summary>
    /// <remarks>
    /// Doesn't affect a line if it doesn't contain <paramref name="marginPrefix"/> except the first and the last blank lines.
    /// </remarks>
    /// <remarks>Doesn't preserve the original line endings.</remarks>
    /// <param name="marginPrefix">non-blank string, which is used as a margin delimiter. Default is <see cref="DefaultMarginPrefix"/>.</param>
    public static string TrimMargin(this string source, string marginPrefix = DefaultMarginPrefix) => source.ReplaceIndentByMargin(marginPrefix: marginPrefix);

    /// <summary>
    /// Detects indent by <paramref name="marginPrefix"/> and replaces it with <paramref name="newIndent"/>.
    /// </summary>
    /// <param name="marginPrefix">non-blank string, which is used as a margin delimiter. Default is <see cref="DefaultMarginPrefix"/>.</param>
    /// <exception cref="ArgumentException">If <paramref name="marginPrefix"/> is blank.</exception>
    public static string ReplaceIndentByMargin(this string source, string newIndent = "", string marginPrefix = DefaultMarginPrefix)
    {
        if (marginPrefix.IsBlank())
            throw new ArgumentException("marginPrefix must be non-blank string.", nameof(marginPrefix));

        string[] lines = source.Lines();

        return lines.Reindent(Util.GetIndentAddFunction(newIndent), line =>
        {
            int firstNonWhitespaceIndex = line.ToCharArray().IndexOfFirst(c => !char.IsWhiteSpace(c));

            if (firstNonWhitespaceIndex == -1)
                return null;

            if (line.Remove(0, firstNonWhitespaceIndex).StartsWith(marginPrefix))
                return line.Substring(firstNonWhitespaceIndex + marginPrefix.Length);
            
            return null;
        });
    }

}