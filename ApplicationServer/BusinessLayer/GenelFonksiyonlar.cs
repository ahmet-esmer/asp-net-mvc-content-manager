using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer
{
    public class GenelFonksiyonlar
    {
        public static string EnterDonusturBr(string str)
        {
            return str.Replace("\n", "<br />");

        }

        public static string BRDonusturEnter(string str)
        {
            return str.Replace("<br />", "\n");

        }

    }
}
