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

            int count = File.ReadAllLines(@"c:\temp\disposable_task_file.txt").Length;
            string[] st1 = new string[count];
            int[] nums = new int[count];

            using (StreamReader sr = new StreamReader(@"c:\temp\disposable_task_file.txt"))
            {
                for (int i = 0; i < count; i++)
                {
                    st1[i] = sr.ReadLine();
                }
            }

            for (int i = 0; i < count; i++)
            {
                nums[i] = int.Parse(st1[i]);
                nums[i] *= nums[i];
            }

            using (FileStream fs1 = new FileStream(@"c:\temp\disposable_task_file.txt", FileMode.Create, FileAccess.Write)) ;
            using (StreamWriter sw = new StreamWriter(@"c:\temp\disposable_task_file.txt", true))
            {
                for (int i = 0; i < count; i++)
                {
                    sw.WriteLine(nums[i]);
                }

            }

            //--------------------------------------------------------------------------------------------------------------------------
            //Task 2.
            //--------------------------------------------------------------------------------------------------------------------------


            DirectoryInfo di1 = new DirectoryInfo(@"c:\temp\K1");
            di1.Create();

            DirectoryInfo di2 = new DirectoryInfo(@"c:\temp\K2");
            di2.Create();


            if (!File.Exists(@"c:\temp\K1\t1.txt"))
            {
                File.WriteAllText(@"c:\temp\K1\t1.txt", "Иванов Иван Иванович, 2000 года рождения," +
                        " место жительства г.Рязань");
            }

            if (!File.Exists(@"c:\temp\K1\t2.txt"))
            {
                File.WriteAllText(@"c:\temp\K1\t2.txt", "Петров Сергей Федорович, 2002 года рождения," +
                        " место жительства г.Бежицк");
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

            di1.Delete(true);
            di2.MoveTo(@"c:\temp\All");

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

