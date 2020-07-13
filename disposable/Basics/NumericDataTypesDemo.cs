using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisposableCode.Basics
{
    class NumericDataTypesDemo
    {
        #region FLOATING POINT NUMERIC DATATYPES           

        public void foo()
        {
                float floatDataType = 3.14F;
                //Size: 4  bytes | Precision: 7 digits

                double doubleDataType = 3.14;
                //Size: 8  bytes | Precision: 14-15 digits

                decimal decimalDataType = 3.14M;
                //Size: 16 bytes | Precision: 28-29 digits            
        }    

        #endregion

        #region NON FLOATING POINT NUMERIC DATA TYPES

        ///Unsigned Numeric Data Types:

        byte unsignedByte = 255;
        //Size: 1 byte  | Range: 0 - 255

        ushort unsignedShort = 65535;
        //Size: 2 bytes | Range: 0 - 65,535

        uint   unsignedInteger = 4294967295;
        //Size: 4 bytes | Range: 0 - 4,294,967,295

        ulong  unsignedLong = 18446744073709551615;
        //Size: 8 bytes | Range: 0 - 18,446,744,073,709,551,615


        ///Signed Numeric Data Types:

        sbyte signedByte = 127;
        //Size: 1 byte  | Range: -128 - 127

        short signedShort = 32767;
        //Size: 2 bytes | Range: -32,768 - 32,767

        int   signedInt = 2147483647;
        //Size: 4 bytes | Range: -2,147,483,648 - 2,147,483,647

        long  signedLong = 9223372036854775807;
        //Size: 8 bytes | Range: -9,223,372,036,854,775,808 - 9,223,372,036,854,775,807

        #endregion
    }
}
