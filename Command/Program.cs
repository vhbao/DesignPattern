using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    abstract class Command
    {
        protected Receiver _receiver;
        public Command(Receiver receiver)
        {
            _receiver = receiver;
        }
        public abstract void Execute();
    }
    class Receiver
    {
        public void Action()
        {
            Console.WriteLine("Run Action !");
        }
    }
    class ConcreteCommand : Command
    {
        public ConcreteCommand(Receiver receiver):base(receiver)
        {

        }
        public override void Execute()
        {
            _receiver.Action();
        }
    }
    class Invoker
    {
        Command _command;
        public Invoker()
        {            
        }
        public void SetCommand(Command command)
        {
            _command = command;
        }
        public void ExecuteCommand()
        {
            _command.Execute();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Invoker invoker = new Invoker();
            Receiver receiver = new Receiver();
            ConcreteCommand concreteCommand = new ConcreteCommand(receiver);
            invoker.SetCommand(concreteCommand);
            invoker.ExecuteCommand();
            Console.ReadKey();
        }
    }
}
