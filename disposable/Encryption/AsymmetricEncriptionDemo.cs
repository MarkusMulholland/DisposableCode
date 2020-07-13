using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace DisposableCode.Encryption
{
    public static class AsymmetricEncriptionDemo
    {
        public static void EncryptDecryptWithRSA()
        {
            var plainText = "P";
            var plainBytes = Encoding.Default.GetBytes(plainText);
            var decryptedText = string.Empty;
            
            foreach (var item in plainBytes)                                            //Display the plain bytes
            {
                Console.Write(item.ToString());
            }
            Console.WriteLine();
                        
            using (var rsaProvder = new RSACryptoServiceProvider())                     //Instaniate the RSACryptoServiceProvider object
            {
                var useOaemPadding = false;             
                var encryptedBytes = rsaProvder.Encrypt(plainBytes, useOaemPadding);    //Use the Encrypt method to encrypt the byte array
                                
                foreach (var item in encryptedBytes)                                    //Display the encrypted bytes
                {
                    Console.Write(item.ToString());
                }
                Console.WriteLine();
                
                var decryptedBytes = rsaProvder.Decrypt(encryptedBytes, useOaemPadding);    //Use the Decrypt method to decrypt the byte array
                                
                decryptedText = Encoding.Default.GetString(decryptedBytes);             //Convert the byte array to a string
                                
                Console.WriteLine(decryptedText);                                       //Display the origional string

            }
        }
    }
}
