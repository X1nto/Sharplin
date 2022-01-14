namespace Sharplin.Scope;

public static class Scopes
{
    /// <summary>
    ///     Calls the provided <paramref name="block"/> function with <paramref name="source"/> as its argument.
    /// </summary>
    /// <typeparam name="TResult">Result of the <paramref name="block"/> invocation.</typeparam>
    /// <returns>
    ///     <typeparamref name="TResult"/>
    /// </returns>
    public static TResult Let<TSource, TResult>(this TSource source, Func<TSource, TResult> block) => block(source);

    /// <summary>
    ///     Calls the provided <paramref name="block"/> function with <paramref name="source"/> as its argument.
    /// </summary>
    /// <returns>
    ///     <paramref name="source"/>
    /// </returns>
    public static TSource Apply<TSource>(this TSource source, Action<TSource> block)
    {
        block(source);
        return source;
    }
}