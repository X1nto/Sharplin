namespace Sharplin.Collection;

public static class Loops
{
    public static void ForEach<TSource>(this IEnumerable<TSource> source, Action<TSource> action)
    {
        foreach (TSource item in source)
        {
            action(item);
        }
    }

    public static void ForEachIndexed<TSource>(this IList<TSource> source, Action<int, TSource> action)
    {
        foreach (int index in source.EIndices())
        {
            action(index, source[index]);
        }
    }
}