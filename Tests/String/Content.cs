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
}