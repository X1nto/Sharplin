namespace Tests.Collection;

using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Sharplin.Scope;

public class Scopes
{   
    [Test]
    public void Test_Apply()
    {
        var expected = new List<string> { "this", "is", "a", "test" }; 
        var actual = new List<string> {"this", "is", "a"};
        Assert.AreEqual(expected, actual.Apply(list => list.Add("test")));
    }

    [Test]
    public void Test_Let()
    {
        var testList = new List<string> { "this", "is", "a" };
        Assert.AreEqual("test", testList.Let(list =>
        {
            list.Add("test");
            return list.ElementAt(3);
        }));
    }
}