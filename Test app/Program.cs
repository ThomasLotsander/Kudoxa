using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Test_app
{
    class Program
    {
        static void Main(string[] args)
        {

            int time = 1556488800;
            DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Local);
            var current = dt.AddHours(2).AddSeconds(time);
            //current.DayOfWeek
            //    current.Month
            //        current.Day
            Console.WriteLine(current);
        }
    }
}
