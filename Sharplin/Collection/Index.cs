namespace Sharplin.Collection;

public static class Index
{
    public static int IndexOfFirst<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
    {
        if (source is List<TSource> list) 
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
    
    public static int IndexOfFirst<TSource>(this IList<TSource> source, Func<TSource, bool> predicate)
    {
        for (int i = 0; i < source.Count; i++)
        {
            if (predicate(source[i]))
                return i;
        }
        
        return -1;
    }

    public static int IndexOfLast<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
    {
        if (source is List<TSource> list)
            return IndexOfLast(list, predicate);

        int lastIndex = -1;
        int index = 0;
        
        foreach (TSource element in source.Reverse())
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
    
    public static int IndexOfLast<TSource>(this IList<TSource> source, Func<TSource, bool> predicate)
    {
        for (int i = source.Count; i > 0; i--)
        {
            if (predicate(source[i]))
                return i;
        }

        return -1;
    }
}