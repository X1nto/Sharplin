namespace Tests.Dictionary;

using System.Collections.Generic;
using NUnit.Framework;
using Sharplin.Dictionary;

public class Builders
{
    private static readonly Dictionary<string, int> Expected = new()
    {
        {"number", 1},
        {"money", 50},
    };

    [Test]
    public void Test_DictionaryOf_Tuple()
    {
        var actual = DictionaryOf(
            ("number", 1),
            ("money", 50)
        );
        Assert.AreEqual(Expected, actual);
    }

    [Test]
    public void Test_DictionaryOf_PairOf()
    {
        var actual = DictionaryOf(PairOf("number", 1), PairOf("money", 50));
        Assert.AreEqual(Expected, actual);
    }

    [Test]
    public void Test_DictionaryOf_Pair()
    {
        var actual = DictionaryOf("number".Pair(1), "money".Pair(50));
        Assert.AreEqual(Expected, actual);
    }
}