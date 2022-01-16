# Builders
Collection builders are useful for quickly making Lists, Arrays and HashSets. Sharplin provides Kotlin-styled tools to help you quickly build collections.

This example demonstrates List builders, but the same can be applied to Arrays, HashSets and Dictionaries too.

Usage with implicit usings
-----
First of all, you have to prepare your project to properly use collection builder classes. For this step, you need to have implicit usings enabled in your csproj file.

In your project, create a file called GlobalUsings.cs with the following content:
```c#
global using static Sharplin.List.Builders;
```
(If you already have a file for your global usings, you can simply add the code above to it.)

Congrats! You can now use the builder classes with no additional imports. Simple as that.

```c#
public static void Main(string[] args)
{
    List<int> numbersList = ListOf(1, 2, 3);
}
```

Usage without implicit usings
-----------------------------
If you do not have implicit usings enabled and/or don't want to declare global using statements, you can use any of the following methods:

### Method 1
```c#
using static Sharplin.Collection.Builders;

public static void Main(string[] args)
{
    List<int> numbersList = ListOf(1, 2, 3);
}
```
### Method 2
```c#
using Sharplin.Collection;

public static void Main(string[] args)
{
    List<int> numbersList = Builders.ListOf(1, 2, 3);
}
```