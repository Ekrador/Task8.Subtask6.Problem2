using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8.Subtask6.Problem2
{

    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Введите путь к папке для подсчета размера.");
            string path = Console.ReadLine();
            if (Directory.Exists(path))
            {
                DirectoryInfo dirInfo = new DirectoryInfo(path);
                long size = Getsize(dirInfo);
            }
            else Console.WriteLine("Папка по данному пути не найдена.");
            Console.ReadLine();
        }

        private static long Getsize(DirectoryInfo dirInfo)
        {
            long size = 0;
            FileInfo[] files = dirInfo.GetFiles();
            try
            {
                foreach (FileInfo file in files)
                {
                    size += file.Length;
                }
                DirectoryInfo[] dirs = dirInfo.GetDirectories();
                foreach (DirectoryInfo dir in dirs)
                {
                    size += Getsize(dir);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return size;
        }
    }
}

