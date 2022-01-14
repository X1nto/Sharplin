namespace Sharplin.Collection;

public static class Indexes
{
    /// <returns><see cref="Range"/> of valid indices for the <paramref name="source"/>.</returns>
    public static Range Indices<TSource>(this ICollection<TSource> source) => ..source.Count;

    /// <returns><see cref="Enumerable.Range(int, int)"/> for the <paramref name="source"/>.</returns>
    public static IEnumerable<int> EIndices<TSource>(this ICollection<TSource> source) =>
        Enumerable.Range(0, source.Count);

    /// <returns>Index of the last element in <paramref name="source"/>.</returns>
    public static int LastIndex<TSource>(this ICollection<TSource> source) => source.Count - 1;
}