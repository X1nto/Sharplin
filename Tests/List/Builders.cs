namespace Tests.List;

using NUnit.Framework;

public class Builders
{
    [Test]
    public void Test_ListOf()
    {
        var actual = ListOf('a', 'b', 'c', 'd', 'd');
        Assert.AreEqual(TestList, actual);
    }
}