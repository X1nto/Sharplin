namespace Tests.String;

using NUnit.Framework;
using Sharplin.String;

public class Content
{
    [Test]
    public void Test_IsBlank()
    {
        Assert.IsTrue(" ".IsBlank());
        Assert.IsTrue("".IsBlank());
    }

    [Test]
    public void Test_IsEmpty()
    {
        Assert.IsTrue("".IsEmpty());
    }

    [Test]
    public void Test_Lines()
    {
        void TestLines(string actual)
        {
            Assert.AreEqual(new[] {"this", "is", "a", "test", "sentence"}, actual.Lines());
        }

        TestLines("this\nis\na\ntest\nsentence");
        TestLines("this\ris\ra\rtest\rsentence");
        TestLines("this\r\nis\r\na\r\ntest\r\nsentence");
        TestLines(@"
        this
        is
        a
        test
        sentence
        ".TrimIndent());
    }
}