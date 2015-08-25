using System;
using System.Security.Cryptography;
using System.Text;

namespace XiyouMobileFoundation.EncryptUtil
{
    public class XYMHashUtil
    {
        public static string MD5_Hash(string str_md5_in)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] bytes_md5_in = UTF8Encoding.Default.GetBytes(str_md5_in);
            byte[] bytes_md5_out = md5.ComputeHash(bytes_md5_in);
            string str_md5_out = BitConverter.ToString(bytes_md5_out);
            return str_md5_out.Replace("-","").ToLower();
        }

        public static string SHA1_Hash(string str_sha1_in)
        {
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            byte[] bytes_sha1_in = UTF8Encoding.Default.GetBytes(str_sha1_in);
            byte[] bytes_sha1_out = sha1.ComputeHash(bytes_sha1_in);
            string str_sha1_out = BitConverter.ToString(bytes_sha1_out);
            return str_sha1_out.Replace("-", "").ToLower();
        }
    }
}
