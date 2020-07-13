using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisposableCode.Interfaces
{
    public class ImplementInterfacesWithTheSameMethodSigniture : ITestOne, ITestTwo
    {
        public ImplementInterfacesWithTheSameMethodSigniture()
        {
            
        }

        void ITestOne.DoWork()
        {
            Console.WriteLine("This is implementing the first Interface");
        }

        public void DoWork()
        {
            Console.WriteLine("This is implementing the second Interface");
        }
    }

    public interface ITestOne
    {
        void DoWork();
    }
    public interface ITestTwo
    {
        void DoWork();
    }
}
