using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.IO;
using System.Web.SessionState;
using System.Drawing.Text;
using System.Drawing.Imaging;

namespace MicroOptik.WebUI.Infrastructure
{
    /// <summary>
    /// Summary description for Captcha IRequiresSessionState
    /// </summary>
    public class Captcha : IHttpHandler, IRequiresSessionState
    {

         public void ProcessRequest(HttpContext context)
        {

            Bitmap objBMP = new System.Drawing.Bitmap(85, 23);
            Graphics objGraphics = System.Drawing.Graphics.FromImage(objBMP);
            objGraphics.Clear(Color.LightGray);

            objGraphics.TextRenderingHint = TextRenderingHint.AntiAlias;

            //' Configure font to use for text

            Font objFont = new Font("Verdana", 11, FontStyle.Bold);
            string randomStr = "";
            int[] myIntArray = new int[5];
            int x;

            //That is to create the random # and add it to our string

            Random autoRand = new Random();

            for (x = 0; x < 5; x++)
            {
                myIntArray[x] = System.Convert.ToInt32(autoRand.Next(0, 9));
                randomStr += (myIntArray[x].ToString());
            }

            //This is to add the string to session cookie, to be compared later

            context.Session.Add("captchaStr", randomStr);

            //' Write out the text

            objGraphics.DrawString(randomStr, objFont, Brushes.Gray, 10, 3);

            //' Set the content type and return the image

            context.Response.ContentType = "image/GIF";
            objBMP.Save(context.Response.OutputStream, ImageFormat.Gif);

            objFont.Dispose();
            objGraphics.Dispose();
            objBMP.Dispose();
        }

         public bool IsReusable
         {
             get { return true; }
         }
    }

}

