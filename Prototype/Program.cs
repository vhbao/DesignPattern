using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    class DogID
    {
        public long Id { get; set; }
    }
    class DogForShallowCopy: ICloneable
    {
        public DogID Id { get; set; }
        public string Name { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }

    }
    class CatID: ICloneable
    {
        public long Id { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
    class CatForDeepCopy: ICloneable
    {
        public CatID Id { get; set; }
        public string Name { get; set; }
        public object Clone()
        {
            CatForDeepCopy objDeepCopy = (CatForDeepCopy)this.MemberwiseClone();
            objDeepCopy.Id = (CatID)this.Id.Clone();
            return objDeepCopy;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("+++Shallow+++");
            DogForShallowCopy objDog = new DogForShallowCopy() { Id = new DogID() { Id = 1 }, Name = "Chó" };
            Console.WriteLine("---Original Copy---");
            Console.WriteLine(objDog.Id.Id + "-" + objDog.Name);
            Console.WriteLine("---Shallow Copy---");
            DogForShallowCopy clonedObjDog = (DogForShallowCopy)objDog.Clone();
            Console.WriteLine(clonedObjDog.Id.Id + "-" + clonedObjDog.Name);
            Console.WriteLine("---Set Shallow Copy---");
            clonedObjDog.Id.Id = 11;
            clonedObjDog.Name = "Chó1";
            Console.WriteLine(clonedObjDog.Id.Id + "-" + clonedObjDog.Name);
            Console.WriteLine("---Original Copy---");
            Console.WriteLine(objDog.Id.Id + "-" + objDog.Name);
            Console.WriteLine("");
            Console.WriteLine("+++Deep+++");
            CatForDeepCopy objCat = new CatForDeepCopy() { Id = new CatID() { Id = 1 }, Name = "Mèo" };
            Console.WriteLine("---Original Copy---");
            Console.WriteLine(objCat.Id.Id + "-" + objCat.Name);
            Console.WriteLine("---Shallow Copy---");
            CatForDeepCopy clonedObjCat = (CatForDeepCopy)objCat.Clone();
            Console.WriteLine(clonedObjCat.Id.Id + "-" + clonedObjCat.Name);
            Console.WriteLine("---Set Shallow Copy---");
            clonedObjCat.Id.Id = 11;
            clonedObjCat.Name = "Mèo1";
            Console.WriteLine(clonedObjCat.Id.Id + "-" + clonedObjCat.Name);
            Console.WriteLine("---Original Copy---");
            Console.WriteLine(objCat.Id.Id + "-" + objCat.Name);

            Console.ReadLine();
        }
    }
}
