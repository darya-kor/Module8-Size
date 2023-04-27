using System;
using System.Drawing;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace DirectoryManager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                DirectoryInfo dirSize = new DirectoryInfo(@"C:\Users\balak\dev\Module8-TimeSpan");
                Console.WriteLine($"Размер папки {dirSize.Name} - {DirectoryExtension.CountDirSize(dirSize)}");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Не удалось посчитать размер {ex.Message}");
            }

        }
    }
    public static class DirectoryExtension
    {
        public static long CountDirSize(DirectoryInfo dirSize)
        {
            if (dirSize.Exists)
            {
                long size = 0;

                FileInfo[] files = dirSize.GetFiles();
                foreach (FileInfo file in files)
                {
                    size += file.Length;
                }

                DirectoryInfo[] dirs = dirSize.GetDirectories();
                foreach (DirectoryInfo dir in dirs)
                {
                    size += CountDirSize(dir);
                }

                return size;

            }
            else
            {
                Console.WriteLine("Такой папки не существует");
                return 0;
            }
        }
    }
}