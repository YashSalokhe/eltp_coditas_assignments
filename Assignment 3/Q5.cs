using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3
{
    //Can we type cast the derived class instance using the base class?
    //Answer = No down casting not possible
    class Q5
    {
        public string Name { get; set; }
        public void display()
        {
            Console.WriteLine("In base class");
        }
    }

    class derivedQ5 : Q5
    {
        public void Play()
        {
            Console.WriteLine("In derived class");
        }
    }
}
