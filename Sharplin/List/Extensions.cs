namespace Sharplin.List;

public static class Extensions
{
    #region Indexes

    /// <inheritdoc cref="List{T}.FindIndex(Predicate{T})"/>
    public static int FindIndex<TSource>(this List<TSource> list, Predicate<TSource> match) =>
        list.FindIndex(match);

    /// <inheritdoc cref="List{T}.FindIndex(int, Predicate{T})"/>
    public static int FindIndex<TSource>(this List<TSource> list, int startIndex, Predicate<TSource> match) =>
        list.FindIndex(startIndex, match);

    /// <inheritdoc cref="List{T}.FindIndex(int, int, Predicate{T})"/>
    public static int FindIndex<TSource>(this List<TSource> list, int startIndex, int count,
        Predicate<TSource> match) =>
        list.FindIndex(startIndex, count, match);

    /// <inheritdoc cref="List{T}.FindLastIndex(Predicate{T})"/>
    public static int FindLastIndex<TSource>(this List<TSource> list, Predicate<TSource> match) =>
        list.FindLastIndex(match);

    /// <inheritdoc cref="List{T}.FindLastIndex(int, Predicate{T})"/>
    public static int FindLastIndex<TSource>(this List<TSource> list, int startIndex, Predicate<TSource> match) =>
        list.FindLastIndex(startIndex, match);

    /// <inheritdoc cref="List{T}.FindLastIndex(int, int, Predicate{T})"/>
    public static int FindLastIndex<TSource>(this List<TSource> list, int startIndex, int count,
        Predicate<TSource> match) =>
        list.FindLastIndex(startIndex, count, match);

    #endregion
}