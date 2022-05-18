using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    interface IMediator
    {
        void Notify(object sender, string ev);
    }
    class ConcreteNotify: IMediator
    {
        private Component1 _component1;
        private Component2 _component2;
        public ConcreteNotify(Component1 component1, Component2 component2)
        {
            _component1 = component1;
            _component1.SetMediator(this);
            _component2 = component2;
            _component2.SetMediator(this);
        }
        public void Notify(object sender, string ev)
        {
            if(ev == "A")
            {                
                _component1.DoB();                
                _component2.DoD();
            }
            if (ev == "C")
            {                
                _component1.DoB();
                _component2.DoD();
            }
        }
    }
    class BaseComponent
    {
        protected IMediator _mediator;
        public BaseComponent(IMediator mediator = null)
        {
            _mediator = mediator;
        }
        public void SetMediator(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
    class Component1: BaseComponent
    {
        public void DoA()
        {
            Console.WriteLine("Component 1 does A.");
            _mediator.Notify(this, "A");
        }
        public void DoB()
        {
            Console.WriteLine("Component 1 does B.");
            _mediator.Notify(this, "B");
        }
    }
    class Component2: BaseComponent
    {
        public void DoC()
        {
            Console.WriteLine("Component 2 does C.");
            _mediator.Notify(this, "C");
        }
        public void DoD()
        {
            Console.WriteLine("Component 2 does D.");
            _mediator.Notify(this, "D");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Component1 component1 = new Component1();
            Component2 component2 = new Component2();
            new ConcreteNotify(component1, component2);
            Console.WriteLine("- Run 1"); 
            component1.DoA();
            Console.WriteLine("- Run 2");
            component2.DoC();
            Console.ReadKey();
        }
    }
}
