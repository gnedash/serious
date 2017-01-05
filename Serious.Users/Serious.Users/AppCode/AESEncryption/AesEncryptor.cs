using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Serious.Users.AppCode.AESEncryption
{
    public class AesEncryptor : ICrypto
    {
        private readonly string _aesIV256;
        private readonly string _aesKey256;

        #region constants

        private const int BLOCK_SIZE = 128;
        private const int KEY_SIZE = 256;

        #endregion

        public AesEncryptor(string key, string iv)
        {
            _aesIV256 = iv;
            _aesKey256 = key;
        }

        public string Decrypt(string text)
        {
            using (AesCryptoServiceProvider aes = new AesCryptoServiceProvider())
            {
                aes.BlockSize = BLOCK_SIZE;
                aes.KeySize = KEY_SIZE;
                aes.IV = Encoding.UTF8.GetBytes(_aesIV256);
                aes.Key = Encoding.UTF8.GetBytes(_aesKey256);
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                // Convert Base64 strings to byte array
                byte[] src = System.Convert.FromBase64String(text);

                // decryption
                using (ICryptoTransform decrypt = aes.CreateDecryptor())
                {
                    byte[] dest = decrypt.TransformFinalBlock(src, 0, src.Length);
                    return Encoding.Unicode.GetString(dest);
                }
            }
        }

        public string Encrypt(string text)
        {
            using (AesCryptoServiceProvider aes = new AesCryptoServiceProvider())
            {
                aes.BlockSize = BLOCK_SIZE;
                aes.KeySize = KEY_SIZE;
                aes.IV = Encoding.UTF8.GetBytes(_aesIV256);
                aes.Key = Encoding.UTF8.GetBytes(_aesKey256);
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                // Convert string to byte array
                byte[] src = Encoding.Unicode.GetBytes(text);

                // encryption
                using (ICryptoTransform encrypt = aes.CreateEncryptor())
                {
                    byte[] dest = encrypt.TransformFinalBlock(src, 0, src.Length);

                    // Convert byte array to Base64 strings
                    return Convert.ToBase64String(dest);
                }
            }
        }
    }
}