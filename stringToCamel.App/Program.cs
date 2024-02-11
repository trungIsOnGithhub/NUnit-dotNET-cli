namespace stringToCamel.App;

using System;

public class Program
{
    public static string StringToCamel(string underscoreSep)
    {
        var tempOut = string.Empty;

        var tempArrSubStr = underscoreSep.Split("_");

        if (tempArrSubStr.Length == 0)
            return "";
        
        tempOut += char.ToLower(tempArrSubStr[0][0]) + tempArrSubStr[0].Substring(1);
        
        for (int i = 0; i < tempArrSubStr.Length; ++i)
        {
            tempOut += char.ToUpper(tempArrSubStr[i][0]) + tempArrSubStr[i].Substring(1);
        }

        return tempOut;
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Hello World");
    }
}