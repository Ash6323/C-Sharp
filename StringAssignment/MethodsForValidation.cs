using System;
using System.Text.RegularExpressions;

public static class ValidationMethods
{
    public static bool ValidateOtherCharInWord(string str)
    {
        if (Regex.Match(str, "^[0-9][.][0-9]*$").Success)
            return false;
        else
            return true;
    }
    public static bool ValidateChoice(int num)
    {
        return Regex.Match(num.ToString(), "[1-5]").Success;
    }
    public static bool ValidateStringOperationChoice(int num)
    {
        return Regex.Match(num.ToString(), "[1-9]|[10]").Success;
    }
}
