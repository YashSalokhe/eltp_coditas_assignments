using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3
{

    //4.Can we have method overloading across base and deried classe?
    //Answer = Yes!


    //8.Can we derive a public class from internal class?
    // Answer = NO! we can't inherit internal class to public class


    //12.Can we have virtual method in not-abstract class?
    // Answer = Yes 


    //13.Can we have abstract method in not-abstract class?
    //Answer = NO!
    public class Q4Q8Q12Q13
    {
        public int Add(int x, int y , int z , int mult)
        {
            return (x + y + z) * mult;
        }

        //public abstract void Display();

        public virtual void Display()
        {
            Console.WriteLine("yes");
        }
        

    }

    public class MethodOverloadingInDerived: Q4Q8Q12Q13
    {
        public int Add(int x, int y , int z , int mult , int div)
        {
            return ((x + y + z) * mult)/div;
        }
    }
}
