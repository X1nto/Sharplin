namespace Sharplin.List;

public static class Builders
{
    /// <returns>A <see cref="List{T}"/> containing the given <paramref name="items"/></returns>
    public static List<TSource> ListOf<TSource>(params TSource[] items) => items.ToList();
}