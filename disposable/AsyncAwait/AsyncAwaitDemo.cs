using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisposableCode.AsyncAwait
{
    public static class AsyncAwaitDemo
    {
        public static async Task RunMethodAsync()               //Declare the method with the async keyword to specify that its implementation detail will implement threading and the await keyword
        {         
            Task[] listOTasks = new Task[]                      //Instantiate and initialize an array of Task objects
            {
                Task.Run(() =>
                {
                    for (int i = 0; i < 1000; i++)
                    {
                        Console.WriteLine(i);
                    }
                }),
                Task.Run(() =>
                {
                    for (int i = 100000; i < 105000; i++)
                    {
                        Console.WriteLine(i);
                    }
                })
            };

            Task.WaitAll(listOTasks);                           //Use the WaitAll method of the Task object, passing the Task array, to ensure execution waits for all the Tasks to complete.

            await Task.Run(() =>                                //Use the await keyword to specify that execution should wait for the Task to complete before continuing.
            {
                for (int i = 0; i < 10000; i++)
                {
                    Console.WriteLine(i);
                }
            });

            Environment.Exit(0);            
        }
    }
}
