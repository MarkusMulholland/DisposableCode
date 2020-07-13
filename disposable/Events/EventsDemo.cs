using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DisposableCode.Events
{
    public class EventsDemo
    {
        //Declare a delegate that describes the signiture of the event handling method in the subscriber
        public delegate void WorkHasBeenDoneEventHandler(object sender, EventArgs e);

        //In most use casses, The delegate being used to create the event will be of the same signiture(void, with and object and args as parameters).
        //Because of this, .NET includes a predefined delegate that describes this signiture, called EventHandler. If the the event args are a custom type,
        //we can use te generic EventHandler<TEventArgs> type. 
        
        ///public event EventHandler WorkHasBeenDone; 
        public event WorkHasBeenDoneEventHandler WorkHasBeenDone;

        public void DoWork()
        {
            Console.WriteLine("Working...");
            Thread.Sleep(3000);

            OnWorkDone(); //Calls the method which raises the event
        }
        protected virtual void OnWorkDone()
        {
            if (WorkHasBeenDone != null)
            {
                WorkHasBeenDone(this, EventArgs.Empty);
            }

            //Because this code is very common practice, a simpler snippet of code that acheives the same can be defined as follows:
            ///WorkHasBeenDone?.Invoke(this, EventArgs.Empty);
        }
    }
}
