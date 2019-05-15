using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GOLLSYSTEM.Validation
{
    public class Validation
    {
        public static bool Val_EmptyField(string text)
        {
            return text.Trim().Length > 0 ? true : false;
        }
        public static bool Val_WordsLength(string text,int length)
        {
            bool result = true;
            string[] words = text.Split(Convert.ToChar(" "));
            foreach (string word in words)
            {
                if (word.Trim().Length<length)
                {
                    return false;
                }
            }
            return result;
        }
        public static bool Val_StringsLength(string text, int length)
        {
            return text.Trim().Length < length ? false : true;
        }
        public static bool Val_DecimalFormat(string text)
        {
            return new Regex(@"^(\d|-)?(\d|,)*\.?\d*$").IsMatch(text);
        }
        public static bool Val_NumberFormat(string text)
        {
            return new Regex(@"^\d+$").IsMatch(text);
        }
        public static bool Val_LetterFormat(string text)
        {
            return new Regex(@"^[a-zA-Z ]*$").IsMatch(text);
        }
        public static bool Val_NameFormat(string text)
        {
            bool result = true;
            string[] words = text.Trim().Split(Convert.ToChar(" "));
            if (words.Length>6|| words.Length <2)
            {
                return false;
            }
            foreach (string word in words)
            {
                if (word.Trim().Length>=2)
                {
                    //result = new Regex(@"\A([a-zA-Z]{3,30})\Z").IsMatch(word.Trim());
                    result = new Regex(@"\A([a-zA-Z]{2,30})\Z").IsMatch(word.Trim());

                    if (!result)
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }

            }
            if (text.Trim().Length<3)
            {
                return false;

            }
            return result;

        }
        public static bool Val_NitFormat(string text)
        {
            bool result = new Regex(@"^[0-9]{4}-[0-9]{6}-[0-9]{3}-[0-9]{1}").IsMatch(text.Trim());
            return result;

        }
        public static bool Val_DuiFormat(string text)
        {
            bool result = new Regex(@"^[0-9]{8}-[0-9]{1}").IsMatch(text.Trim());
            return result;
        }
        public static bool Val_PasswordFormat(string text)
        {
            bool result = new Regex(@"^[0-9a-zA-Z]{5,30}").IsMatch(text.Trim());
            return result;
        }

        public static bool Val_CellphoneFormat(string text)
        {
            bool result = new Regex(@"\A[\+\-]{1}[0-9]{1,3}[0-9]{5,13}\Z|\A\([\+\-]{1}[0-9]{1,3}\)[0-9]{5,13}\Z|\A[0-9]{5,15}\Z").IsMatch(text.Trim());
            return result;
        }
        public static bool Val_EmailFormat(string text)
        {
            bool result = new Regex(@"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" + @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$").IsMatch(text.Trim());
            return result;
        }
        public static string Val_Injection(string text)
        {
            char[] letters = text.ToArray();
            string result = "";
            foreach (char letter in letters)
            {
                if (letter.ToString()=="'"|| letter.ToString() == "\"")
                {
                    result += "\\" + letter;

                }
                else
                {
                    result += letter;
                }
            }
            return result;
        }

    }
}
