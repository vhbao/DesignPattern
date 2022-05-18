using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator
{
    class Item
    {
        string name;
        public Item (string name)
        {
            this.name = name;
        }
        public string Name
        {
            get { return name; }
        }
    }
    interface ICollection
    {
        Iterator CreateIterator();
    }
    class Collection:ICollection
    {
        List<Item> items = new List<Item>();
        public Iterator CreateIterator()
        {
            return new Iterator(this);
        }
        public int Count
        {
            get { return items.Count; }
        }
        public Item this[int index]
        {
            get { return items[index]; }
            set { items.Add(value); }
        }
    }
    interface IIterator
    {
        Item First();
        Item Next();
        bool HasNext { get; }
        Item CurrentItem { get; }
    }
    class Iterator: IIterator
    {
        Collection collection;
        int current = 0;
        int step = 1;
        public Iterator(Collection collection)
        {
            this.collection = collection;
        }
        public Item First()
        {
            current = 0;
            return this.collection[current];
        }
        public Item Next()
        {
            current += step;
            if(HasNext)
            {
                return this.collection[current];
            }    
            return null;
        }
        public Item CurrentItem
        {
            get { return collection[current]; }
        }
        public bool HasNext
        {
            get { return current < collection.Count; }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Collection collection = new Collection();
            collection[0] = new Item("Item0");
            collection[1] = new Item("Item1");
            collection[2] = new Item("Item2");

            Iterator iterator = collection.CreateIterator();
            for(iterator.First(); iterator.HasNext; iterator.Next())
            {
                Console.WriteLine(iterator.CurrentItem.Name);
            }    
            Console.ReadLine();
        }
    }
}
