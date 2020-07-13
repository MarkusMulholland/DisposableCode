using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisposableCode.ExtensionMethods
{
    public static class ExtensionMethods
    {
        public static void AddValues(this int[] collection)
        {
            int result = 0;
            foreach (var item in collection)
            {
                result += item;
            }

            var collectionTwo = collection.Where(i => i % 2 == 0); //Little LINQ fun

            int resultTwo = 0;
            foreach (var item in collectionTwo)
            {
                resultTwo += item;
            }
            Console.WriteLine(result);
            Console.WriteLine(resultTwo);
            
        }

    }
}
