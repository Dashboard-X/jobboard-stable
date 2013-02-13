using System;

namespace JB
{
    public class Clcookiehandler : Clpager
    {
        //an alternative to cookies when our server was blocked from 
        //sending any to browsers!

        public string GenerateId()
        {
            long i = 1;
            for (int index = 0; index < Guid.NewGuid().ToByteArray().Length; index++)
            {
                byte b = Guid.NewGuid().ToByteArray()[index];
                i *= (b + 1);
            }
            return string.Format("{0:x}", i - DateTime.Now.Ticks);
        }

        //public void setjobcookie(string cookiehash)
        //{
        //    //Create a new cookie, passing the name into the constructor
        //    var cookie = new HttpCookie("ahrcloud.com") { Value = cookiehash, Expires = DateTime.Now.AddHours(1) };

        //    //Add the cookie
        //    Response.Cookies.Add(cookie);
        //}

        ////read cookie
        //public string Readjobcookie()
        //{
        //    if (Request.Cookies["ahrcloud.com"] != null)
        //    {
        //        //Get the cookie value
        //        return Request.Cookies["ahrcloud.com"].Value;
        //    }

        //    else
        //    {
        //        return "";
        //    }
        //}
    }
}