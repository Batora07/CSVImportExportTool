using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolInsertMedicamentATU.ToolSRC.Insert
{
    public static class InsertTools
    {
        public static char HandleBoolFromString(string boolToChar)
        {
            if (string.IsNullOrWhiteSpace(boolToChar))
            {
                return '\0';
            }

            if (boolToChar.ToLower() == "oui")
            {
                return 'O';
            }
            else
            {
                return 'N';
            }
        }

        public static DateTime ConvertDateTimeFromString(string dateTime)
        {
            return ConvertToDateTime(dateTime);
        }

        private static DateTime ConvertToDateTime(string value)
        {
            DateTime convertedDate;
            try
            {
                convertedDate = Convert.ToDateTime(value);
                /*  Console.WriteLine("'{0}' converts to {1} {2} time.",
                                    value, convertedDate,
                                    convertedDate.Kind.ToString());*/
                return convertedDate;
            }
            catch (FormatException)
            {
                Console.WriteLine("'{0}' is not in the proper format.", value);
                return DateTime.Now;
            }
        }

        public static string ConvertToUTF8String(string unconvertedString)
        {
            if (string.IsNullOrWhiteSpace(unconvertedString))
            {
                return null;
            }

            byte[] utf = System.Text.Encoding.UTF8.GetBytes(unconvertedString);

            //utf to string
            string s2 = System.Text.Encoding.UTF8.GetString(utf);
            return s2;
        }

        public static string EscapeStringForSQLQuery(string unescapedString)
        {
            if (string.IsNullOrWhiteSpace(unescapedString))
            {
                return null;
            }

            string result = "";

            for (int i = 0; i < unescapedString.Length; ++i)
            {
                if (unescapedString[i] == '\'')
                {
                    result += "'";
                }
                result += unescapedString[i];
            }
            return result;
        }

        public static string RemoveSpaceString(string unescapedString)
        {
            string result = "";

            if (string.IsNullOrWhiteSpace(unescapedString))
            {
                return null;
            }

            for (int i = 0; i < unescapedString.Length; ++i)
            {
                if (!char.IsWhiteSpace(unescapedString[i]))
                {
                    result += unescapedString[i];
                }
            }
            return result;
        }

        public static bool IsValidDate(string date)
        {
            if (string.IsNullOrWhiteSpace(date))
            {
                return false;
            }
            else if (date.ToLower().Contains("sans objet"))
            {
                return false;
            }

            return true;
        }
    }
}
