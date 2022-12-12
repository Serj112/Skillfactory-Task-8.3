using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.IO;
using Skillfactory_Task_8._3;
using System.Runtime;

class Program
{
    static void WriteFolderInfo(DirectoryInfo folder)
    {
        try
        {
            Console.WriteLine(folder.Name + $"- {DirectoryExtension.DirSize(folder)} байт");
        }

        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    }
    static void Main(string[] args)
    {
        try
        {
            string path = @"C:\\Skillfactory\1\";

            DirectoryInfo dirinfo = new DirectoryInfo(path);
            Console.WriteLine("Исходный размер папки");
            WriteFolderInfo(dirinfo);
            var a = DirectoryExtension.DirSize(dirinfo);

            if (dirinfo.Exists)
            {
                TimeSpan interval = TimeSpan.FromSeconds(10);

                if (DateTime.Now - dirinfo.LastWriteTime > interval)
                {
                    foreach (var d in dirinfo.GetDirectories()) d.Delete(true);
                    foreach (var f in dirinfo.GetFiles()) f.Delete();
                    //dirinfo.Delete(true);
                    Console.WriteLine("Каталог удален");
                }

                else
                {
                    Console.WriteLine("Не прошло достаточно времени для удаления каталога");
                }

            }

            DirectoryInfo dirinfo1 = new DirectoryInfo(path);
            
            var b = DirectoryExtension.DirSize(dirinfo1);
            var c = a - b;
            Console.WriteLine($@"Освобождено: {c} байт");

            Console.WriteLine("Текущий размер папки");
            WriteFolderInfo(dirinfo1);

        }

        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}