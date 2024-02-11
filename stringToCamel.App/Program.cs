namespace stringToCamel.App;

using System;
using System.Text;

public class Program
{
    private static string transformIf(string word, bool isLower = false)
    {
        if (word is null || word == string.Empty)
        {
            return string.Empty;
        }

        var result = new StringBuilder(word);

        if (isLower)
        {
            result[0] = char.ToLower(word[0]);
        }
        else
        {
            result[0] = char.ToUpper(word[0]);
        }

        return result.ToString();
    }

    public static string StringToCamel(string underscoreSep)
    {
        var tempArrSubStr = underscoreSep.Split("_");

        if (tempArrSubStr.Length == 0)
            return string.Empty;

        var tempOut = new StringBuilder(string.Empty);
        var isLower = true;
        
        foreach (var substr in tempArrSubStr)
        {
            if (substr == string.Empty)
            {
                continue;
            }
        
            tempOut.Append( transformIf(substr, isLower) );

            if (isLower) // first word will be lowercased
            {
                isLower = false;
            }
        }

        return tempOut.ToString();
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Hello World");
    }
}