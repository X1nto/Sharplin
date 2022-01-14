namespace Sharplin.Collection;

public static class Indexes
{
    /// <returns>
    ///     Index of the first element matching the given <paramref name="predicate"/>, or -1 if
    ///     <paramref name="source"/> does not contain such element.
    /// </returns>
    /// <remarks>
    ///     If <paramref name="source"/> is of type <see cref="IList{T}"/>, this method calls
    ///     <see cref="IndexOfFirst{TSource}(System.Collections.Generic.IList{TSource},System.Predicate{TSource})"/> instead.
    /// </remarks>
    public static int IndexOfFirst<TSource>(this IEnumerable<TSource> source, Predicate<TSource> predicate)
    {
        if (source is IList<TSource> list)
            return IndexOfFirst(list, predicate);

        int index = 0;

        foreach (TSource element in source)
        {
            if (predicate(element))
                return index;

            checked
            {
                index++;
            }
        }

        return -1;
    }

    /// <returns>
    ///     index of the first element matching the given <paramref name="predicate"/>, or -1 if
    ///     <paramref name="source"/> does not contain such element.
    /// </returns>
    public static int IndexOfFirst<TSource>(this IList<TSource> source, Predicate<TSource> predicate)
    {
        foreach (int index in source.EIndices())
            if (predicate(source[index]))
                return index;

        return -1;
    }

    /// <returns>
    ///     Index of the last element matching the given <paramref name="predicate"/>, or -1 if
    ///     <paramref name="source"/> does not contain such element.
    /// </returns>
    /// <remarks>
    ///     If <paramref name="source"/> is of type <see cref="IList{T}"/>, this method calls
    ///     <see cref="IndexOfFirst{TSource}(System.Collections.Generic.IList{TSource},System.Predicate{TSource})"/> instead.
    /// </remarks>
    public static int IndexOfLast<TSource>(this IEnumerable<TSource> source, Predicate<TSource> predicate)
    {
        if (source is IList<TSource> list)
            return IndexOfLast(list, predicate);

        int lastIndex = -1;
        int index = 0;

        foreach (TSource element in source)
        {
            if (predicate(element))
                lastIndex = index;
            checked
            {
                index++;
            }
        }

        return lastIndex;
    }

    /// <returns>
    ///     Index of the last element matching the given <paramref name="predicate"/>, or -1 if
    ///     <paramref name="source"/> does not contain such element.
    /// </returns>
    public static int IndexOfLast<TSource>(this IList<TSource> source, Predicate<TSource> predicate)
    {
        foreach (int index in source.EIndices().Reverse())
            if (predicate(source[index]))
                return index;

        return -1;
    }

    /// <returns><see cref="Range"/> of valid indices for the <paramref name="source"/>.</returns>
    public static Range Indices<TSource>(this ICollection<TSource> source) => ..source.Count;

    /// <returns><see cref="Enumerable.Range(int, int)"/> for the <paramref name="source"/>.</returns>
    public static IEnumerable<int> EIndices<TSource>(this ICollection<TSource> source) =>
        Enumerable.Range(0, source.Count);

    /// <returns>Index of the last element in <paramref name="source"/>.</returns>
    public static int LastIndex<TSource>(this ICollection<TSource> source) => source.Count - 1;
}