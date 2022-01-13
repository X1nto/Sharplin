namespace Sharplin.Collection;

public static class Index
{
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
    
    public static int IndexOfFirst<TSource>(this IList<TSource> source, Predicate<TSource> predicate)
    {
        foreach (int index in source.EIndices())
        {
            if (predicate(source[index]))
                return index;
        }
        
        return -1;
    }

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
    
    public static int IndexOfLast<TSource>(this IList<TSource> source, Predicate<TSource> predicate)
    {
        foreach (int index in source.EIndices().Reverse())
        {
            if (predicate(source[index]))
                return index;
        }
        
        return -1;
    }

    public static Range Indices<TSource>(this ICollection<TSource> source) => ..source.Count;
    
    public static IEnumerable<int> EIndices<TSource>(this ICollection<TSource> source) => Enumerable.Range(0, source.Count);

    public static int LastIndex<TSource>(this ICollection<TSource> source) => source.Count - 1;
}