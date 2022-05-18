using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    abstract class aGirl
    {
        public List<aBoy> FriendZone = new List<aBoy>();
        public void AddZone(aBoy boy)
        {
            FriendZone.Add(boy);
        }
        public void RemoveZone(aBoy boy)
        {
            FriendZone.Add(boy);
        }
        public void PostFacebook()
        {
            foreach(var boy in FriendZone)
            {
                boy.Care();
            }    
        }
    }
    class Girl: aGirl
    {
        public string Name { get; set; }
    }
    abstract class aBoy
    {
        public abstract void Care();
    }
    class Boy: aBoy
    {
        private Girl girl;
        private string Name { get; set; }
        public Boy(Girl girl, string Name)
        {
            this.girl = girl;
            this.Name = Name;
        }
        public override void Care()
        {
            Console.WriteLine($"{Name}: Are you OK?");
            Console.WriteLine($"{this.girl.Name}: No :)))");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Girl girl = new Girl();
            girl.AddZone(new Boy(girl, "Boy1"));
            girl.AddZone(new Boy(girl, "Boy2"));
            girl.AddZone(new Boy(girl, "Boy3"));
            girl.Name = "Girl1";
            girl.PostFacebook();
            Console.ReadLine();
        }
    }
}
