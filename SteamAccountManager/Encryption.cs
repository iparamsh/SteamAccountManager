using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace SteamAccountManager
{
    class Encryption
    {
        public string ComputeSHA256Hash(string data)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] dataBytes = Encoding.UTF8.GetBytes(data);
                byte[] hashBytes = sha256.ComputeHash(dataBytes);
                string hash = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();

                return hash;
            }
        }

        public byte[] Encrypt(string plainText, byte [] key)
        {
            byte[] encryptedBytes;
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.Mode = CipherMode.ECB;
                aesAlg.Padding = PaddingMode.PKCS7;
                ICryptoTransform encryptor = aesAlg.CreateEncryptor();
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        byte[] plaintextBytes = Encoding.UTF8.GetBytes(plainText);
                        csEncrypt.Write(plaintextBytes, 0, plaintextBytes.Length);
                    }
                    encryptedBytes = msEncrypt.ToArray();
                }
            }
            return encryptedBytes;
        }

        public string Decrypt(byte[] cipherText, byte [] key)
        {
            string plainText;
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.Mode = CipherMode.ECB;
                aesAlg.Padding = PaddingMode.PKCS7;
                ICryptoTransform decryptor = aesAlg.CreateDecryptor();
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            plainText = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
            return plainText;
        }

        public byte[] stripKey(byte[] keycpy)
        {
            byte[] key = new byte[16];

            for (int ctr = 0; ctr < 16; ctr++)
            {
                key[ctr] = keycpy[ctr];
            }

            return key;
        }
    }
}
