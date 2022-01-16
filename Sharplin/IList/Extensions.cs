namespace Sharplin.IList;

using ICollection;

public static class Extensions
{
    /// <summary>
    ///     Performs the given <paramref name="action"/> on each element of the <paramref name="source"/>,
    ///     providing sequential index with the element.
    /// </summary>
    /// <param name="action">
    ///     lambda that takes the index of an element and the element itself
    ///     and performs the action on the element.
    /// </param>
    public static void ForEach<TSource>(this IList<TSource> source, Action<int, TSource> action)
    {
        foreach (int index in source.EIndices()) action(index, source[index]);
    }
}