using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /// <summary>
    /// студент деген класс ашу
    /// </summary>
    class Student
    {
        private string name; //студент аты
        private int id; //студент ID
        private int year; //студент оқуға түскен жыл

        /// <summary>
        /// аты,аиди номері,тускен жылы
        /// </summary>
        /// <param name="name">Name of the student</param>
        /// <param name="id">ID of the student</param>
        public Student(string name, int id)
        {
            this.name = name;
            this.id = id;
            this.year = 2018;
        }
        /// <summary>
        /// студент туралы ақпараттарды шығару
        /// </summary>
        public void PrintInfo()
        {
            Console.WriteLine("ID: " + id);
            Console.WriteLine("Имя: " + name);
            Console.WriteLine("Год: " + year);
        }
        /// <summary>
        /// Белгілі бір студентті қабылдау жылын ұлғайту әдісі. Егер әдіс дұрыс болса, әдіс OK деп жазады.
        /// </summary>
        public void YearInc()
        {
            year++;
            Console.WriteLine("OK!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Student s = new Student("Zhenis", 110686);
            s.PrintInfo();
            s.YearInc();
            s.PrintInfo();

            Console.ReadKey();
        }
    }
}