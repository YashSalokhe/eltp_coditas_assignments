using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3
{
    //7.Can we have same property in base and derived class?
    //Answer = Yes

    //11.Can we have internal property?
    //Answer = Yes

    internal class classInternal
    {
        public int date { get; set; }

    }
    class Q7Q11
    {
        public int name { get; set; }
    }

    class DerivedQ7 : Q7Q11
    {
        //use the new keyword or shadow casting
        public int name { get; set; }
    }
}
