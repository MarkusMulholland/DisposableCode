#define PI
#define TAKARA

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisposableCode.CompilerDirectives
{
    class CompilerDirectivesDemo
    {
        public static void foo()
        {
#if (PI)
            Console.WriteLine("PI is defined");
#elif (TAKARA)
            Console.WriteLine("PI is not defined");
#endif
            
        }

    }
}
