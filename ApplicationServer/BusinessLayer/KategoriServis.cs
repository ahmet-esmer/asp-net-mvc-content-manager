using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BusinessLayer
{
    public class KategoriServis
    {
        public static string Cizgi(string serial)
        {
            string sonuc = string.Empty;

            if (Convert.ToInt32(serial.ToString().Length) == 3)
            {
                sonuc = "";
            }
            else if (Convert.ToInt32(serial.ToString().Length) == 6)
            {
                sonuc = "-- ";
            }
            else if (Convert.ToInt32(serial.ToString().Length) == 9)
            {
                sonuc = "---- ";
            }
            else if (Convert.ToInt32(serial.ToString().Length) == 12)
            {
                sonuc = "------ ";
            }
            else if (Convert.ToInt32(serial.ToString().Length) == 15)
            {
                sonuc = "-------- ";
            }
            else if (Convert.ToInt32(serial.ToString().Length) == 18)
            {
                sonuc = "---------- ";
            }
            else if (Convert.ToInt32(serial.ToString().Length) == 21)
            {
                sonuc = "------------ ";
            }

            return sonuc.ToString();
        }

        public static string UrunTree(string serial, int AltKatVarmi)
        {
            string sonuc = string.Empty;

            if (serial.Length == 3)
            {
                sonuc = "";
            }
            else if (serial.Length == 6 && AltKatVarmi == 0)
            {
                sonuc = " ";
            }
            else if (serial.Length == 6 )
            {
                sonuc = " » ";
            }
            else if (serial.Length == 9 && AltKatVarmi == 0)
            {
                sonuc = "&nbsp;  ";
            }
            else if (serial.Length == 9)
            {
                sonuc = "&nbsp; » ";
            }
            else if (serial.Length == 12 && AltKatVarmi == 0)
            {
                sonuc = "&nbsp; &nbsp;  ";
            }
            else if (serial.Length == 12 )
            {
                sonuc = "&nbsp; &nbsp; » ";
            }
            else if (serial.Length == 15 && AltKatVarmi == 0)
            {
                sonuc = "&nbsp; &nbsp; &nbsp;   ";
            }
            else if (serial.Length == 15)
            {
                sonuc = "&nbsp; &nbsp; &nbsp; » ";
            }
          

            return sonuc;
        }

    }
}
