namespace Sharplin.String;

public static class Content
{
    /// <returns>true if <paramref name="source"/> is empty or consists solely of whitespace characters.</returns>
    public static bool IsBlank(this string source) => string.IsNullOrEmpty(source) || string.IsNullOrWhiteSpace(source);

    /// <returns>true if <paramref name="source"/> is empty (contains no characters).</returns>
    public static bool IsEmpty(this string source) => string.IsNullOrEmpty(source);
}