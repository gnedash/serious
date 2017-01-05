using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serious.Users.AppCode.AESEncryption
{
    public interface ICrypto
    {
        /// <summary>
        /// AES ecryption
        /// </summary>
        string Encrypt(string text);
        
        /// <summary>
        /// AES decryption
        /// </summary>
        string Decrypt(string text);
    }
}
