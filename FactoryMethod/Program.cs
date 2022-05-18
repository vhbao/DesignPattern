using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    class Dog:Animal
    {
        public override void Interact()
        {
            Console.WriteLine("Dog Interact!");
        }
    }
    class Cat : Animal
    {
        public override void Interact()
        {
            Console.WriteLine("Cat Interact!");
        }
    }
    abstract class Animal
    {
        public abstract void Interact(); 
        public enum Type { Dog, Cat }
        public static Animal AnimalFactory(Type typeAnimal)//Factory Method
        {
            switch(typeAnimal)
            {
                case Type.Dog:
                    return new Dog();
                case Type.Cat:
                    return new Cat();                
            }
            throw new Exception("The animal type " + typeAnimal.ToString() + " is not recognized.");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Animal.AnimalFactory(Animal.Type.Dog).Interact();

            Animal.AnimalFactory(Animal.Type.Cat).Interact();

            Console.ReadKey();
        }
    }
}
