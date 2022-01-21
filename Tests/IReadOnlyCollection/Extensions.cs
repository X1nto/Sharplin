namespace Tests.IReadOnlyCollection;

using System;
using System.Linq;
using NUnit.Framework;
using Sharplin.IReadOnlyCollection;

public class Extensions
{
    [Test]
    public void Test_Indices()
    {
        Range expect = ..5;
        Range actual = TestIReadOnlyCollection.Indices();
        Assert.AreEqual(expect, actual);
    }

    [Test]
    public void Test_EIndices()
    {
        var expect = Enumerable.Range(0, 5);
        var actual = TestIReadOnlyCollection.EIndices();
        Assert.AreEqual(expect, actual);
    }

    [Test]
    public void Test_LastIndex()
    {
        const int expect = 4;
        int actual = TestIReadOnlyCollection.LastIndex();
        Assert.AreEqual(expect, actual);
    }
}