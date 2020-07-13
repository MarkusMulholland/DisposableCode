using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace DisposableCode.Encryption
{
    class EncryptionBestPracticeDemo
    {
        public static byte[] keys;
        public static AesManaged aesAlgorithm = new AesManaged();        
        
        public struct KeyIV
        {            
            public byte[] Key { get; private set; }
            public byte[] IV { get; private set; }
            public KeyIV(byte[] key, byte[] iV)
            {
                this.Key = key;
                this.IV = iV;
            }
        }

        public static KeyIV GetEncryptedKeyAndIV()
        {
            KeyIV keySalt;

            var password = "Pa$$w0rd";
            var salt = "S@lt";

            var rgb = new Rfc2898DeriveBytes(password, Encoding.Unicode.GetBytes(salt));

            aesAlgorithm.Padding = PaddingMode.None;

            var rgbKey = rgb.GetBytes(aesAlgorithm.KeySize / 8);            
            
            var rgbIV = rgb.GetBytes(aesAlgorithm.BlockSize / 8);            
            
            //Encrypt the key and IV
            using (var rsaProvider = new RSACryptoServiceProvider())
            {
                var setOaemPadding = true;

                keys = rsaProvider.ExportCspBlob(true);
                
                keySalt = new KeyIV(rsaProvider.Encrypt(rgbKey, setOaemPadding), rsaProvider.Encrypt(rgbIV, setOaemPadding));
            }
            return keySalt;
        }

        public static void AesWithRSA()
        {
            //Use RSACryptoProvider to decrypt the secret key of the AesAlgorithm algorithm
            var message = "NET Cryptography";
            var messageByteArray = Encoding.UTF8.GetBytes(message);

            byte[] encryptedData;
            byte[] decryptedData;

            //Get the encrypted Key and IV
            var keySalt = GetEncryptedKeyAndIV();            

            using (var rsaProvider = new RSACryptoServiceProvider())
            {
                var setOaemPadding = true;
                rsaProvider.ImportCspBlob(keys);

                //Decrypt the key and IV
                var key = rsaProvider.Decrypt(keySalt.Key, setOaemPadding);
                var iV = rsaProvider.Decrypt(keySalt.IV, setOaemPadding);
                
                //Use the decrypted key and IV in the AES encryptor
                var encryptor = aesAlgorithm.CreateEncryptor(key, iV);

                using (var bufferStream = new MemoryStream())
                using (var cryptoStream = new CryptoStream(bufferStream, encryptor, CryptoStreamMode.Write))
                {
                    cryptoStream.Write(messageByteArray, 0, messageByteArray.Length);

                    encryptedData = bufferStream.ToArray();
                }
            }

            using (var rsaProvider = new RSACryptoServiceProvider())
            {
                var setOaemPadding = true;
                rsaProvider.ImportCspBlob(keys);

                //Decrypt the key and IV
                var key = rsaProvider.Decrypt(keySalt.Key, setOaemPadding);                
                var iV = rsaProvider.Decrypt(keySalt.IV, setOaemPadding);

                //Use the decrypted key and IV in the AES decryptor
                var decryptor = aesAlgorithm.CreateDecryptor(key, iV);

                using (var bufferStream = new MemoryStream())
                using (var cryptoStream = new CryptoStream(bufferStream, decryptor, CryptoStreamMode.Write))
                {
                    cryptoStream.Write(encryptedData, 0, encryptedData.Length);

                    decryptedData = bufferStream.ToArray();
                   
                    Console.WriteLine(Encoding.UTF8.GetString(decryptedData));                                        
                }
            }
        }
    }
}
