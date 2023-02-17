using System;
using System.Text.RegularExpressions;

public static class ValidationMethods
{
    public static bool VehicleNameValidate(string str)
    {
        if (Regex.Match(str, "^[A-Z][a-zA-Z0-9\\s]*$").Success)
            return false;
        else
            return true;
    }
}
