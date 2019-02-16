using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TASK_4
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Жанжос\source\repos\info.txt"; //info.txt файл аштым осылай
            FileStream FS = new FileStream(path, FileMode.Create, FileAccess.Write);
            StreamWriter SW = new StreamWriter(FS);
            SW.Write("Zhenis"); //файлды ашып ішіне жазу 
            SW.Close();
            FS.Close();// файлды жабу 
            string path1 = @"C:\Users\Жанжос\source\repos\Week3\info.txt";//файлды осында өткізу
            File.Copy(path, path1, true);//копя жасау
            File.Delete(path);//бірінші файлды өшіру
        }
    }
}
