using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TravelingSalesmanProblem
{
    public class PointKeeper
    {      
        public static List<Point> GetTestPreset()
        {
            return new List<Point>()
            {
                new Point(259, 77),
                new Point(200, -100),
                new Point(89, -201),
                new Point(0, 143),
                new Point(129, - 129),
                new Point(56, 56),
                new Point(-49, - 134),
                new Point(-12, 45)
            };
        }

        public static List<Point> GetRandomPoints()
        {
            var result = new List<Point>();
            Random rnd = new Random();
            for (int i = 0; i < 9; i++)
            {
                result.Add(new Point(rnd.Next(-270, 270), rnd.Next(-230, 230)));
            }
            return result;
        }
    }
}
