using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    class Animal
    {
        public string Name { get; set; }
        public int Age { get; set; }                
    }
    abstract class AnimalBuilder
    {
        protected Animal animal { get; set; }
        public abstract void SetName(string Name);
        public abstract void SetAge(int Age);
        public abstract Animal ToObject();

    }
    class DogBuilder : AnimalBuilder
    {
        public DogBuilder()
        {
            animal = new Animal();
        }
        public override void SetName(string Name)
        {
            animal.Name = Name;
        }
        public override void SetAge(int Age)
        {
            animal.Age = Age;
        }
        public override Animal ToObject()
        {
            return animal;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {            
            DogBuilder dog1Builder = new DogBuilder();
            dog1Builder.SetName("dog1");
            dog1Builder.SetAge(1);
            Console.WriteLine(dog1Builder.ToObject().Name + "-" + dog1Builder.ToObject().Age);

            DogBuilder dog2Builder = new DogBuilder();
            dog2Builder.SetName("dog2");
            dog2Builder.SetAge(2);
            Console.WriteLine(dog2Builder.ToObject().Name + "-" + dog2Builder.ToObject().Age);
            Console.ReadKey();
        }
    }
}
