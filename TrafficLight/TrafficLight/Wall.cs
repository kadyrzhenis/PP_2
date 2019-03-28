using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLight
{
   public class Wall
    {
        List<Point> points;
        public Wall()
        {
            points = new List<Point>();
        }
        public void addPoint(Point p)
        {
            points.Add(p);
        }
        public void draw()
        {
            foreach (Point p in points)
            {

                Console.SetCursorPosition(p.x, p.y);
                Console.Write('O');
            }
        }
    }
}
