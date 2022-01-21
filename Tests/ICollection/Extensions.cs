namespace Tests.ICollection;

using System;
using System.Linq;
using NUnit.Framework;
using Sharplin.ICollection;

public class Extensions
{
    [Test]
    public void Test_Indices()
    {
        Range expect = ..5;
        Range actual = TestICollection.Indices();
        Assert.AreEqual(expect, actual);
    }

    [Test]
    public void Test_EIndices()
    {
        var expect = Enumerable.Range(0, 5);
        var actual = TestICollection.EIndices();
        Assert.AreEqual(expect, actual);
    }

    [Test]
    public void Test_LastIndex()
    {
        const int expect = 4;
        int actual = TestICollection.LastIndex();
        Assert.AreEqual(expect, actual);
    }
}