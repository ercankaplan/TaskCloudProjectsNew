
using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;
namespace WSD.TaskCloud.MVC.HelperClasses
{


    public class FileEncDec
    {
        private int keySize;
        private string passPhrase;

        internal FileEncDec(int keySize = 256, string passPhrase = @"This is pass phrase key to use for testing")
        {
            this.keySize = keySize;
            this.passPhrase = passPhrase; // Can be user selected and must be kept secret
        }

        private static byte[] GenerateSalt(int length)
        {
            byte[] salt = new byte[length];

            // Populate salt with cryptographically strong bytes.
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();

            rng.GetNonZeroBytes(salt);

            // Split salt length (always one byte) into four two-bit pieces and store these pieces in the first four bytes 
            // of the salt array.
            salt[0] = (byte)((salt[0] & 0xfc) | (length & 0x03));
            salt[1] = (byte)((salt[1] & 0xf3) | (length & 0x0c));
            salt[2] = (byte)((salt[2] & 0xcf) | (length & 0x30));
            salt[3] = (byte)((salt[3] & 0x3f) | (length & 0xc0));

            return salt;
        }

        internal bool EncryptFile(string inputFile, string outputFile)
        {
            try
            {
                byte[] salt = GenerateSalt(16); // Salt needs to be known for decryption (can be safely stored in the file)
                Rfc2898DeriveBytes derivedBytes = new Rfc2898DeriveBytes(passPhrase, salt, 10000);
                int bytesRead, bufferSize = keySize / 8;
                byte[] data = new byte[bufferSize];
                RijndaelManaged cryptor = new RijndaelManaged();
                cryptor.Key = derivedBytes.GetBytes(keySize / 8);
                cryptor.IV = derivedBytes.GetBytes(cryptor.BlockSize / 8);

                using (var fsIn = new FileStream(inputFile, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, FileOptions.SequentialScan))
                {
                    using (var fsOut = new FileStream(outputFile, FileMode.Create, FileAccess.Write, FileShare.None, 4096, FileOptions.SequentialScan))
                    {
                        // Add the salt to the file
                        fsOut.Write(salt, 0, salt.Length);

                        using (CryptoStream cs = new CryptoStream(fsOut, cryptor.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            while ((bytesRead = fsIn.Read(data, 0, bufferSize)) > 0)
                            {
                                cs.Write(data, 0, bytesRead);
                            }
                        }
                    }
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        internal bool EncryptFileV2(System.IO.Stream inputStream, string outputFile)
        {
            try
            {
                byte[] salt = GenerateSalt(16); // Salt needs to be known for decryption (can be safely stored in the file)
                Rfc2898DeriveBytes derivedBytes = new Rfc2898DeriveBytes(passPhrase, salt, 10000);
                int bytesRead, bufferSize = keySize / 8;
                byte[] data = new byte[bufferSize];
                RijndaelManaged cryptor = new RijndaelManaged();
                cryptor.Key = derivedBytes.GetBytes(keySize / 8);
                cryptor.IV = derivedBytes.GetBytes(cryptor.BlockSize / 8);


                using (var fsOut = new FileStream(outputFile, FileMode.Create, FileAccess.Write, FileShare.None, 4096, FileOptions.SequentialScan))
                {
                    // Add the salt to the file
                    fsOut.Write(salt, 0, salt.Length);

                    using (CryptoStream cs = new CryptoStream(fsOut, cryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        while ((bytesRead = inputStream.Read(data, 0, bufferSize)) > 0)
                        {
                            cs.Write(data, 0, bytesRead);
                        }
                    }

                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        internal bool DecryptFile(string inputFile, string outputFile)
        {
            try
            {
                int bytesRead = 0, bufferSize = keySize / 8, saltLen;
                byte[] data = new byte[bufferSize], salt;
                Rfc2898DeriveBytes derivedBytes;
                RijndaelManaged cryptor = new RijndaelManaged();    // Create new cryptor so it's thread safe and don't need to use locks

                using (var fsIn = new FileStream(inputFile, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, FileOptions.SequentialScan))
                {
                    // Retrieve the salt length from the file
                    fsIn.Read(data, 0, 4);

                    saltLen = (data[0] & 0x03) |
                                (data[1] & 0x0c) |
                                (data[2] & 0x30) |
                                (data[3] & 0xc0);

                    salt = new byte[saltLen];
                    Array.Copy(data, salt, 4);

                    // Retrieve the remaining salt from the file and create the cryptor
                    fsIn.Read(salt, 4, saltLen - 4);
                    derivedBytes = new Rfc2898DeriveBytes(passPhrase, salt, 10000);
                    cryptor.Key = derivedBytes.GetBytes(keySize / 8);
                    cryptor.IV = derivedBytes.GetBytes(cryptor.BlockSize / 8);

                    using (var fsOut = new FileStream(outputFile, FileMode.Create, FileAccess.Write, FileShare.None, 4096, FileOptions.SequentialScan))
                    {
                        using (var cs = new CryptoStream(fsIn, cryptor.CreateDecryptor(), CryptoStreamMode.Read))
                        {
                            while ((bytesRead = cs.Read(data, 0, bufferSize)) > 0)
                            {
                                fsOut.Write(data, 0, bytesRead);
                            }
                        }
                    }
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        internal bool DecryptFileV2(string inputFile, Stream outputFileStream)
        {
            try
            {
               
                int bytesRead = 0, bufferSize = keySize / 8, saltLen;
                byte[] data = new byte[bufferSize], salt;
                Rfc2898DeriveBytes derivedBytes;
                RijndaelManaged cryptor = new RijndaelManaged();    // Create new cryptor so it's thread safe and don't need to use locks

                using (var fsIn = new FileStream(inputFile, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, FileOptions.SequentialScan))
                {
                    // Retrieve the salt length from the file
                    fsIn.Read(data, 0, 4);

                    saltLen = (data[0] & 0x03) |
                                (data[1] & 0x0c) |
                                (data[2] & 0x30) |
                                (data[3] & 0xc0);

                    salt = new byte[saltLen];
                    Array.Copy(data, salt, 4);

                    // Retrieve the remaining salt from the file and create the cryptor
                    fsIn.Read(salt, 4, saltLen - 4);
                    derivedBytes = new Rfc2898DeriveBytes(passPhrase, salt, 10000);
                    cryptor.Key = derivedBytes.GetBytes(keySize / 8);
                    cryptor.IV = derivedBytes.GetBytes(cryptor.BlockSize / 8);

                    using (var fsOut = outputFileStream)
                    {
                        using (var cs = new CryptoStream(fsIn, cryptor.CreateDecryptor(), CryptoStreamMode.Read))
                        {
                            while ((bytesRead = cs.Read(data, 0, bufferSize)) > 0)
                            {
                                fsOut.Write(data, 0, bytesRead);
                            }
                        }
                    }
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}