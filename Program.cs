using System;
using System.IO;

namespace FileSystem
{
    class Program
    {

        static void Main(string[] args)
        {

            //--------------------------------------------------------------------------------------------------------------------------
            //Task1.   Фаил должен быть размещён в папке c:\temp
            //--------------------------------------------------------------------------------------------------------------------------

            string[] st1 = new string[100];
            int[] nums = new int[100];

            using (FileStream fs1 = new FileStream(@"c:\temp\disposable_task_file.txt", FileMode.Open, FileAccess.Read)) ;
            using (StreamReader sr = new StreamReader(@"c:\temp\disposable_task_file.txt"))
            {
                for (int i = 0; i < 100; i++)
                {
                    st1[i] = sr.ReadLine();
                }
                sr.Close();
            }

            for (int i = 0; i < 100; i++)
            {
                nums[i] = int.Parse(st1[i]);
                nums[i] *= nums[i];
            }

            using (FileStream fs2 = new FileStream(@"c:\temp\disposable_task_file.txt", FileMode.Create, FileAccess.Write)) ;
            using (StreamWriter sw = new StreamWriter(@"c:\temp\disposable_task_file.txt", true))
            {
                for (int i = 0; i < 100; i++)
                {
                    sw.WriteLine(nums[i]);
                }
                sw.Close();
            }

            //--------------------------------------------------------------------------------------------------------------------------
            //Task 2.
            //--------------------------------------------------------------------------------------------------------------------------

            if (!Directory.Exists(@"c:\temp\K1"))
            {
                DirectoryInfo di = new DirectoryInfo(@"c:\temp\K1");
                di.Create();
            }

            if (!Directory.Exists(@"c:\temp\K2"))
            {
                DirectoryInfo di = new DirectoryInfo(@"c:\temp\K2");
                di.Create();
            }

            if (!File.Exists(@"c:\temp\K1\t1.txt"))
            {
                var fi = new FileInfo(@"c:\temp\K1\t1.txt");
                using (StreamWriter sw = fi.CreateText())
                {
                    sw.WriteLine("Иванов Иван Иванович, 2000 года рождения," +
                        " место жительства г.Рязань");
                }
            }

            if (!File.Exists(@"c:\temp\K1\t2.txt"))
            {
                var fi = new FileInfo(@"c:\temp\K1\t2.txt");
                using (StreamWriter sw = fi.CreateText())
                {
                    sw.WriteLine("Петров Сергей Федорович, 2002 года рождения," +
                        " место жительства г.Бежицк");
                }
            }

            if (!File.Exists(@"c:\temp\K2\t3.txt"))
            {
                var fi = new FileInfo(@"c:\temp\K2\t3.txt");
            }

            CopyText(@"c:\temp\K1\t1.txt", @"c:\temp\K2\t3.txt");
            CopyText(@"c:\temp\K1\t2.txt", @"c:\temp\K2\t3.txt");
            FileInfo(@"c:\temp\K1\t1.txt");
            FileInfo(@"c:\temp\K1\t2.txt");
            FileInfo(@"c:\temp\K2\t3.txt");

            var fi1 = new FileInfo(@"c:\temp\K1\t1.txt");
            fi1.MoveTo(@"c:\temp\K2\t1.txt");

            var fi2 = new FileInfo(@"c:\temp\K1\t2.txt");
            fi2.CopyTo(@"c:\temp\K2\t2.txt");

            DirectoryInfo di1 = new DirectoryInfo(@"c:\temp\K1");
            di1.Delete(true);

            DirectoryInfo di2 = new DirectoryInfo(@"c:\temp\K2");
            di2.MoveTo(@"c:\temp\All");

            DirectoryInfo di3 = new DirectoryInfo(@"c:\temp\All");
            string[] st2 = Directory.GetFiles(@"c:\temp\All");
            foreach (string st in st2)
            {
                Console.WriteLine(st);
                FileInfo(st);
            }

        }

        public static void CopyText(string path1, string path2)
        {
            string line;
            using (StreamReader sr = new StreamReader(path1))
            {
                line = sr.ReadLine();
                sr.Close();
            }
            using (StreamWriter sw = new StreamWriter(path2, true))
            {
                sw.WriteLine(line);
                sw.Close();
            }
        }

        public static void FileInfo(string path)
        {
            var fi = new FileInfo(path);
            Console.WriteLine($"Фаил {fi.Name} имеет размер {fi.Length}" +
                $" и находится в {fi.DirectoryName} ");
        }

    }
}
