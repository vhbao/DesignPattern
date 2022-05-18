using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    class DbContext
    {
        protected IImplemantaion _implemantaion;
        public DbContext(IImplemantaion implemantaion)
        {
            _implemantaion = implemantaion;
        }
        public virtual void Operation()
        {
            Console.WriteLine("DbContext Operation");
            _implemantaion.OperationImplementation();
        }
    }
    class DomainDbContext: DbContext
    {
        public DomainDbContext(IImplemantaion implemantaion): base(implemantaion)
        {
            
        }
        public override void Operation()
        {
            Console.WriteLine("DomainDbContext Operation " + _implemantaion.GetType().Name);
            _implemantaion.OperationImplementation();
        }
    }
    interface IImplemantaion
    {
        void OperationImplementation();
    }
    class SqlServerImplemantaion: IImplemantaion
    {
        public void OperationImplementation()
        {
            Console.WriteLine("OperationImplementation SqlServer");
        }
    }
    class OracleImplemantaion: IImplemantaion
    {
        public void OperationImplementation()
        {
            Console.WriteLine("OperationImplementation Oracle");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            DomainDbContext domainDbContext = new DomainDbContext(new OracleImplemantaion());
            domainDbContext.Operation();
            Console.ReadLine();
        }
    }
}
