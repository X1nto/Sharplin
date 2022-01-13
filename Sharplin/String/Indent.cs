namespace Sharplin.String;

using Collection;

public static class Indent
{
    private const string DefaultMarginPrefix = "|";
    
    public static string TrimMargin(this string source, string marginPrefix = DefaultMarginPrefix) => source.ReplaceIndentByMargin(marginPrefix: marginPrefix);

    public static string ReplaceIndentByMargin(this string source, string newIndent = "", string marginPrefix = DefaultMarginPrefix)
    {
        if (string.IsNullOrWhiteSpace(marginPrefix))
            throw new ArgumentException("marginPrefix must be non-blank string.", nameof(marginPrefix));

        string[] lines = source.Split('\r');

        return lines.Reindent(GetIndentAddFunction(newIndent), line =>
        {
            int firstNonWhitespaceIndex = line.ToCharArray().IndexOfFirst(c => !char.IsWhiteSpace(c));

            if (firstNonWhitespaceIndex == -1)
                return null;

            if (line.Remove(0, firstNonWhitespaceIndex).StartsWith(marginPrefix))
                return line.Substring(firstNonWhitespaceIndex + marginPrefix.Length);
            
            return null;
        });
    }
    
    public static string TrimIndent(this string source) => source.ReplaceIndent();

    public static string TrimWhiteSpace(this string source) => string.Join("", source.Where(c => !char.IsWhiteSpace(c)));

    public static string ReplaceIndent(this string source, string newIndent = "")
    {
        string[] lines = source.Split('\r');

        int minCommonIndent = lines
            .Where(line => !string.IsNullOrWhiteSpace(line))
            .Select(line => line.IndentWidth())
            .Min();

        return lines.Reindent(
            GetIndentAddFunction(newIndent),
            line => line.Remove(0, minCommonIndent));
    }

    private static int IndentWidth(this string source)
    {
        int nonWhitespaceIndex = source.ToCharArray()
            .IndexOfFirst(c => !string.IsNullOrWhiteSpace(c.ToString()));

        return nonWhitespaceIndex != -1 ? nonWhitespaceIndex : source.Length;
    }

    private static Func<string, string> GetIndentAddFunction(string indent)
    {
        if (string.IsNullOrEmpty(indent))
            return line => line;

        return line => indent + line;
    }

    private static string Reindent(
        this IReadOnlyCollection<string> source,
        Func<string, string> indentAddFunction,
        Func<string, string?> indentCutFunction)
    {
        int lastIndex = source.Count - 1;

        var transform = source
            .Where((value, index) => !(index == 0 || index == lastIndex) && !string.IsNullOrWhiteSpace(value))
            .Select(value =>
            {
                string? cut = indentCutFunction(value);
                return cut is null ? value : indentAddFunction(cut);
            });

        return string.Join("\n", transform);
    }
}