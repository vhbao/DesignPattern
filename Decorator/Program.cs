using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    interface IPizza
    {
        string DoPizza();
    }
    class ChickenPizza : IPizza
    {
        public string DoPizza()
        {
            return "Do pizza chicken ";
        }
    }
    abstract class PizzaDecorator : IPizza
    {
        protected IPizza pizza;
        public PizzaDecorator(IPizza _pizza)
        {
            pizza = _pizza;
        }
        public virtual string DoPizza()
        {
            return pizza.DoPizza();
        }
    }
    class CheeseDocorator: PizzaDecorator
    {
        public CheeseDocorator(IPizza _pizza):base(_pizza)
        {
            
        }
        public override string DoPizza()
        {
            return pizza.DoPizza() + AddCheese();
        }
        private string AddCheese()
        {
            return "cheese";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ChickenPizza chickenPizza = new ChickenPizza();
            Console.WriteLine(chickenPizza.DoPizza());

            CheeseDocorator cheeseDocorator = new CheeseDocorator(chickenPizza);
            Console.WriteLine(cheeseDocorator.DoPizza());
            Console.ReadLine();
        }
    }
}
