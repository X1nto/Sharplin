namespace Tests.Dictionary;

using System.Collections.Generic;
using NUnit.Framework;

public class Builders
{
    [Test]
    public void Test_DictionaryOf()
    {
        var expected = new Dictionary<string, int>
        {
            {"number", 1},
            {"money", 50}
        };
        var actual = DictionaryOf(PairOf("number", 1), PairOf("money", 50));
        Assert.AreEqual(expected, actual);
    }
}