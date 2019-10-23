using System;
using System.IO;
using System.Security.Cryptography;

namespace DEDEV
{
	// Token: 0x02000002 RID: 2
	public class FileEncryption
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
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
			using (FileStream fileStream = new FileStream(outputFile, FileMode.CreateNew, FileAccess.Write, FileShare.None))
			{
				using (CryptoStream cryptoStream = new CryptoStream(fileStream, transform, CryptoStreamMode.Write))
				{
					try
					{
						using (FileStream fileStream2 = new FileStream(sourceFile, FileMode.Open, FileAccess.Read, FileShare.Read))
						{
							fileStream2.CopyTo(cryptoStream);
						}
					}
					catch (Exception ex)
					{
						throw ex;
					}
				}
			}
		}

		// Token: 0x06000002 RID: 2 RVA: 0x00002174 File Offset: 0x00000374
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
			using (FileStream fileStream = new FileStream(outputFile, FileMode.CreateNew, FileAccess.Write, FileShare.None))
			{
				using (CryptoStream cryptoStream = new CryptoStream(fileStream, transform, CryptoStreamMode.Write))
				{
					using (FileStream fileStream2 = new FileStream(sourceFile, FileMode.Open, FileAccess.Read, FileShare.Read))
					{
						fileStream2.CopyTo(cryptoStream);
					}
				}
			}
		}

		// Token: 0x04000001 RID: 1
		public static byte[] salt = new byte[]
		{
			1,
			2,
			3,
			4,
			254,
			252,
			244,
			248
		};

		// Token: 0x04000002 RID: 2
		public const int repeat = 777;
	}
}
