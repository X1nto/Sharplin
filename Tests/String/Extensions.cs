namespace Tests.String;

using NUnit.Framework;
using Sharplin.String;

public class Extensions
{
    #region Lines

    [Test]
    public void Test_Lines()
    {
        void TestLines(string actual)
        {
            Assert.AreEqual(TestSentence, actual.Lines());
        }

        TestLines("This\nsentence\nis\nfalse");
        TestLines("This\rsentence\ris\rfalse");
        TestLines("This\r\nsentence\r\nis\r\nfalse");
        TestLines(@"
        This
        sentence
        is
        false
        ".TrimIndent());
    }

    [Test]
    public void Test_LineCount()
    {
        const int expected = 4;
        int actual = "This\nsentence\nis\nfalse".LineCount();
        Assert.AreEqual(expected, actual);
    }

    #endregion
    

    #region Blank and Empty

    [Test]
    public void Test_IsBlank()
    {
        Assert.IsTrue(" ".IsBlank());
        Assert.IsTrue("".IsBlank());
    }

    [Test]
    public void Test_IsEmpty()
    {
        Assert.IsFalse(" ".IsEmpty());
        Assert.IsTrue("".IsEmpty());
    }

    #endregion

    #region Capitalization

    [Test]
    public void Test_Capitalization()
    {
        void TestCapitalize(string expected, string actual)
        {
            Assert.AreEqual(expected, actual.Capitalize());
        }

        TestCapitalize("A", "A");
        TestCapitalize("A", "a");
        TestCapitalize("Abcd", "Abcd");
        TestCapitalize("Abcd", "abcd");
    }

    [Test]
    public void Test_Decapitalization()
    {
        void TestDecapitalize(string expected, string actual)
        {
            Assert.AreEqual(expected, actual.Decapitalize());
        }

        TestDecapitalize("a", "A");
        TestDecapitalize("a", "a");
        TestDecapitalize("abcd", "Abcd");
        TestDecapitalize("abcd", "abcd");
    }

    #endregion

    #region Indentation

    [Test]
    public void Test_TrimIndent()
    {
        void TestTrimIndent(string expected, string actual)
        {
            Assert.AreEqual(expected, actual.TrimIndent());
        }

        TestTrimIndent("ABC", @"
        ABC
        ");
        TestTrimIndent("ABC\n    123", @"
        ABC
            123
        ");
        TestTrimIndent("    ABC\n123", @"
            ABC
        123
        ");
    }

    [Test]
    public void Test_ReplaceIndent()
    {
        Assert.AreEqual("|    ABC\n|123", @"
            ABC
        123
        ".ReplaceIndent("|"));
    }

    [Test]
    public void Test_TrimMargin()
    {
        Assert.AreEqual("ABC\n123", @"
            |ABC
            |123
        ".TrimMargin());
        Assert.AreEqual("ABC\n123", @"
            #ABC
            #123
        ".TrimMargin("#"));
    }

    [Test]
    public void Test_ReplaceIndentByMargin()
    {
        Assert.AreEqual("~ABC\n~123", @"
            |ABC
            |123
        ".ReplaceIndentByMargin("~"));
        Assert.AreEqual("~ABC\n~123", @"
            #ABC
            #123
        ".ReplaceIndentByMargin("~", "#"));
    }

    #endregion

    #region Indexes

    [Test]
    public void Test_FindIndex()
    {
        const int expected = 1;
        int actual = "ABB".FindIndex(c => c == 'B');
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_FindLastIndex()
    {
        const int expected = 2;
        int actual = "ABB".FindLastIndex(c => c == 'B');
        Assert.AreEqual(expected, actual);
    }

    #endregion
}