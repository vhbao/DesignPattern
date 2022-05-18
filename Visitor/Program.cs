using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    interface IVisitor
    {
        void Visit(Element element);
    }
    abstract class Element
    {
        public abstract void Accept(IVisitor visitor);
    }
    class VisitorIncome : IVisitor
    {
        public void Visit(Element element)
        {
            Employee employee = element as Employee;
            Console.WriteLine($"{employee.name} income: {employee.income}");
        }
    }
    class VisitorVacationDays : IVisitor
    {
        public void Visit(Element element)
        {
            Employee employee = element as Employee;
            Console.WriteLine($"{employee.name} vacation days: {employee.vacationDays}");
        }
    }
    class Employee: Element
    {
        public string name { get; private set; }
        public double income { get; private set; }
        public int vacationDays { get; private set; }
        public Employee(string name, double income, int vacationDays)
        {
            this.name = name;
            this.income = income;
            this.vacationDays = vacationDays;
        }
        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
    class Employees
    {
        private List<Employee> employees = new List<Employee>();
        public void AddItem(Employee employee)
        {
            employees.Add(employee);
        }
        public void RemoveItem(Employee employee)
        {
            employees.Remove(employee);
        }
        public void Accept(IVisitor visitor)
        {
            foreach(var employee in employees)
            {
                employee.Accept(visitor);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Employees employees = new Employees();
            employees.AddItem(new Employee("Employee 1", 1.1, 1));
            employees.AddItem(new Employee("Employee 2", 2.2, 2));
            employees.AddItem(new Employee("Employee 3", 3.3, 3));
            employees.Accept(new VisitorIncome());
            employees.Accept(new VisitorVacationDays());
            Console.ReadKey();
        }
    }
}
