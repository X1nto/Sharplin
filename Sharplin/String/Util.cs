namespace Sharplin.String;

using Collection;

public static class Util
{
    internal static int IndentWidth(this string source)
    {
        int nonWhitespaceIndex = source.ToCharArray()
            .FindIndex(c => !string.IsNullOrWhiteSpace(c.ToString()));

        return nonWhitespaceIndex != -1 ? nonWhitespaceIndex : source.Length;
    }

    internal static Func<string, string> GetIndentAddFunction(string indent)
    {
        if (string.IsNullOrEmpty(indent))
            return line => line;

        return line => indent + line;
    }

    internal static string Reindent(
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