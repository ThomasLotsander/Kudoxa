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
            // 1/1/0001 12:00:00 AM
            int time = 1556488800;
            DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Local);
            var current = dt.AddHours(2).AddSeconds(time);
            dt.ToString("d/M/yyyy:HH:mm:ss");

            Console.WriteLine(dt);
            Console.ReadLine();
            //current.DayOfWeek
            //    current.Month
            //        current.Day
            Console.WriteLine(current);
        }
    }
}
