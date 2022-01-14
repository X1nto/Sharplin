namespace Tests.Collection;

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Sharplin.Collection;

public class Index
{
    private static readonly string[] TestArr = {"a", "b", "c", "c"};

    [Test]
    public void Test_LastIndex()
    {
        Assert.AreEqual(3, TestArr.LastIndex());
    }

    [Test]
    public void Test_Indices()
    {
        Assert.AreEqual(..4, TestArr.Indices());
    }

    [Test]
    public void Test_EIndices()
    {
        Assert.AreEqual(Enumerable.Range(0, 4), TestArr.EIndices());
    }
}