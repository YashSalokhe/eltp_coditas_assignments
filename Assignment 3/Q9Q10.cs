using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3
{
    //9. Can we have internal virtual or abstract methods in abstract class?
    //Answer = Yes!

    //10.Can we have private or protect class?
    //Answer = NO!

    internal class InternalClass
    {
        public virtual void display()
        {
            Console.WriteLine("..");
        }
    }
    public abstract class Q9Q10
    {
        public void display()
        {
            Console.WriteLine("public method in Abstract class");
        }

        public abstract void print();

        }
}
