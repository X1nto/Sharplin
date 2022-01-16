namespace Sharplin.HashSet;

public class Builders
{
    /// <returns>A <see cref="HashSet{T}"/> containing the given <paramref name="items"/></returns>
    public static HashSet<TSource> HashSetOf<TSource>(params TSource[] items) => items.ToHashSet();
}