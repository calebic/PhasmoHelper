using System;
using System.IO;
using System.Security.Cryptography;

namespace Phasmophobia_Save_Editor
{
    // Token: 0x02000002 RID: 2
    internal class Crypto
    {
        // Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
        public static byte[] DecryptSaveData(byte[] data)
        {
            byte[] result;
            using (MemoryStream memoryStream = new MemoryStream(data))
            {
                using (MemoryStream memoryStream2 = new MemoryStream())
                {
                    byte[] array = new byte[16];
                    memoryStream.Read(array, 0, 16);
                    using (Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes("t36gref9u84y7f43g", array, 100))
                    {
                        using (Aes aes = Aes.Create())
                        {
                            aes.Mode = CipherMode.CBC;
                            aes.Padding = PaddingMode.PKCS7;
                            aes.Key = rfc2898DeriveBytes.GetBytes(16);
                            aes.IV = array;
                            using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Read))
                            {
                                cryptoStream.CopyTo(memoryStream2);
                            }
                        }
                    }
                    result = memoryStream2.ToArray();
                }
            }
            return result;
        }

        // Token: 0x06000002 RID: 2 RVA: 0x00002158 File Offset: 0x00000358
        public static byte[] EncryptSaveData(byte[] data)
        {
            byte[] result;
            using (MemoryStream memoryStream = new MemoryStream(data))
            {
                using (MemoryStream memoryStream2 = new MemoryStream())
                {
                    byte[] array = new byte[16];
                    new Random().NextBytes(array);
                    memoryStream2.Write(array, 0, 16);
                    using (Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes("t36gref9u84y7f43g", array, 100))
                    {
                        using (Aes aes = Aes.Create())
                        {
                            aes.Mode = CipherMode.CBC;
                            aes.Padding = PaddingMode.PKCS7;
                            aes.Key = rfc2898DeriveBytes.GetBytes(16);
                            aes.IV = array;
                            using (CryptoStream cryptoStream = new CryptoStream(memoryStream2, aes.CreateEncryptor(), CryptoStreamMode.Write))
                            {
                                memoryStream.CopyTo(cryptoStream);
                            }
                        }
                    }
                    result = memoryStream2.ToArray();
                }
            }
            return result;
        }

        // Token: 0x04000001 RID: 1
        private const string PASSWORD = "t36gref9u84y7f43g";
    }
}
