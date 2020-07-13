using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisposableCode.Delegates
{
    public static class DelegatesDemo
    {
        //This delegate defines a method signiture which returns void and takes one string parameter
        public delegate void FirstDelegate(string input);

        public static bool UseDelegateActionAndFunc(FirstDelegate firstDelegate, Action<string> calculateRoot, Func<string, int> calculateCube)
        {                        
            string input = Console.ReadLine();
            firstDelegate(input);
            calculateRoot(input);
            Console.WriteLine(calculateCube(input));
            return true;
        }

        public static void UseDelegateWithDifferentMethods(FirstDelegate firstDelegate)
        {
            string input = Console.ReadLine();
            firstDelegate(input);

        }
        public static void SquareInput(string input)                //Declare a method with the same signiture defined by the Delegate
        {
            try
            {
                int baseInt = Convert.ToInt32(input);
                Console.WriteLine(baseInt * baseInt);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }

        public static void FindRootOfInput(string input)            //Declare a method with the same signiture defined by the Action
        {            
            try
            {
                int baseInt = Convert.ToInt32(input);
                Console.WriteLine(Math.Sqrt(baseInt));
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }

        public static int CubeInput(string input)                   //Declare a method with the same signiture defined by the Func
        {
            try
            {
                int baseInt = Convert.ToInt32(input);
                return (baseInt * baseInt) * baseInt;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }
        }        
    }
}
