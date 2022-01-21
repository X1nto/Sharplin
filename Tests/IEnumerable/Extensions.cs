namespace Tests.IEnumerable;

using NUnit.Framework;
using Sharplin.IEnumerable;

public class Extensions
{
    [Test]
    public void Test_FindIndex()
    {
        const int expected = 3;
        int actual = TestIEnumerable.FindIndex(c => c == 'd');
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_FindLastIndex()
    {
        const int expected = 4;
        int actual = TestIEnumerable.FindLastIndex(c => c == 'd');
        Assert.AreEqual(expected, actual);
    }
}