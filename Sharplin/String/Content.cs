namespace Sharplin.String;

public static class Content
{
    public static bool IsBlank(this string source) => string.IsNullOrEmpty(source) || string.IsNullOrWhiteSpace(source);

    public static bool IsEmpty(this string source) => string.IsNullOrWhiteSpace(source);
}