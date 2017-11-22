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

        public void ListFilter()
        {
            var myCars = new Car().getList();

            // 取第一個
            var NewMyCars = new Car();
            NewMyCars = myCars.First();

        }

        public List<Car> getList()
        {
            var myCars = new List<Car>()
            {
                new Car() {Id = 1, Name="Car1" },
                new Car() {Id = 2, Name="Car2" },
                new Car() {Id = 3, Name="Car3" },
                new Car() {Id = 4, Name="Car4" }
            };

            return myCars;
        }

        public static explicit operator Car(List<Car> v)
        {
            throw new NotImplementedException();
        }
    }
}