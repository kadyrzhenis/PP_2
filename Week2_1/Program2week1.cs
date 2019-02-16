using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;//файлдарды ашу немесе жабу

namespace ConsoleApp11
{
    class Program
    {
        static void Main(string[] args)
        {   //папканы ашу
            string a =System.IO.File.ReadAllText( @"C:\Users\Жанжос\source\repos\ConsoleApp11\Test.txt");
            
            //әріптерді тексеру
            int cnt = 0;
            for (int i = 0; i < a.Length / 2; i++)
            {
                if (a[i] != a[a.Length - i - 1])
                {
                    cnt++;
                }

            }
            if (cnt == 0)
                Console.WriteLine("Yes");
            else
            {
                Console.WriteLine("No");
            }
            Console.ReadKey();//консол жабылмауы үшін
        }

    }
}


