namespace Tests.Collection;

using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Sharplin.ICollection;
using Sharplin.IEnumerable;

public class Index
{
    private static readonly string[] TestArr = {"a", "b", "c", "c"};
    private static readonly IEnumerable<string> Enumerable = new TestEnumerable();

    [Test]
    public void Test_IndexOfFirst_Enumerable()
    {
        Assert.AreEqual(-1, Enumerable.FindIndex(s => s == "d"));
        Assert.AreEqual(2, Enumerable.FindIndex(s => s == "c"));
    }

    [Test]
    public void Test_IndexOfLast_Enumerable()
    {
        Assert.AreEqual(-1, Enumerable.FindLastIndex(s => s == "d"));
        Assert.AreEqual(3, Enumerable.FindLastIndex(s => s == "c"));
    }
    
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
        Assert.AreEqual(System.Linq.Enumerable.Range(0, 4), TestArr.EIndices());
    }
    
    private class TestEnumerable : IEnumerable<string>
    {
        private readonly List<string> _testList = new() {"a", "b", "c", "c"};

        public IEnumerator GetEnumerator() => _testList.GetEnumerator();

        IEnumerator<string> IEnumerable<string>.GetEnumerator() => _testList.GetEnumerator();
    }
}