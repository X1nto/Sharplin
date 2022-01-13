namespace Tests.Collection;

using System.Collections.ObjectModel;
using System.Linq;
using NUnit.Framework;
using Sharplin.Collection;

public class Index
{
    private static readonly Collection<string> ETestArr = new() { "a", "b", "c", "c" };
    private static readonly string[] TestArr = {"a", "b", "c", "c" };

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
        Assert.AreEqual(3, ETestArr.LastIndex());
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