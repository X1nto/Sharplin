namespace Tests.Dictionary;

using System.Collections.Generic;
using NUnit.Framework;
using Sharplin.Dictionary;

public class Builders
{
    [Test]
    public void Test_DictionaryOf_PairOf()
    {
        var expected = new Dictionary<string, int>
        {
            {"number", 1},
            {"money", 50},
        };
        var actual = DictionaryOf(PairOf("number", 1), PairOf("money", 50));
        Assert.AreEqual(expected, actual);
    }
    
    [Test]
    public void Test_DictionaryOf_Pair()
    {
        var expected = new Dictionary<string, int>
        {
            {"number", 1},
            {"money", 50},
        };
        var actual = DictionaryOf("number".Pair(1), "money".Pair(50));
        Assert.AreEqual(expected, actual);
    }
}