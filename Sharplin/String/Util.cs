namespace Sharplin.String;

using IReadOnlyCollection;
using Scope;

internal static class Util
{
    internal static int IndentWidth(this string source) => source
        .FindIndex(c => !char.IsWhiteSpace(c))
        .Let(index => index == -1 ? source.Length : index);

    internal static Func<string, string> GetIndentAddFunction(string indent)
    {
        if (indent.IsEmpty())
            return line => line;

        return line => indent + line;
    }

    internal static string Reindent(
        this IReadOnlyCollection<string> source,
        Func<string, string> indentAddFunction,
        Func<string, string?> indentCutFunction)
    {
        var transform = source
            .Where((value, index) => !(index == 0 || index == source.LastIndex()) && value.IsNotBlank())
            .Select(value => indentCutFunction(value)?.Let(indentAddFunction) ?? value);

        return string.Join("\n", transform);
    }
}