namespace Sharplin.Array;

public static class Builders
{
    /// <returns>An array containing the given <paramref name="items"/></returns>
    public static TSource[] ArrayOf<TSource>(params TSource[] items) => items;
}