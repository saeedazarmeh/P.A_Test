using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace P.A_Contract
{
    public class Utility
    {
        public static bool IsCheckLength(string str, int length)
        {
            return str.Length <= length;
        }

        public static bool IsValidPhoneNumber(string phone)
        {
            return Regex.IsMatch(phone,
                @"^(?=.[09])(?=\d).{11}$",
                RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
        }

        public static bool IsValidPassword(string password)
        {
            return Regex.IsMatch(password,
                @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$",
                RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
        }
        public static bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email,
                @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$",
                RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
        }

    }
}
