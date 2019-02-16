using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Week_3
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Users\Жанжос\OneDrive\Документы"); //инфо папка
            PrintInfo(dir, 0); //функция файлдар мен папкаларды катармен шыгару
        }

        static void PrintInfo(FileSystemInfo fsi, int k)
        {
            string s = new string(' ', k);   //стринг  пробел аркылы жазады
            Console.WriteLine(s + fsi.Name);

            if (fsi.GetType() == typeof(DirectoryInfo))
            {
                FileSystemInfo[] arr = ((DirectoryInfo)fsi).GetFileSystemInfos();
                for (int i = 0; i < arr.Length; ++i)
                {
                    PrintInfo(arr[i], k + 7);  //Бұл әдіс өзін басқа параметрлермен шақырады
                }
            }
        }
    }
}
