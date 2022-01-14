namespace Sharplin.Collection;

using System;
using System.Collections.Generic;

public static class Indexes
{
    /// <returns><see cref="Range"/> of valid indices for the <paramref name="source"/>.</returns>
    public static Range Indices<TSource>(this ICollection<TSource> source) => ..source.Count;

    /// <returns><see cref="Enumerable.Range(int, int)"/> for the <paramref name="source"/>.</returns>
    public static IEnumerable<int> EIndices<TSource>(this ICollection<TSource> source) =>
        Enumerable.Range(0, source.Count);

    /// <returns>Index of the last element in <paramref name="source"/>.</returns>
    public static int LastIndex<TSource>(this ICollection<TSource> source) => source.Count - 1;

    /// <inheritdoc cref="Array.FindIndex{T}(T[], Predicate{T})"/>
    public static int FindIndex<TSource>(this TSource[] array, Predicate<TSource> match) =>
        Array.FindIndex(array, match);
    
    /// <inheritdoc cref="Array.FindIndex{T}(T[], int, Predicate{T})"/>
    public static int FindIndex<TSource>(this TSource[] array, int startIndex, Predicate<TSource> match) =>
        Array.FindIndex(array, startIndex, match);
    
    /// <inheritdoc cref="Array.FindIndex{T}(T[], int, int, Predicate{T})"/>
    public static int FindIndex<TSource>(this TSource[] array, int startIndex, int count, Predicate<TSource> match) =>
        Array.FindIndex(array, startIndex, count, match);
    
    /// <inheritdoc cref="Array.FindLastIndex{T}(T[], Predicate{T})"/>
    public static int FindLastIndex<TSource>(this TSource[] array, Predicate<TSource> match) =>
        Array.FindLastIndex(array, match);
    
    /// <inheritdoc cref="Array.FindLastIndex{T}(T[], int, Predicate{T})"/>
    public static int FindLastIndex<TSource>(this TSource[] array, int startIndex, Predicate<TSource> match) =>
        Array.FindLastIndex(array, startIndex, match);
    
    /// <inheritdoc cref="Array.FindLastIndex{T}(T[], int, int, Predicate{T})"/>
    public static int FindLastIndex<TSource>(this TSource[] array, int startIndex, int count, Predicate<TSource> match) =>
        Array.FindLastIndex(array, startIndex, count, match);
    
    /// <inheritdoc cref="List{T}.FindIndex(Predicate{T})"/>
    public static int FindIndex<TSource>(this List<TSource> list, Predicate<TSource> match) =>
        list.FindIndex(match);
    
    /// <inheritdoc cref="List{T}.FindIndex(int, Predicate{T})"/>
    public static int FindIndex<TSource>(this List<TSource> list, int startIndex, Predicate<TSource> match) =>
        list.FindIndex(startIndex, match);
    
    /// <inheritdoc cref="List{T}.FindIndex(int, int, Predicate{T})"/>
    public static int FindIndex<TSource>(this List<TSource> list, int startIndex, int count, Predicate<TSource> match) =>
        list.FindIndex(startIndex, count, match);
    
    /// <inheritdoc cref="List{T}.FindLastIndex(Predicate{T})"/>
    public static int FindLastIndex<TSource>(this List<TSource> list, Predicate<TSource> match) =>
        list.FindLastIndex(match);
    
    /// <inheritdoc cref="List{T}.FindLastIndex(int, Predicate{T})"/>
    public static int FindLastIndex<TSource>(this List<TSource> list, int startIndex, Predicate<TSource> match) =>
        list.FindLastIndex(startIndex, match);
    
    /// <inheritdoc cref="List{T}.FindLastIndex(int, int, Predicate{T})"/>
    public static int FindLastIndex<TSource>(this List<TSource> list, int startIndex, int count, Predicate<TSource> match) =>
        list.FindLastIndex(startIndex, count, match);
    
    /// <summary>
    /// Searches for an element that matches the conditions defined by the specified predicate,
    /// and returns the zero-based index of the first occurrence within the entire
    /// <paramref name="enumerable"/>.
    /// </summary>
    /// <param name="enumerable"> The <see cref="IEnumerable{T}"/> to search.</param>
    /// <param name="match">
    /// The <see cref="Predicate{T}"/> delegate that defines the conditions of the element to search for.
    /// </param>
    /// <typeparam name="TSource">The type of the elements of the <paramref name="enumerable"/>.</typeparam>
    /// <returns>
    /// The zero-based index of the first occurrence of an element that matches the conditions defined by match, if found; otherwise, -1.
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
    /// Searches for an element that matches the conditions defined by the specified predicate,
    /// and returns the zero-based index of the last occurrence within the entire
    /// <paramref name="enumerable"/>.
    /// </summary>
    /// <param name="enumerable"> The <see cref="IEnumerable{T}"/> to search.</param>
    /// <param name="match">
    /// The <see cref="Predicate{T}"/> delegate that defines the conditions of the element to search for.
    /// </param>
    /// <typeparam name="TSource">The type of the elements of the <paramref name="enumerable"/>.</typeparam>
    /// <returns>
    /// The zero-based index of the last occurrence of an element that matches the conditions defined by match, if found; otherwise, -1.
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
    
}