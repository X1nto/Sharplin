namespace Sharplin.IEnumerable;

public static class Extensions
{
    #region Indexes

    /// <summary>
    ///     Searches for an element that matches the conditions defined by the specified predicate,
    ///     and returns the zero-based index of the first occurrence within the entire
    ///     <paramref name="enumerable"/>.
    /// </summary>
    /// <param name="enumerable"> The <see cref="IEnumerable{T}"/> to search.</param>
    /// <param name="match">
    ///     The <see cref="Predicate{T}"/> delegate that defines the conditions of the element to search for.
    /// </param>
    /// <typeparam name="TSource">The type of the elements of the <paramref name="enumerable"/>.</typeparam>
    /// <returns>
    ///     The zero-based index of the first occurrence of an element that matches the conditions defined by match, if found;
    ///     otherwise, -1.
    /// </returns>
    public static int FindIndex<TSource>(this IEnumerable<TSource> enumerable, Predicate<TSource> match)
    {
        int index = 0;

        foreach (TSource element in enumerable)
        {
            if (match(element))
                return index;

            checked
            {
                index++;
            }
        }

        return -1;
    }

    /// <summary>
    ///     Searches for an element that matches the conditions defined by the specified predicate,
    ///     and returns the zero-based index of the last occurrence within the entire
    ///     <paramref name="enumerable"/>.
    /// </summary>
    /// <param name="enumerable"> The <see cref="IEnumerable{T}"/> to search.</param>
    /// <param name="match">
    ///     The <see cref="Predicate{T}"/> delegate that defines the conditions of the element to search for.
    /// </param>
    /// <typeparam name="TSource">The type of the elements of the <paramref name="enumerable"/>.</typeparam>
    /// <returns>
    ///     The zero-based index of the last occurrence of an element that matches the conditions defined by match, if found;
    ///     otherwise, -1.
    /// </returns>
    public static int FindLastIndex<TSource>(this IEnumerable<TSource> enumerable, Predicate<TSource> match)
    {
        int lastIndex = -1;
        int index = 0;

        foreach (TSource element in enumerable)
        {
            if (match(element))
                lastIndex = index;
            checked
            {
                index++;
            }
        }

        return lastIndex;
    }

    #endregion
    
    /// <summary>
    ///     Performs the given <paramref name="action"/> on each element of the <paramref name="source"/>.
    /// </summary>
    public static void ForEach<TSource>(this IEnumerable<TSource> source, Action<TSource> action)
    {
        foreach (TSource item in source) action(item);
    }
}