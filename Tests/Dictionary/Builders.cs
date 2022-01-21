namespace Tests.Dictionary;

using NUnit.Framework;
using Sharplin.Dictionary;

public class Builders
{
    [Test]
    public void Test_DictionaryOf_Tuple()
    {
        var actual = DictionaryOf(
            ('a', 1),
            ('b', 2));
        Assert.AreEqual(TestDictionary, actual);
    }

    [Test]
    public void Test_DictionaryOf_PairOf()
    {
        var actual = DictionaryOf(
            PairOf('a', 1),
            PairOf('b', 2));
        Assert.AreEqual(TestDictionary, actual);
    }

    [Test]
    public void Test_DictionaryOf_PairExt()
    {
        var actual = DictionaryOf(
            'a'.Pair(1),
            'b'.Pair(2));
        Assert.AreEqual(TestDictionary, actual);
    }
}