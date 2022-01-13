namespace Tests.String;

using NUnit.Framework;
using Sharplin.String;

public class Content
{
    [SetUp]
    public void SetUp()
    {
        
    }

    [Test]
    public void Test_IsBlank()
    {
        void TestIsBlank(string actual)
        {
            Assert.IsTrue(actual.IsBlank());
        }
        
        TestIsBlank(" ");
        TestIsBlank("");
    }

    [Test]
    public void Test_IsEmpty()
    {
        void TestIsEmpty(string actual)
        {
            Assert.IsTrue(actual.IsEmpty());
        }
        
        TestIsEmpty(" ");
        TestIsEmpty("");
    }
    
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
    
    
}