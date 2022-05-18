using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    public abstract class SortStrategy
    {
        public abstract void Sort(List<string> l);
    }
    public class QuickSort: SortStrategy
    {
        public override void Sort(List<string> l)
        {
            Console.WriteLine("QuickSort");
            l.Sort();
        }
    }
    public class ShellSort : SortStrategy
    {
        public override void Sort(List<string> l)
        {
            Console.WriteLine("ShellSort");
            l.Sort();
        }
    }
    public class SortedList
    {
        private List<string> l = new List<string>();

        private SortStrategy sortStrategy;        
        public void SetSortStrategy(SortStrategy sortStrategy)
        {
            this.sortStrategy = sortStrategy;
        }
        public void AddItem(string item)
        {
            l.Add(item);
        }
        public void RemoveItem(string item)
        {
            l.Remove(item);
        }
        public void Sort()
        {
            Console.WriteLine("Sorted");
            sortStrategy.Sort(l);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            SortedList sortedList = new SortedList();
            sortedList.AddItem("item 1");
            sortedList.AddItem("item 2");
            sortedList.SetSortStrategy(new QuickSort());
            sortedList.Sort();
            sortedList.SetSortStrategy(new ShellSort());
            sortedList.Sort();
            Console.ReadKey();
        }
    }
}
