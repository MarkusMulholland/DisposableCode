using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisposableCode.Basics
{
    class MathOperators
    {
        public MathOperators()
        {
            //We will use these Integers to store the value of the arithmetic operations.
            int a, b, c, d;

            //We will apply the operators to these Integers 
            int x;
            int y;      

            x = 4;
            y = 2;

            a = x + y;  // a = 6
            b = x - y;  // b = 2
            c = x * y;  // c = 8
            d = x / y;  // d = 2

            a += x;     // This is the same as writing a = a + x || a = 6 + 4 = 10
            b -= y;     // This is the same as writing b = b - y || b = 2 - 2 = 0 
            c *= x;     // This is the same as writing c = c * x || c = 8 * 4 = 32
            d /= y;     // This is the same as writing d = d / y || d = 2 / 2 = 1 
        }
    }
}
