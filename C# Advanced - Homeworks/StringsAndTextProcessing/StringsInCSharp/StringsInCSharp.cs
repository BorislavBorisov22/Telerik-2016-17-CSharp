using System;
using System.Text;


class StringsInCSharp
{
    static void Main()
    {
        var str = new StringBuilder();

        str.Append("A string is an object of type \"String\" that holds series of symbols in the form of a text.")
            .Append("Strings are a refference type which means when initialized they are stored in the Heap")
            .Append(" Strings are immutable this means that the are read-only so every time there are changes")
            .Append("made on them a new string is actually returned and never the same.")
            .Append("There are many useful methods and properties ot the String class like")
            .Append("the Length property of a string that gives the number of symbols in the string.").
            Append("There are also the methods Replace,Substring,Remove,CompareTo whose functions ")
            .Append("basically correspond to their names.");


        Console.WriteLine(str);
            
    }
}

