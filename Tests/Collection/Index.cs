namespace Tests.Collection;

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Sharplin.Collection;

public class Index
{
    private static readonly IEnumerable<string> ETestArr = new TestEnumerable();
    private static readonly string[] TestArr = {"a", "b", "c", "c" };

    private class TestEnumerable : IEnumerable<string>
    {
        private readonly List<string> _testList = new() { "a", "b", "c", "c"};

        public IEnumerator GetEnumerator() => _testList.GetEnumerator();

        IEnumerator<string> IEnumerable<string>.GetEnumerator() => _testList.GetEnumerator();
    }

    [Test]
    public void Test_IndexOfFirst_Enumerable()
    {
        Assert.AreEqual(-1, ETestArr.IndexOfFirst(s => s == "d"));
        Assert.AreEqual(2, ETestArr.IndexOfFirst(s => s == "c"));
    }
    
    [Test]
    public void Test_IndexOfFirst_List()
    {
        Assert.AreEqual(-1, TestArr.IndexOfFirst(s => s == "d"));
        Assert.AreEqual(2, TestArr.IndexOfFirst(s => s == "c"));
    }
    
    [Test]
    public void Test_IndexOfLast_Enumerable()
    {
        Assert.AreEqual(-1, ETestArr.IndexOfLast(s => s == "d"));
        Assert.AreEqual(3, ETestArr.IndexOfLast(s => s == "c"));
    }
    
    [Test]
    public void Test_IndexOfLast_List()
    {
        Assert.AreEqual(-1, TestArr.IndexOfLast(s => s == "d"));
        Assert.AreEqual(3, TestArr.IndexOfLast(s => s == "c"));
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
        Assert.AreEqual(Enumerable.Range(0, 4), TestArr.EIndices());
    }
}