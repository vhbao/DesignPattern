using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    class SubsystemOne
    {
        public void MethodOne()
        {
            Console.WriteLine("+ MethodOne");
        }
    }
    class SubsystemTwo
    {
        public void MethodTwo()
        {
            Console.WriteLine("+ MethodTwo");
        }
    }
    class SubsystemThree
    {
        public void MethodThree()
        {
            Console.WriteLine("+ MethodThree");
        }
    }
    class Facade
    {
        private SubsystemOne subsystemOne;
        private SubsystemTwo subsystemTwo;
        private SubsystemThree subsystemThree;
        public Facade()
        {
            subsystemOne = new SubsystemOne();
            subsystemTwo = new SubsystemTwo();
            subsystemThree = new SubsystemThree();
        }
        public void MethodFacadeA()
        {
            Console.WriteLine("- MethodFacadeA");
            subsystemOne.MethodOne();
            subsystemTwo.MethodTwo();
        }
        public void MethodFacadeB()
        {
            Console.WriteLine("- MethodFacadeB");
            subsystemOne.MethodOne();
            subsystemTwo.MethodTwo();
            subsystemThree.MethodThree();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Facade facade = new Facade();
            facade.MethodFacadeA();
            facade.MethodFacadeB();
            Console.ReadLine();
        }
    }
}
