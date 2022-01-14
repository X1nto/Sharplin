namespace Sharplin.Dictionary;

using System.Collections.Generic;

/// <summary>Helper class containing methods for quickly building a dictionary.</summary>
/// <example>
/// <para>
/// Example 1:
/// <code>
/// using static Sharplin.Dictionary.Builders;
/// var arr = DictionaryOf(PairOf("number", 1));
/// </code>
/// </para>
/// <para>
/// Example 2:
/// <code>
/// using Sharplin.Dictionary;
/// var dic = Builders.DictionaryOf(PairOf("number", 1));
/// </code>
/// </para>
/// <para>
/// Example 3:
/// <code>
/// //GlobalUsings.cs
/// global static using Sharplin.Dictionary.Builders;
/// //Any other class/file in the project
/// var dic = DictionaryOf(PairOf("number", 1));
/// </code>
/// </para>
/// </example>
public static class Builders
{
    /// <returns>A dictionary containing the provided <paramref name="pairs"/></returns>
    public static Dictionary<TKey, TValue> DictionaryOf<TKey, TValue>(params KeyValuePair<TKey, TValue>[] pairs)
        where TKey : notnull
     => pairs.ToDictionary(pair => pair.Key, pair => pair.Value);

    /// <returns>A <see cref="KeyValuePair{TKey,TValue}"/> of the provided <paramref name="key"/> and <paramref name="value"/></returns>
    public static KeyValuePair<TKey, TValue> PairOf<TKey, TValue>(TKey key, TValue value) => new(key, value);
}