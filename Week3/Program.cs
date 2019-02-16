using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace FarManager
{
    class Layer
    {
        public FileSystemInfo[] content
        {
            get;
            set;
        }
        int selectedItem;
        public int SelectedItem
        {
            get
            {
                return SelectedItem1;
            }
            set
            {
                if (value < 0)
                {
                    SelectedItem1 = content.Length - 1;
                }
                else if (value >= content.Length)
                {
                    SelectedItem1 = 0;
                }
                else
                {
                    SelectedItem1 = value;
                }
            }
        }

        public int SelectedItem1 { get => selectedItem; set => selectedItem = value; }

        public void DrawFile(FileInfo a)
        {
            Console.BackgroundColor = ConsoleColor.DarkCyan;
        }

        public void Draw()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            for (int i = 0; i < content.Length; i++)
            {
                if (content[i].GetType() == typeof(DirectoryInfo))
                {
                    if (i == SelectedItem1)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    if (i == SelectedItem1)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                }
                Console.WriteLine(content[i].Name);
            }
        }
    }

    enum Farmode
    {
        FileView,
        DirectoryView
    }
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo root = new DirectoryInfo(@"C:\Users\Жанжос\OneDrive\Документы");
            Stack<Layer> history = new Stack<Layer>();
            history.Push(new Layer { content = root.GetFileSystemInfos(), SelectedItem = 0 });
            Farmode farmode = Farmode.DirectoryView;
            while (true)
            {
                if (farmode == Farmode.DirectoryView)
                {
                    history.Peek().Draw();
                }
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
                switch (consoleKeyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        history.Peek().SelectedItem--;
                        break;
                    case ConsoleKey.DownArrow:
                        history.Peek().SelectedItem++;
                        break;
                    case ConsoleKey.Backspace:
                        if (farmode == Farmode.DirectoryView)
                        {
                            history.Pop();
                        }
                        else if (farmode == Farmode.FileView)
                        {
                            farmode = Farmode.DirectoryView;
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        break;
                    case ConsoleKey.Enter:
                        int x = history.Peek().SelectedItem;
                        FileSystemInfo fileSystemInfo = history.Peek().content[x];
                        if (fileSystemInfo.GetType() == typeof(DirectoryInfo))
                        {
                            DirectoryInfo d = fileSystemInfo as DirectoryInfo;
                            history.Push(new Layer { content = d.GetFileSystemInfos(), SelectedItem = 0 });
                        }
                        else
                        {
                            farmode = Farmode.FileView;
                            using (FileStream fs = new FileStream(fileSystemInfo.FullName, FileMode.Open, FileAccess.Read))
                            {
                                using (StreamReader sr = new StreamReader(fs))
                                {
                                    Console.BackgroundColor = ConsoleColor.White;
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.Clear();
                                    Console.WriteLine(sr.ReadToEnd());
                                }
                            }
                        }
                        break;
                    case ConsoleKey.Delete:
                        int y = history.Peek().SelectedItem;
                        FileSystemInfo fileSystemInfo2 = history.Peek().content[y];
                        if (fileSystemInfo2.GetType() == typeof(DirectoryInfo))
                        {
                            DirectoryInfo d = fileSystemInfo2 as DirectoryInfo;
                            Directory.Delete(fileSystemInfo2.FullName, true);
                            history.Peek().content = d.Parent.GetFileSystemInfos();
                        }
                        else
                        {
                            FileInfo f = fileSystemInfo2 as FileInfo;
                            File.Delete(fileSystemInfo2.FullName);
                            history.Peek().content = f.Directory.GetFileSystemInfos();
                        }
                        history.Peek().SelectedItem--;
                        break;
                    case ConsoleKey.F:
                        int z = history.Peek().SelectedItem;
                        FileSystemInfo fileSystemInfo3 = history.Peek().content[z];
                        string fullname = fileSystemInfo3.FullName;
                        string name = fileSystemInfo3.Name;
                        string path = fullname.Remove(fullname.Length - name.Length);
                        Console.WriteLine("Please enter the new name ,to rename {0}", name);
                        string newname = Console.ReadLine();
                        if (farmode == Farmode.DirectoryView)
                            new DirectoryInfo(fullname).MoveTo(path + newname);
                        else
                            new FileInfo(fullname).MoveTo(path + newname);
                        DirectoryInfo di = new DirectoryInfo(path);
                        fileSystemInfo3 = di as FileSystemInfo;
                        break;
                }
            }
        }
    }
}