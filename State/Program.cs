using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    class Red: Color
    {
        public override void SetColor(Brush brush)
        {
            Console.WriteLine("Draw Red");
            brush.color = new Blue();
        }
    }
    class Blue: Color
    {
        public override void SetColor(Brush brush)
        {
            Console.WriteLine("Draw Blue");
            brush.color = new Red();
        }
    }
    abstract class Color
    {
        public abstract void SetColor(Brush brush);
    }        
    class Brush
    {
        public Color color { get; set; }        
        public Brush(Color color)
        {
            this.color = color;
        }
        public void Draw()
        {
            color.SetColor(this);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Brush brush = new Brush(new Red());
            brush.Draw();
            brush.Draw();
            Console.ReadKey();
        }
    }
}
