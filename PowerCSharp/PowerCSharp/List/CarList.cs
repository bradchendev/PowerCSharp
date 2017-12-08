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
}