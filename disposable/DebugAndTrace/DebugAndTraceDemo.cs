using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisposableCode.DebugAndTrace
{
    public static class DebugAndTraceDemo
    {
        public static void RunDebugMethods()
        {
            ///ALL OF THESE WILL ONLY RUN IN DEBUG MODE

            //This will cause all text output to the Debug window be Indented.
            Debug.Indent();

            //This will write a string to the Debug window.
            Debug.WriteLineIf(1 == 1, "This will return this text to the output if the statement evaluates to true");

            //This will cause all text output to the Debug window be Unindented.
            Debug.Unindent();

            //Throw an error window if the boolean expression passed as a parameter to the Debug.Assert method returns false.
            Debug.Assert(1+1 == 11);
        }
    }
}
