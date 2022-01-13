namespace Tests.Collection;

using System.Collections.Generic;
using NUnit.Framework;

using static Sharplin.Collection.Builders;

public class Builders
{
    [Test]
    public void Test_ArrayOf()
    {
        string[] expected = {"this", "is", "a", "test"};
        string[] actual = ArrayOf("this", "is", "a", "test");
        Assert.AreEqual(expected, actual);
    }
    
    [Test]
    public void Test_ListOf()
    {
        var expected = new List<string> {"this", "is", "a", "test"};
        var actual = ListOf("this", "is", "a", "test");
        Assert.AreEqual(expected, actual);
    }
    
    [Test]
    public void Test_HashSetOf()
    {
        var expected = new HashSet<string> {"this", "is", "a", "test"};
        var actual = HashSetOf("this", "is", "a", "test");
        Assert.AreEqual(expected, actual);
    }
}