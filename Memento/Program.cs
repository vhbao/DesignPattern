using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento
{
    class Memento
    {
        private Stack<string> stateStack = new Stack<string>();
        public void addNewState(string state)
        {
            stateStack.Push(state);
        }
        public string takeLastState()
        {
            return stateStack.Count == 0 ? "" : stateStack.Pop();
        }
    }
    class TextEditor
    {
        private Memento memento = new Memento();
        private StringBuilder text = new StringBuilder();

        public void Start()
        {
            Console.WriteLine("Please enter your text: ");
            while (true)
            {
                string line;
                try
                {
                    line = Console.ReadLine();                    
                }
                catch (Exception e)
                {
                    continue;
                }
                if (line.Equals("r"))
                {
                    restore();
                }
                else if (line.Equals("c"))
                {
                    close();
                    break;
                }
                else
                {
                    save(line);
                }
            }
        }
        public void restore()
        {
            text.Remove(0, text.Length);
            text.Append(memento.takeLastState());
        }
        public void save(string line)
        {
            memento.addNewState(text.ToString());
            if(text.Length > 0)
            {
                text.Append(" ");
            }
            text.Append(line);
        }
        public void close()
        {
            Console.WriteLine("finished, your text is: " + text);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            TextEditor textEditor = new TextEditor();
            textEditor.Start();
            Console.ReadLine();
        }
    }
}
