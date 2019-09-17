using System;
using System.Security.Cryptography;
using System.Text;

namespace DynamicDns.Core
{
    /// <summary>
    /// HAMC 算法帮助类 Hash-based Message Authentication Code
    /// </summary>
    public static class HmacUtil
    {
        /// <summary>
        /// Base64 SHA256
        /// </summary>
        /// <param name="data">待加密数据</param>
        /// <param name="secret">密钥</param>
        /// <returns></returns>
        public static string EncryptWithSHA256(string data, string secret)
        {
            secret = secret ?? "";
            var encoding = Encoding.UTF8;
            byte[] keyByte = encoding.GetBytes(secret);
            byte[] dataBytes = encoding.GetBytes(data);
            using (var hmac256 = new HMACSHA256(keyByte))
            {
                byte[] hashData = hmac256.ComputeHash(dataBytes);
                return Convert.ToBase64String(hashData);
            }
        }

        /// <summary>
        /// Base64 SHA1
        /// </summary>
        /// <param name="data">待加密数据</param>
        /// <param name="secret">密钥</param>
        /// <returns></returns>
        public static string EncryptWithSHA1(string data, string secret)
        {
            secret = secret ?? "";
            var encoding = Encoding.UTF8;
            byte[] keyByte = encoding.GetBytes(secret);
            byte[] dataBytes = encoding.GetBytes(data);
            using (var hmac1 = new HMACSHA1(keyByte))
            {
                byte[] hashData = hmac1.ComputeHash(dataBytes);
                return Convert.ToBase64String(hashData);
            }
        }

        /// <summary>
        /// 原始64位 SHA256
        /// </summary>
        /// <param name="data">待加密数据</param>
        /// <param name="secret">密钥</param>
        /// <returns></returns>
        public static string EncryptWithSHA256Original(string data, string secret)
        {
            secret = secret ?? "";
            var encoding = Encoding.UTF8;
            byte[] keyByte = encoding.GetBytes(secret);
            byte[] dataBytes = encoding.GetBytes(data);
            using (var hmac256 = new HMACSHA256(keyByte))
            {
                byte[] hashData = hmac256.ComputeHash(dataBytes);
                return BitConverter.ToString(hashData).Replace("-", "").ToLower();
            }
        }

        /// <summary>
        /// 原始64位 SHA1
        /// </summary>
        /// <param name="data">待加密数据</param>
        /// <param name="secret">密钥</param>
        /// <returns></returns>
        public static string EncryptWithSHA1Original(string data, string secret)
        {
            secret = secret ?? "";
            var encoding = Encoding.UTF8;
            byte[] keyByte = encoding.GetBytes(secret);
            byte[] dataBytes = encoding.GetBytes(data);
            using (var hmac1 = new HMACSHA1(keyByte))
            {
                byte[] hashData = hmac1.ComputeHash(dataBytes);
                return BitConverter.ToString(hashData).Replace("-", "").ToLower();
            }
        }
    }
}
