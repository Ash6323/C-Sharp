using System;
using System.Text.RegularExpressions;

public static class ValidationMethods
{
    public static bool VehicleNameValidate(string str)
    {
        if (Regex.Match(str, "^[A-Z][a-zA-Z]*$").Success)
            return false;
        else
            return true;
    }
    //public static bool PriceValidate(double price)
    //{
    //    if (Regex.Match(price, "/\\d+\\.\\d*|\\.?\\d+/").Success)
    //        return false;
    //    else
    //        return true;
    //}
}

