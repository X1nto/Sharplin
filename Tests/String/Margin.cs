namespace Tests.String;

using NUnit.Framework;
using Sharplin.String;

public class Margin
{
    [Test]
    public void Test_TrimMargin()
    {
        Assert.AreEqual("ABC\n123\n456", @"
            |ABC
            |123
            |456
        ".TrimMargin());
        Assert.AreEqual("ABC\n123\n456", @"
            #ABC
            #123
            #456
        ".TrimMargin("#"));
    }
}