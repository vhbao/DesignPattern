using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod
{
    abstract class DataAccessor
    {
        public abstract void Connect();
        public abstract void Select();
        public abstract void Process();
        public abstract void Disconnect();
        public void Run()
        {
            Connect();
            Select();
            Process();
            Disconnect();
        }
    }
    class Categories:DataAccessor
    {
        List<string> lstCategories;
        public override void Connect()
        {
            lstCategories = new List<string>();
        }
        public override void Select()
        {
            lstCategories.Add("Categories 1");
            lstCategories.Add("Categories 2");
            lstCategories.Add("Categories 3");
        }
        public override void Process()
        {
            Console.WriteLine("Categories:");
            foreach(var item in lstCategories)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }
        public override void Disconnect()
        {
            lstCategories.Clear();
        }
    }
    class Products:DataAccessor
    {
        List<string> lstProducts;
        public override void Connect()
        {
            lstProducts = new List<string>();
        }
        public override void Select()
        {
            lstProducts.Add("Products 1");
            lstProducts.Add("Products 2");
            lstProducts.Add("Products 3");
        }
        public override void Process()
        {
            Console.WriteLine("Products:");
            foreach (var item in lstProducts)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }
        public override void Disconnect()
        {
            lstProducts.Clear();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            DataAccessor dataAccessorCategories = new Categories();
            dataAccessorCategories.Run();
            DataAccessor dataAccessorProducts = new Products();
            dataAccessorProducts.Run();
            Console.ReadLine();
        }
    }
}
