namespace Sharplin.String;

public static class Indent
{
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
            Util.GetIndentAddFunction(newIndent),
            line => line.Remove(0, minCommonIndent));
    }
}