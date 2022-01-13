namespace Tests.String;

using NUnit.Framework;
using Sharplin.String;

public class Content
{
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
}