using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyweight
{
    class NumberFactory
    {
        private Dictionary<char, string> dicNumbers = new Dictionary<char, string>();
        public NumberFactory(string numbers)
        {
            Number number = null;
            string result = string.Empty;
            foreach(var num in numbers)
            {        
                if(dicNumbers.ContainsKey(num))
                {
                    result += dicNumbers[num];
                }   
                else
                {
                    switch (num)
                    {
                        case '1': number = new One(); break;
                        case '2': number = new Two(); break;
                        case '3': number = new Three(); break;
                    }
                    dicNumbers.Add(num, number.Name);
                    result += number.Name;
                }      
            }
            Console.WriteLine(result);
        }
    }
    abstract class Number
    {
        public string Name { get; set; }        
    }
    class One:Number
    {
        public One()
        {
            Name = "Mot";
        }
    }
    class Two : Number
    {
        public Two()
        {
            Name = "Hai";
        }
    }
    class Three : Number
    {
        public Three()
        {
            Name = "Ba";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            NumberFactory numberFactory = new NumberFactory("1213");
            Console.ReadKey();
        }
    }
}
