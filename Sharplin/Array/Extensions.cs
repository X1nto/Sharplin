namespace Sharplin.Array;

public static class Extensions
{
    #region Indexes

    /// <inheritdoc cref="Array.FindIndex{T}(T[], Predicate{T})"/>
    public static int FindIndex<TSource>(this TSource[] array, Predicate<TSource> match) =>
        System.Array.FindIndex(array, match);

    /// <inheritdoc cref="Array.FindIndex{T}(T[], int, Predicate{T})"/>
    public static int FindIndex<TSource>(this TSource[] array, int startIndex, Predicate<TSource> match) =>
        System.Array.FindIndex(array, startIndex, match);

    /// <inheritdoc cref="Array.FindIndex{T}(T[], int, int, Predicate{T})"/>
    public static int FindIndex<TSource>(this TSource[] array, int startIndex, int count, Predicate<TSource> match) =>
        System.Array.FindIndex(array, startIndex, count, match);

    /// <inheritdoc cref="Array.FindLastIndex{T}(T[], Predicate{T})"/>
    public static int FindLastIndex<TSource>(this TSource[] array, Predicate<TSource> match) =>
        System.Array.FindLastIndex(array, match);

    /// <inheritdoc cref="Array.FindLastIndex{T}(T[], int, Predicate{T})"/>
    public static int FindLastIndex<TSource>(this TSource[] array, int startIndex, Predicate<TSource> match) =>
        System.Array.FindLastIndex(array, startIndex, match);

    /// <inheritdoc cref="Array.FindLastIndex{T}(T[], int, int, Predicate{T})"/>
    public static int FindLastIndex<TSource>(this TSource[] array, int startIndex, int count,
        Predicate<TSource> match) =>
        System.Array.FindLastIndex(array, startIndex, count, match);

    #endregion
}