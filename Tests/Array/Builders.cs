namespace Tests.Array;

using NUnit.Framework;

public class Builders
{
    [Test]
    public void Test_ArrayOf()
    {
        char[] actual = ArrayOf('a', 'b', 'c', 'd', 'd');
        Assert.AreEqual(TestArray, actual);
    }
}