﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            string[] s = Console.ReadLine().Split();
            int[] array = new int[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = int.Parse(s[i]);
            }

            int[] b = Repeat(array);
            for (int i = 0; i < b.Length; i++)
            {
                Console.Write(b[i] + " ");
            }
            Console.ReadKey();

            
        }
        public static int[] Repeat(int[] a)
        {
            int[] b = new int[a.Length * 2];
            for (int i = 0; i < a.Length; i++)
            {
                b[2 * i] = a[i];
                b[2 * i + 1] = a[i];
            }

            return b;

        }
    } 
        
    
}
