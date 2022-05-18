using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    abstract class Name
    {
        public abstract void getName();
    }
    abstract class Age
    {
        public abstract void getAge();
    }
    class DogName : Name
    {
        public override void getName()
        {
            Console.WriteLine("DogName!");
        }
    }
    class DogAge : Age
    {
        public override void getAge()
        {
            Console.WriteLine("DogAge!");
        }
    }
    class CatName : Name
    {
        public override void getName()
        {
            Console.WriteLine("CatName!");
        }
    }
    class CatAge : Age
    {
        public override void getAge()
        {
            Console.WriteLine("CatAge!");
        }
    }
    abstract class AnimalFactory
    {
        public abstract Name createName();
        public abstract Age createAge();
    }
    class DogFactory: AnimalFactory
    {
        public override Name createName()
        {
            return new DogName();
        }
        public override Age createAge()
        {
            return new DogAge();
        }
    }
    class CatFactory : AnimalFactory
    {
        public override Name createName()
        {
            return new CatName();
        }
        public override Age createAge()
        {
            return new CatAge();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            AnimalFactory animalFactory = new CatFactory();
            animalFactory.createName().getName();
            animalFactory.createAge().getAge();

            Console.ReadKey();
        }
    }
}
