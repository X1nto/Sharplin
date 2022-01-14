namespace Sharplin.Dictionary;

using System.Collections.Generic;

/// <summary>Helper class containing methods for quickly building a dictionary.</summary>
/// <example>
///     <para>
///         Example 1:
///         <code>
///             using static Sharplin.Dictionary.Builders;
///             var arr = DictionaryOf(PairOf("number", 1));
///         </code>
///     </para>
///     <para>
///         Example 2:
///         <code>
///             using Sharplin.Dictionary;
///             var dic = Builders.DictionaryOf(PairOf("number", 1));
///         </code>
///     </para>
///     <para>
///         Example 3:
///         <code>
///             //GlobalUsings.cs
///             global static using Sharplin.Dictionary.Builders;
///             //Any other class/file in the project
///             var dic = DictionaryOf(PairOf("number", 1));
///         </code>
///     </para>
/// </example>
public static class Builders
{
    /// <summary>Constructs a <see cref="Dictionary{TKey,TValue}"/> from the provided <
    /// paramref name="pairs"/>
    /// </summary>
    /// <example>
    ///     <code>
    ///         var dic = DictionaryOf(
    ///             PairOf("number", 1),
    ///             PairOf("position": 2)
    ///         );
    ///     </code>
    /// </example>
    /// <returns>A <see cref="Dictionary{TKey,TValue}"/> containing the provided <paramref name="pairs"/></returns>

    public static Dictionary<TKey, TValue> DictionaryOf<TKey, TValue>(params KeyValuePair<TKey, TValue>[] pairs)
        where TKey : notnull => 
        pairs.ToDictionary(pair => pair.Key, pair => pair.Value);

    /// <summary>Constructs a <see cref="Dictionary{TKey,TValue}"/> from the provided
    /// <paramref name="pairs"/>
    /// </summary>
    /// <example>
    ///     <code>
    ///         var dic = DictionaryOf(
    ///             ("number", 1),
    ///             ("position": 2)
    ///         );
    ///     </code>
    /// </example>
    /// <returns>A <see cref="Dictionary{TKey,TValue}"/> containing the provided <paramref name="pairs"/></returns>
    public static Dictionary<TKey, TValue> DictionaryOf<TKey, TValue>(params (TKey key, TValue value)[] pairs)
        where TKey : notnull =>
        pairs.ToDictionary(pair => pair.Item1, pair => pair.Item2);
    
    /// <returns>
    ///     A <see cref="KeyValuePair{TKey,TValue}"/> of the provided <paramref name="key"/> and
    ///     <paramref name="value"/>
    /// </returns>
    public static KeyValuePair<TKey, TValue> PairOf<TKey, TValue>(TKey key, TValue value) => new(key, value);

    /// <returns>
    ///     A <see cref="KeyValuePair{TKey,TValue}"/> of the provided <paramref name="key"/> and
    ///     <paramref name="value"/>
    /// </returns>
    public static KeyValuePair<TKey, TValue> Pair<TKey, TValue>(this TKey key, TValue value) => new(key, value);
}