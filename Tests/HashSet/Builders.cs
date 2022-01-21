namespace Tests.HashSet;

using NUnit.Framework;

public class Builders
{
    [Test]
    public void Test_HashSetOf()
    {
        var actual = HashSetOf('a', 'b', 'c', 'd', 'd');
        Assert.AreEqual(TestHashSet, actual);
    }
}