using System;
using System.Security.Cryptography;
using System.Text;

namespace JB
{
    public class ClPwdhash
    {
        //get password
        public string GetMd5Hash(string input)
        {
            MD5 md5Hasher = MD5.Create();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));
            var sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

        public string GenerateGuid()
        {
            long i = 1;
            for (int index = 0; index < Guid.NewGuid().ToByteArray().Length; index++)
            {
                byte b = Guid.NewGuid().ToByteArray()[index];
                i *= (b + 1);
            }
            return string.Format("{0:x}", i - DateTime.Now.Ticks);
        }
    }
}