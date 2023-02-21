using System;
using System.Text.RegularExpressions;
public static class ValidationMethods
    {
        public static bool NameValidate(string str)
        {
            if (Regex.Match(str, "^[A-Z][a-zA-Z]*$").Success)
                return false;
            else
                return true;
        }
        public static bool EmailValidate(string str)
        {
            if (Regex.Match(str, "^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+$").Success)
                return false;
            else
                return true;
        }
        public static bool DOBValidate(string str)
        {
            if (Regex.Match(str, "(0[1-9]|[12][0-9]|3[01])[-](0[1-9]|1[012])[-]\\d{4}").Success)
                return false;
            else
                return true;
        }
        public static bool ContactValidate(string str)
        {
            if (Regex.Match(str, "\\A[0-9]{10}\\z").Success)
                return false;
            else
                return true;
        }
        public static bool GenderValidate(string str)
        {
            if (Regex.Match(str, "(?:m|M|male|Male|f|F|female|Female|FEMALE|MALE|Other||OTHER||other)$").Success)
                return false;
            else
                return true;
        }
        public static bool MaritalStatusValidate(string str)
        {
            if (Regex.Match(str, "(?:y|n|yes|no|Yes|No|YES|NO|d|D)$").Success)
                return false;
            else
                return true;
        }
        public static bool PANCardValidate(string str)
        {
            if (Regex.Match(str, "[A-Z]{5}[0-9]{4}[A-Z]{1}").Success)
                return false;
            else
                return true;
        }
    }

