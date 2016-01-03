using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer
{
    public  class UrlTRKarekter
    {
        public static string Replace(string x)
        {
            x = x.Trim();
            char[] c = @"$%#@!*?;:~`+=()[]{}|'<>,/^&"". ".ToCharArray();

            for (int i = 0; i < c.Length; i++)
            {
                string strChar = c.GetValue(i).ToString();

                if (x.Contains(strChar))
                {
                    x = x.Replace(strChar, "_");
                }
            }

            x = x.Contains('Ç'.ToString()) ? x.Replace('Ç', 'C') : x;
            x = x.Contains('Ğ'.ToString()) ? x.Replace('Ğ', 'G') : x;
            x = x.Contains('Ş'.ToString()) ? x.Replace('Ş', 'S') : x;
            x = x.Contains('İ'.ToString()) ? x.Replace('İ', 'I') : x;
            x = x.Contains('Ü'.ToString()) ? x.Replace('Ü', 'U') : x;
            x = x.Contains('ş'.ToString()) ? x.Replace('ş', 's') : x;
            x = x.Contains('ç'.ToString()) ? x.Replace('ç', 'c') : x;
            x = x.Contains('ğ'.ToString()) ? x.Replace('ğ', 'g') : x;
            x = x.Contains('ı'.ToString()) ? x.Replace('ı', 'i') : x;
            x = x.Contains('ü'.ToString()) ? x.Replace('ü', 'u') : x;
            x = x.Contains('Ö'.ToString()) ? x.Replace('Ö', 'O') : x;
            x = x.Contains('ö'.ToString()) ? x.Replace('ö', 'o') : x;

            return x.Trim();

        }
    }
}
