using System;

namespace LeetCode.App;

public interface ISolution
{
    public void solve();
}

public class LengthOfLastWord : ISolution
{
    private string inputStr;

    public LengthOfLastWord(string inputStr)
    {
        this.inputStr = inputStr;        
    }

    public ISolution.solve()
    {
        var strB = new StringBuilder(inputStr);

        int endOfLastWordIndex = strB.Length - 1;

        while (endOfLastWordIndex >= 0)
        {
            if (strB[endOfLastWordIndex] != ' ')
                break;

            --endOfLastWordIndex;
        }

        if (endOfLastWordIndex < 0)
            return 0;


        int beginOfLastWordIndex = endOfLastWordIndex-1;

        while (beginOfLastWordIndex >= 0)
        {
            if (strB[endOfLastWordIndex] == ' ')
                break;

            --beginOfLastWordIndex;
        }

        return endOfLastWordIndex - beginOfLastWordIndex;
    }
}