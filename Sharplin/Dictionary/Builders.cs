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
    /// <returns>A dictionary containing the provided <paramref name="pairs"/></returns>
    public static Dictionary<TKey, TValue> DictionaryOf<TKey, TValue>(params KeyValuePair<TKey, TValue>[] pairs)
        where TKey : notnull => 
        pairs.ToDictionary(pair => pair.Key, pair => pair.Value);

    /// <summary>
    /// Constructs a <see cref="Dictionary{TKey,TValue}"/> from the provided <paramref name="pairs"/>
    /// </summary>
    /// <example>
    ///     <code>
    ///         var dic = SmartDictionaryOf&lt;string, int&gt;(
    ///             "number", 1,
    ///             "position": 2
    ///         );
    ///     </code>
    /// </example>
    /// <returns>A <see cref="Dictionary{TKey,TValue}"/> of keys and values extracted from <paramref name="pairs"/></returns>
    /// <remarks>Use this at the cost of your sanity.</remarks>
    /// 
    public static Dictionary<TKey, TValue> SmartDictionaryOf<TKey, TValue>(params object[] pairs)
        where TKey : notnull
    {
        var dic = new Dictionary<TKey, TValue>();
        for (int i = 0; i < pairs.Length; i += 2) {
            dic.Add((TKey) pairs[i], (TValue) pairs[i + 1]);
        }
        return dic;
    }

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