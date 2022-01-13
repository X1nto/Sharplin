namespace Tests.String;

using NUnit.Framework;
using Sharplin.String;

public class Indent
{
    [Test]
    public void Test_TrimIndent()
    {
        void TestTrimIndent(string expected, string actual)
        {
            Assert.AreEqual(expected, actual.TrimIndent());
        }
        
        TestTrimIndent("123", @"
        123
        ");
        TestTrimIndent("123\n    456", @"
        123
            456
        ");
        TestTrimIndent("    123\n456", @"
            123
        456
        ");
        
        Assert.AreEqual("|    123\n|456", @"
            123
        456
        ".ReplaceIndent(newIndent: "|"));
    }
}