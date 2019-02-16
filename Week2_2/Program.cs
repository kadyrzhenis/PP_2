using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.MemoryMappedFiles;
namespace ConsoleApp6
{
    class Program
    {
        static bool IsPrime(int p)
        {
            bool ee = true;
            if (p == 1)
                return false;
            for (int i = 2; i < p; ++i)
            {
                if (p % i == 0)
                {
                    ee = false;
                    return ee;
                }
            }
            return ee;
        }
        static void Main(string[] args)
        {
            // (@"C: \Users\Жанжос\source\repos\ConsoleApp6\zhenis.txt")) ;
            int n;
            string s = System.IO.File.ReadAllText(@"C:\Users\Жанжос\source\repos\ConsoleApp6\zhenis.txt");
            string[] arr = s.Split(' ');
            n = arr.Length;
            int[] array = new int[n];
            int cnt = 0;
            List<int> prime = new List<int>();
            for (int i = 0; i < n; ++i)
            {
                array[i] = int.Parse(arr[i]);
                if (IsPrime(array[i]))
                {

                    prime.Add(array[i]);
                    cnt++;
                }
            }
            for (int i = 0; i < cnt; ++i)
            {
                using (FileStream fs1 = new FileStream(@"C:\Users\Жанжос\source\repos\ConsoleApp6\prime.txt", FileMode.Create, FileAccess.Write)) //создал файл, если сущ то перезаписывается
                {
                    using (StreamWriter sw = new StreamWriter(fs1))   //это не для чтения а для записи
                    {
                        foreach (var x in prime)      //цикл который пишет в файл все числа из праймнам(все простые числа)
                        {
                            sw.Write(x + " ");
                        }
                    }
                }
            }


        }
    }
}
   
  

