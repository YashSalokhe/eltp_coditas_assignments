using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3
{

    //2.
    //Can we override the private virtual method of abstract
    //class using public method from the deriuved class?

    //Answer = No!
    //virtual or abstract members cannot be private



    //3.
    //Can we have private and protected abstract and virtual methods in abstract base class?

    //Answer = No! (Private = NO! Protected =  Yess)
    //virtual or abstract members cannot be private



    //public abstract class BaseClass
    //{
    //    private virtual int Add(int x, int y)
    //    {
    //        return x + y;
    //    }

    //    protected virtual int Sub(int x, int y)
    //    {
    //        return x - y;
    //    }
    //}
    //public class OverloadingPrivateVirtualMethodByDerivedClass : BaseClass
    //{
    //    public override int Add(int x,int y)
    //    {
    //        Console.WriteLine("derived Class");
    //        return x + y;
    //    }

    //}
}
