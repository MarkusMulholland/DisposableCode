using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DisposableCode.Encryption
{
    public static class SymmetricalEncryptionDemo
    {
        public static void EncyptDecryptData()
        {

            //    string a = "abcdefghabcdefgh";
            //    Console.WriteLine(a);
            //    var bytes = Encoding.UTF8.GetBytes(a);

            //    foreach (var item in bytes)
            //    {
            //        Console.Write(item);
            //    }

            //    var algorithm = new RijndaelManaged();
            //    algorithm.Padding = PaddingMode.None;

            //    var encryptor = algorithm.CreateEncryptor();
            //    var decryptor = algorithm.CreateDecryptor();

            //    byte[] encryptedBytes;
            //    Console.WriteLine();
            //    using (MemoryStream stream = new MemoryStream())
            //    using (CryptoStream cryptoStream = new CryptoStream(stream, encryptor, CryptoStreamMode.Write))
            //    {
            //        cryptoStream.Write(bytes, 0, bytes.Length);
            //        cryptoStream.FlushFinalBlock();
            //        cryptoStream.Close();
            //        encryptedBytes = stream.ToArray();

            //        foreach (var item in encryptedBytes)
            //        {
            //            Console.Write(item);
            //        }
            //    }

            //Console.WriteLine("----------------------");
            //using (MemoryStream stream = new MemoryStream())
            //using (CryptoStream cryptoStream = new CryptoStream(stream, decryptor, CryptoStreamMode.Write))
            //{
            //    cryptoStream.Write(encryptedBytes, 0, bytes.Length);
            //    cryptoStream.FlushFinalBlock();
            //    cryptoStream.Close();
            //    var streamArray = stream.ToArray();

            //    foreach (var item in streamArray)
            //    {
            //        Console.WriteLine(item);
            //    }
            //}
            string toEncode = "Hey Sexy Penguin";                                               //Create initial string and convert it to a byte array
            byte[] toEncodeAsByteArray = Encoding.ASCII.GetBytes(toEncode);
                        
            Console.WriteLine(toEncode);                                                        //Displays the initial string and the byte array                                       
            foreach (var item in toEncodeAsByteArray)
            {
                Console.Write(item.ToString());
            }
            Console.WriteLine();
            
            var encryptedBytes = default(byte[]);                                               //Create variables to hold the encrypted and decrypted bytes
            var decryptedBytes = default(byte[]);
            
            var password = "Pa$$w0rd";                                                                  
            var salt = "s@lt";
            var rgb = new Rfc2898DeriveBytes(password, Encoding.Unicode.GetBytes(salt));        //Create a Rfc2898DeriveBytes object, which you will use to derive the secret key and IV.

            var algorithm = new AesManaged();                                                   //Create an instance of the encryption algorithm you want to use.
            
            algorithm.Padding = PaddingMode.None;                                               //Set the padding mode
            
            var rgbKey = rgb.GetBytes(algorithm.KeySize / 8);                                   //Generate a secret key and IV from the Rfc2898DerviveBytes instance.
            var rgbIV = rgb.GetBytes(algorithm.BlockSize / 8);
                        
            using (var bufferStream = new MemoryStream())                                       //Create a stream object that you will use to buffer the encrypted bytes.
            {                
                var encryptor = algorithm.CreateEncryptor(rgbKey, rgbIV);                       //Create an encryption object using the CreateEmcryptormethod in the AesManaged instance.
                                               
                using (var cryptoStream = new CryptoStream(bufferStream, encryptor, CryptoStreamMode.Write))    //Create CryptoStream object, which will be used to write the cryptographic bytes to the buffer stream. Pass the bufferStream object, the algorithm object and the stream mode(Read/Write).
                {                                      
                    var bytesToTransform = toEncodeAsByteArray;
                    cryptoStream.Write(bytesToTransform, 0, bytesToTransform.Length);           //Invoke the Write the CryptoStream object to perform the cryptographic transform.
                                        
                    encryptedBytes = bufferStream.ToArray();                                    //Convert the buffer stream to a byte array and display it

                    foreach (var item in encryptedBytes)
                    {
                        Console.Write(item.ToString());
                    }
                }
            }
            
            using (var bufferStream = new MemoryStream())                                       //Create a buffer stream that will buffer the decrypted data
            {                               
                var decryptor = algorithm.CreateDecryptor(rgbKey, rgbIV);                       //Create an decryption object using the CreateDecryptor method in the AesManaged instance.
                               
                using (var cryptoStream = new CryptoStream(bufferStream, decryptor, CryptoStreamMode.Write))    //Create CryptoStream object, which will be used to write the cryptographic bytes to the buffer stream. Pass the bufferStream object, the algorithm object and the stream mode(Read/Write).
                {                    
                    cryptoStream.Write(encryptedBytes, 0, encryptedBytes.Length);               //Invoke the Write and FlushFinalBlock methods on the CryptoStream object to perform the cryptographic transform.
                                        
                    decryptedBytes = bufferStream.ToArray();                                    //Convert the stream to an array

                    Console.WriteLine();
                                        
                    string decryptedString = Encoding.ASCII.GetString(decryptedBytes);          //Convert the array into a string and display it as well as the byte array

                    foreach (var item in decryptedBytes)
                    {
                        Console.Write(item.ToString());
                    }

                    Console.WriteLine("\n" + decryptedString);
                }
            }
        }        
    }
}
