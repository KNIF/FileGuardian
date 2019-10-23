using System;
using System.IO;
using System.Security.Cryptography;

namespace FileGuardian
{
    class FileEncryption
    {
        public const int repeat = 777;
        public static byte[] salt = new byte[] { 21, 56, 8, 68, 91, 66, 90, 31, 44, 69, 77, 39, 57, 30, 29, 7, 10, 78, 46, 83, 89, 80, 62, 63, 42, 13, 41, 70, 65, 75, 67, 11, 52, 45, 59, 15, 38, 35, 19, 76, 23, 93, 79, 25, 53, 24, 87, 50, 22, 12 };

        public static void DecryptFile(string sourceFile, string outputFile, string key, byte[] salt, int repeat)
        {
            AesManaged aesManaged = new AesManaged();
            aesManaged.BlockSize = aesManaged.LegalBlockSizes[0].MaxSize;
            aesManaged.KeySize = aesManaged.LegalKeySizes[0].MaxSize;
            Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(key, salt, repeat);
            aesManaged.Key = rfc2898DeriveBytes.GetBytes(aesManaged.KeySize / 8);
            aesManaged.IV = rfc2898DeriveBytes.GetBytes(aesManaged.BlockSize / 8);
            aesManaged.Mode = CipherMode.CBC;
            ICryptoTransform transform = aesManaged.CreateDecryptor(aesManaged.Key, aesManaged.IV);
            using (FileStream fileStream = new FileStream(outputFile, FileMode.CreateNew, FileAccess.Write, FileShare.None)) {
                using (CryptoStream cryptoStream = new CryptoStream(fileStream, transform, CryptoStreamMode.Write)) {
                    try {
                        using (FileStream fileStream2 = new FileStream(sourceFile, FileMode.Open, FileAccess.Read, FileShare.Read)) {
                            fileStream2.CopyTo(cryptoStream);
                        }
                    }
                    catch (Exception ex) {
                        throw ex;
                    }
                }
            }
        }

        public static void EncryptFile(string sourceFile, string outputFile, string key, byte[] salt, int repeat)
        {
            AesManaged aesManaged = new AesManaged();
            aesManaged.BlockSize = aesManaged.LegalBlockSizes[0].MaxSize;
            aesManaged.KeySize = aesManaged.LegalKeySizes[0].MaxSize;
            Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(key, salt, repeat);
            aesManaged.Key = rfc2898DeriveBytes.GetBytes(aesManaged.KeySize / 8);
            aesManaged.IV = rfc2898DeriveBytes.GetBytes(aesManaged.BlockSize / 8);
            aesManaged.Mode = CipherMode.CBC;
            ICryptoTransform transform = aesManaged.CreateEncryptor(aesManaged.Key, aesManaged.IV);
            using (FileStream fileStream = new FileStream(outputFile, FileMode.CreateNew, FileAccess.Write, FileShare.None)) {
                using (CryptoStream cryptoStream = new CryptoStream(fileStream, transform, CryptoStreamMode.Write)) {
                    using (FileStream fileStream2 = new FileStream(sourceFile, FileMode.Open, FileAccess.Read, FileShare.Read)) {
                        fileStream2.CopyTo(cryptoStream);
                    }
                }
            }
        }
    }
}