using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisposableCode.Interfaces
{
    public class ImplementIEnumerable : IEnumerable
    {
        int[] array = new int[] { 0, 1, 2, 3 };

        public IEnumerator GetEnumerator()
        {
            //return array.GetEnumerator();  OR
            for (int i = 0; i < array.Length; i++)
            {
                yield return array[i];
            }
        }
    }
}
