using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DisposableCode.HashingData
{
    public static class HashingDataDemo
    {
        public static void HashData()
        {
            
            SHA1CryptoServiceProvider algorithm = new SHA1CryptoServiceProvider();  //Create a new instance of the Hash algorithm
            string stringValue = "Penguin";                               //Declare the data to be hashed
            byte[] byteArray = Encoding.Unicode.GetBytes(stringValue);              //Convert the data into a byte array.

            byte[] dataHashedWithFirstOverload;                                     //Declare a byte array to store the hash of the data
            byte[] dataHashedWithSecondOverload;
            byte[] dataHashedWithThirdOverload;

            Console.WriteLine(stringValue);                                         //Print the plain text
            
            foreach (var item in byteArray)                                         //Print the un hashed byte array
            {
                Console.Write(item); 
            }

            Console.WriteLine("\n");                    

            dataHashedWithFirstOverload = algorithm.ComputeHash(byteArray);         //Create a hash of the byte array using the first overload of the ComputeHash algorithm
            foreach (var item in dataHashedWithFirstOverload)                       //Print the hashed byte array
            {
                Console.Write(item);
            }

            Console.WriteLine("\n");

            dataHashedWithSecondOverload = algorithm.ComputeHash(byteArray, 0, 5);  //Create a hash of the byte array using the second overload of the ComputeHash algorithm.
            foreach (var item in dataHashedWithSecondOverload)                      //Print the hashed byte array
            {
                Console.Write(item);
            }

            Console.WriteLine("\n");

            using (StreamWriter sw = new StreamWriter("test.txt"))
            {
                sw.WriteLine(stringValue);
            }
            using (FileStream stream = new FileStream("test.txt", FileMode.Open))
            {
                dataHashedWithThirdOverload = algorithm.ComputeHash(stream);        //Create a hash of the byte array using the third overload of the ComputeHash algorithm.
                foreach (var item in dataHashedWithThirdOverload)                   //Print the hashed byte array
                {
                    Console.Write(item);
                }

            }


        }
    }
}
