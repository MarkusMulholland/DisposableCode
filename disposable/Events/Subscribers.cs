using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisposableCode.Events
{
    public class Subscribers
    {
        public void EventHandler(object sender, EventArgs args)
        {
            Console.WriteLine("Work in the EventsDemo class has been done.\nThis message comes from one method in the Subscribers class");
        }

        public void EventHandlerTwo(object sender, EventArgs args)
        {
            Console.WriteLine("Work in the EventsDemo class has been done.\nThis message comes from another method in the Subscribers class");
        }
    }
}
