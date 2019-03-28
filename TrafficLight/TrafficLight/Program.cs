using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TrafficLight
{
    class Program
    {
        static Wall wall_1;
        static Wall wall_2;
        static Wall wall_3;
        static int cur = 0;
        static void Main(string[] args)
        {
            wall_1 = new Wall();
            for (int x = 5; x <= 14; ++x)
            {
                for (int y = 5; y <= 20; ++y)
                {
                    Point p = new Point(y, x);
                    wall_1.addPoint(p);
                }
            }
            wall_2 = new Wall();
            for (int x = 18; x <= 27; ++x)
            {
                for (int y = 5; y <= 20; ++y)
                {
                    Point p = new Point(y, x);
                    wall_2.addPoint(p);
                }
            }
            wall_3 = new Wall();
            for (int x = 31; x <= 40; ++x)
            {
                for (int y = 5; y <= 20; ++y)
                {
                    Point p = new Point(y, x);
                    wall_3.addPoint(p);
                }
            }

            Thread thread = new Thread(new ThreadStart(move));
            thread.Start();

            Console.SetWindowSize(25, 45);
            Console.CursorVisible = false;


        }
        public static void move()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                wall_1.draw();
                if (cur >= 1 && cur <= 600)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    wall_1.draw();
                }
                Console.ForegroundColor = ConsoleColor.DarkYellow;

                wall_2.draw();
                if ((cur >= 600 && cur < 700) || (cur > 1000 && cur < 1100))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    wall_2.draw();
                }
                Console.ForegroundColor = ConsoleColor.DarkRed;
                wall_3.draw();
                if (cur >= 700 && cur < 1000)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    wall_3.draw();
                }
                cur = cur + 10;
                if (cur >= 1100)
                {
                    cur = 1;
                }
                Thread.Sleep(1);
            }
        }

    }
}
