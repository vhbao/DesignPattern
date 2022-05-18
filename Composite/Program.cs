using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    abstract class TaskItem
    {
        public string Name { get; set; }
        public double Time { get; set; }

        abstract public void ShowTime();
        public virtual void AddTask(TaskItem taskItem) { }
        public virtual void RemoveTask(TaskItem taskItem) { }
    }
    class Project: TaskItem
    {
        List<TaskItem> subTask = new List<TaskItem>();
        public Project(string _Name)
        {
            Name = _Name;
            Time = 0;
        }
        public override void AddTask(TaskItem taskItem)
        {
            Time += taskItem.Time;
            subTask.Add(taskItem);
        }
        public override void RemoveTask(TaskItem taskItem)
        {
            Time -= taskItem.Time;
            subTask.Remove(taskItem);
        }
        public override void ShowTime()
        {
            Console.WriteLine("Total time for project ("+ Name +"):" + Time);
        }
    }
    class Task : TaskItem
    {
        public Task(string _Name, double _Time)
        {
            Name = _Name;
            Time = _Time;
        }
        public override void ShowTime()
        {
            Console.WriteLine("Total time for task (" + Name + "):" + Time);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Project bigProject = new Project("BigProject");

            Project smallProject1 = new Project("SmallProject1");
            Task taskSmallProject1_1 = new Task("taskSmallProject1_1", 3);
            Task taskSmallProject1_2 = new Task("taskSmallProject1_2", 2);
            smallProject1.AddTask(taskSmallProject1_1);
            smallProject1.AddTask(taskSmallProject1_2);
            smallProject1.RemoveTask(taskSmallProject1_2);

            Project smallProject2 = new Project("SmallProject2");
            Task taskSmallProject2_1 = new Task("taskSmallProject2_1", 3);
            smallProject2.AddTask(taskSmallProject2_1);

            bigProject.AddTask(smallProject1);
            bigProject.AddTask(smallProject2);

            smallProject1.ShowTime();
            smallProject2.ShowTime();
            bigProject.ShowTime();
            Console.ReadKey();
        }
    }
}
