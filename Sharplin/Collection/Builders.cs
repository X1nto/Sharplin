namespace Sharplin.Collection;

/// <summary>Helper class containing methods for quickly building various collections.</summary>
/// <example>
///     <para>
///         Example 1:
///         <code>
///             using static Sharplin.Collection.Builders;
///             var arr = ArrayOf(1, 2, 3);
///         </code>
///     </para>
///     <para>
///         Example 2:
///         <code>
///             using Sharplin.Collection;
///             var arr = Builders.ArrayOf(1, 2, 3);
///         </code>
///     </para>
///     <para>
///         Example 3:
///         <code>
///             //GlobalUsings.cs
///             global static using Sharplin.Collection.Builders;
///             //Any other class/file in the project
///             var arr = ArrayOf(1, 2, 3);
///         </code>
///     </para>
/// </example>
public static class Builders
{
    /// <returns>An array containing the given <paramref name="items"/></returns>
    public static TSource[] ArrayOf<TSource>(params TSource[] items) => items;

    /// <returns>A <see cref="List{T}"/> containing the given <paramref name="items"/></returns>
    public static List<TSource> ListOf<TSource>(params TSource[] items) => items.ToList();

    /// <returns>A <see cref="HashSet{T}"/> containing the given <paramref name="items"/></returns>
    public static HashSet<TSource> HashSetOf<TSource>(params TSource[] items) => items.ToHashSet();
}