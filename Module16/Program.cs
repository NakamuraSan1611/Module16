using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Module16
{
    class Program
    {
        public static int fibonacci(int i)
        {
            if (i == 1 || i == 2)
                return 1;
            else
                return fibonacci(i - 1) + fibonacci(i - 2);
        }
        public static void BinaryWrite()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "text.txt");
            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Create)))
            {
                for (int i = 0; i < 256; i++)
                    writer.Write((char)i);
            }
        }
        public static void BinaryRead()
        {
            Dictionary<int, char> myDic = new Dictionary<int, char>();
            string path = Path.Combine(Directory.GetCurrentDirectory(), "text.txt");
            int i = 0;
            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                myDic.Add(i++,reader.ReadChar());
            }

        }
        static void Main(string[] args)
        {
            List<string> arr = new List<string>();
            try
            {
                using (StreamReader sr = new StreamReader("fibonacci.txt"))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        arr.AddRange(line.Split('\t'));
                    }
                }
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            int count = arr.Count;
            while (count > 0)
            {
                arr.Add(fibonacci(arr.Count).ToString());
                count--;
            }
            int i = 1;
            try
            {
                using (StreamWriter sr = new StreamWriter("fibonacci.txt", true))
                {
                    while (i <= arr.Count / 2)
                        sr.Write("\t" + arr[arr.Count / 2 + i++]);
                }
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            arr.Clear();
            try
            {
                using (StreamReader sr = new StreamReader("INPUT.txt"))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        arr.AddRange(line.Split(' '));
                    }
                }
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            var sum = arr.Select(int.Parse).ToList().Sum();
            try
            {
                using (StreamWriter sr = new StreamWriter("OUTPUT.txt"))
                {
                    sr.WriteLine(sum);
                }
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            BinaryWrite();
            BinaryRead();

        }
    }
}
