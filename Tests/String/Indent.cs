namespace Tests.String;

using NUnit.Framework;
using Sharplin.String;

public class Indent
{
    [Test]
    public void Test_TrimIndent()
    {
        Assert.AreEqual("123", @"
        123
        ".TrimIndent());
        Assert.AreEqual("123\n    456", @"
        123
            456
        ".TrimIndent());
        Assert.AreEqual("    123\n456", @"
            123
        456
        ".TrimIndent());
        Assert.AreEqual("|    123\n|456", @"
            123
        456
        ".ReplaceIndent(newIndent: "|"));
    }
}