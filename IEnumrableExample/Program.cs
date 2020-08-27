using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnumrableExample
{
    class Program
    {
        static void Main(string[] args)
        {
            People p = new People(new Person("Avi"), new Person("Dan"), new Person("Tom"));
            //the foreach loop takes an IEnumrable type as the collection.
            //this allows to Enumerate the collection,(map it movement)
            //and interact with that enum
            foreach (Person person in p)
            {
                Console.WriteLine(person);
            }
        }
    }
}
