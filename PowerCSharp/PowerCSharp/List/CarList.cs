using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerCSharp
{
    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string Make { get; set; }

        public void test()
        {
            var myCars = new Car().getList();
            var bmws = myCars.Where(p => p.Name == "BMW" && p.Year == 2010);


            // 取得 Name 清單
            var bmwName = from bmw in bmws
                          where bmw.Year == 2010
                          select new { bmw.Name };

            //
            //List<string> cars1 = bmwName.ToList().ConvertAll(x => x.Name.ConvertTo<string>());

        }

        public void Update()
        {
            var myCars = new Car().getList();

            // method 1
            // update Item Name
            myCars.Where(d => d.Id == 1).First().Name = "some value";

            // method 2
            // However, a safer version of that might be this:
            var car = myCars.Where(d => d.Id == 2).FirstOrDefault();
            if (car != null) { car.Name = "some value"; }

            // method 3
            // As Reed stated, we can just go straight to First or even FirstOrDefault here:
            myCars.First(d => d.Id == 2).Name = "some value";
            //or
            var car2 = myCars.FirstOrDefault(d => d.Id == 2);


            // update all items in list
            myCars.Select(c => { c.Make = "Honda"; return c; }).ToList();

        }

        public void ListFilter()
        {
            var myCars = new Car().getList();

            // 取第一個
            var NewMyCars = new Car();
            NewMyCars = myCars.First();

        }

        public void GroupBy()
        {
            var myCars = new Car().getList();

            // Group by 1個欄位
            var myCarsListGroupByYear = myCars.GroupBy(c => c.Year)
                .Select(c => new { 
                    year = c.Key, 
                    yearCount = c.Count() 
                })
                .OrderByDescending(order => order.year)
                .ToList();

            // Group by 2個欄位
            var myCarsListGroupByYear2 = myCars.GroupBy(c => new { c.Year, c.Make })
                .Select(c => new
                {
                    Year = c.Key.Year,
                    make = c.Key.Make,
                    makeCount = c.Count()
                }).OrderBy(order => order.make).ThenByDescending(order => order.Year).ToList();

        }

        public List<Car> getList()
        {
            var myCars = new List<Car>()
            {
                new Car() {Id = 1, Name="Car1", Year = 2010, Make = "BMW" },
                new Car() {Id = 2, Name="Car2", Year = 2010, Make = "BENS" },
                new Car() {Id = 3, Name="Car3", Year = 2013, Make = "TOYOTA" },
                new Car() {Id = 4, Name="Car4", Year = 2016, Make = "TOYOTA" },
                new Car() {Id = 5, Name="Car5", Year = 2016, Make = "TOYOTA" },
                new Car() {Id = 6, Name="Car6", Year = 2016, Make = "BMW" }
            };

            return myCars;
        }

        public static explicit operator Car(List<Car> v)
        {
            throw new NotImplementedException();
        }
    }



    //List<T>.Contains Method (T)
    //https://msdn.microsoft.com/en-us/library/bhkz42b3(v=vs.110).aspx

    // Simple business object. A PartId is used to identify a part 
    // but the part name can change. 
    public class Part : IEquatable<Part>
    {
        public string PartName { get; set; }
        public int PartId { get; set; }

        public override string ToString()
        {
            return "ID: " + PartId + "   Name: " + PartName;
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Part objAsPart = obj as Part;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }
        public override int GetHashCode()
        {
            return PartId;
        }
        public bool Equals(Part other)
        {
            if (other == null) return false;
            return (this.PartId.Equals(other.PartId));
        }
        // Should also override == and != operators.
    }
    public class Example
    {
        public static void Main()
        {
            // Create a list of parts.
            List<Part> parts = new List<Part>();

            // Add parts to the list.
            parts.Add(new Part() { PartName = "crank arm", PartId = 1234 });
            parts.Add(new Part() { PartName = "chain ring", PartId = 1334 });
            parts.Add(new Part() { PartName = "regular seat", PartId = 1434 });
            parts.Add(new Part() { PartName = "banana seat", PartId = 1444 });
            parts.Add(new Part() { PartName = "cassette", PartId = 1534 });
            parts.Add(new Part() { PartName = "shift lever", PartId = 1634 }); ;

            // Write out the parts in the list. This will call the overridden ToString method
            // in the Part class.
            Console.WriteLine();
            foreach (Part aPart in parts)
            {
                Console.WriteLine(aPart);
            }


            // Check the list for part #1734. This calls the IEquatable.Equals method
            // of the Part class, which checks the PartId for equality.
            Console.WriteLine("\nContains: Part with Id=1734: {0}",
                parts.Contains(new Part { PartId = 1734, PartName = "" }));

            // Find items where name contains "seat".
            Console.WriteLine("\nFind: Part where name contains \"seat\": {0}",
                parts.Find(x => x.PartName.Contains("seat")));

            // Check if an item with Id 1444 exists.
            Console.WriteLine("\nExists: Part with Id=1444: {0}",
                parts.Exists(x => x.PartId == 1444));

            /*This code example produces the following output:

            ID: 1234   Name: crank arm
            ID: 1334   Name: chain ring
            ID: 1434   Name: regular seat
            ID: 1444   Name: banana seat
            ID: 1534   Name: cassette
            ID: 1634   Name: shift lever

            Contains: Part with Id=1734: False

            Find: Part where name contains "seat": ID: 1434   Name: regular seat

            Exists: Part with Id=1444: True 
             */
        }
    }
}