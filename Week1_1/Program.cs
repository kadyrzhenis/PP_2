using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{/// <summary>
/// ЖАЙ САН ТАУАТЫН ФУНКЦИЯ  
/// </summary>
    class Program
    {
        static bool IsPrime(int q)
        {
            bool ee = true;
            if (q == 1)
                return false;
            for(int i = 2; i < q; i++)
            {
                if (q % i == 0)
                {
                    ee = false;
                    return ee;
                }
       
            }
            return ee;
        }
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());//САН ЕНГІЗУ
            string s= Console.ReadLine();//САНДАРДАН ҚҰРАЛҒАН СӨЗ ЕНГІЗУ
            string[] arr = s.Split(' ');//ТІРКЕСТІ ПРОБЕЛ АРҚЫЛЫ ОҚУ
            int[] array = new int[a];//ЖИЫМ ЕНГІЗУ
            int qwe = 0;
            List<int> prime = new List<int>();//ШЕКСІЗ САНДАР ҰЯШЫҒЫ
            for (int i = 0; i < a; i++)
            {
                array[i] = int.Parse(arr[i]);
                if (IsPrime(array[i]))// ЖАЙ САНДАРДЫ ҰЯШЫҚҚА ОРНАЛАСТЫРУ
                {
                    prime.Add(array[i]);
                    qwe++;//ЖАЙ САНДАРДЫҢ САНЫ
                }
            }
            Console.WriteLine(qwe);
            for(int i = 0; i < qwe; i++)
            {
                Console.Write(prime[i] + " ");//ЖАЙ САНДАРДЫ ШЫҒАРУ
            }
            Console.ReadKey();
        }
    }
}
