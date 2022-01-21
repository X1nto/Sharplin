namespace Tests;

using System.Collections.Generic;

public static class Util
{
    public static char[] TestArray
    {
        get => new[] {'a', 'b', 'c', 'd', 'd'};
    }

    public static HashSet<char> TestHashSet
    {
        get => new() {'a', 'b', 'c', 'd', 'd'};
    }

    public static List<char> TestList
    {
        get => new() {'a', 'b', 'c', 'd', 'd'};
    }

    public static ICollection<char> TestICollection
    {
        get => TestArray;
    }

    public static IReadOnlyCollection<char> TestIReadOnlyCollection
    {
        get => TestArray;
    }

    public static IEnumerable<char> TestIEnumerable
    {
        get => TestArray;
    }

    public static Dictionary<char, int> TestDictionary
    {
        get => new()
        {
            {'a', 1},
            {'b', 2},
        };
    }

    public static string[] TestSentence
    {
        get => new[] {"This", "sentence", "is", "false"};
    }
}