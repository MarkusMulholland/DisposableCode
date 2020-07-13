using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisposableCode.Inheritance
{
    public class InheritanceDemo
    {
        public static void DemonstrateTypeInheritance()
        {
            TypeTwo test = new TypeTwo(5);
            TestMethod(test);
            Console.WriteLine(test.X);      //Even though TypeTwo does not explecitly implement a member called "X", it is contained within it's implementation because it inherits the members from TypeOne.

            TypeOne typeTwoAsTypeOne = test as TypeOne;

            bool isCompatible = test is TypeOne;
        }

        static void TestMethod(TypeOne x)   //This method accepts a parameter of type TypeOne but because TypeTwo is derived from TypeOne, it is also accepted as a parameter.
        {

        }
    }
    public class TypeOne
    {
        public int X { get; private set; }
        public TypeOne(int x)
        {
            this.X = x;
            
        }        
    }

    public class TypeTwo : TypeOne
    {
        public int RandomProp { get; set; }
        public TypeTwo(int x)
            : base(x)                       //This is needed to satisfy the constructor requirements in the base class
        {
           
        }
    }
}
