namespace Sharplin.String;

using Collection;

public static class Margins
{
    private const string DefaultMarginPrefix = "|";
    
    public static string TrimMargin(this string source, string marginPrefix = DefaultMarginPrefix) => source.ReplaceIndentByMargin(marginPrefix: marginPrefix);

    public static string ReplaceIndentByMargin(this string source, string newIndent = "", string marginPrefix = DefaultMarginPrefix)
    {
        if (string.IsNullOrWhiteSpace(marginPrefix))
            throw new ArgumentException("marginPrefix must be non-blank string.", nameof(marginPrefix));

        string[] lines = source.Split('\r');

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