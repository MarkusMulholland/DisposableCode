using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisposableCode.LINQ
{
    class LINQDemo
    {
        List<Person> people = new List<Person>();              
        
        public LINQDemo()
        {
            people.Add(new Person("Takara", 16));
            people.Add(new Person("Markus", 19));
            people.Add(new Person("Sarah", 1));
            people.Add(new Person("James", 25));
            people.Add(new Person("Sam", 21));
            people.Add(new Person("Lucus", 36));

        }

        public void RunLINQ()
        {
            foreach (var item in people)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine();
            var x = people.Where(p => p.Age < 20).Select(p => p.Age);   //LINQ Where and Select extension method
            var xAfterQuery = x.ToList();

            foreach (var item in xAfterQuery)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            var y = people.OrderBy(p => p.Name);                        //LINQ OrderBy extension method
            var yAfterSort = y.ToList();

            foreach (var item in yAfterSort)
            {
                Console.WriteLine(item.Name);
            }


            var h = people.Sum(p => p.Age);                             //LINQ Sum extension method
            Console.WriteLine(h);

            Console.WriteLine();
            var z = people.SingleOrDefault(p => p.Name == "Takara");    //LINQ SignleOrDefault extension method
            Console.WriteLine(z.Name);

        }
    }
}
