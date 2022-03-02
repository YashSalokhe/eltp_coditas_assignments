using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3
{
    //What will happen if the derive class dows not override all abstract methods of the abstract class?
    //Answer = Error
    abstract class Q14
    {
        public abstract void display();
        public abstract void update();
    }

    //class DerivedQ14 : Q14
    //{
    //    public override void display()
    //    {

    //    }

    //    //public override void update()
    //    //{

    //    //}
    //}
}
