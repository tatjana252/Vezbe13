using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    interface I //opsti domenski objekat
    {
        void i();
    }

    class A : I // seansa
    {
        public virtual void i()
        {
            Console.WriteLine("Seansa"); //Seansa
        }
    }

    class B : A //rebt
    {
        public new void i()
        {
            Console.WriteLine("Rebt");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            A a = new A();
            A b = new B();

            a.i();
            b.i();

        }
    }
}
