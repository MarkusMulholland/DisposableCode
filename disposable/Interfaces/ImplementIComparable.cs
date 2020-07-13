using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisposableCode.Interfaces
{
    class ImplementIComparable 
    {
        List<Person> people = new List<Person>();

        public ImplementIComparable()
        {
            people.Add(new Person(1));
            people.Add(new Person(2));
            people.Add(new Person(3));
            people.Add(new Person(4));

            people.Sort();

            foreach (var item in people)
            {
                Console.WriteLine(item.Id);
            }
        }

        
        
    }
    class Person : IComparable<Person>
    {
        public int Id { get; set; }

        public Person(int id)
        {
            this.Id = id;
        }

        public int CompareTo(Person person)
        {
            return this.Id.CompareTo(person.Id);
        }
    }
}
