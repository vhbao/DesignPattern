using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    class Singleton
    {
        private static Singleton _instance;
        public static Singleton GetInstance()
        {
            if(_instance == null)
            {
                _instance = new Singleton();
            }
            return _instance;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Singleton singleton1 = Singleton.GetInstance();
            Singleton singleton2 = Singleton.GetInstance();      
            
            if(singleton1 == singleton2)
            {
                Console.WriteLine("Singleton workes ");
            }
            else
            {
                Console.WriteLine("Singleton failed ");
            }
            Console.WriteLine("singleton1:" + singleton1);
            Console.WriteLine("singleton2:" + singleton2);
            Console.ReadLine();
        }
    }
}
