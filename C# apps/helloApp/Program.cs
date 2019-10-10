using System;
using System.IO;

namespace helloApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] filePaths = Directory.GetFiles(@"C:\Users\jlars\OneDrive\Documents\Study\newFolder");
            foreach (string file in filePaths)
            {
                /*  Console.WriteLine(file);
                  byte[] test = File.ReadAllBytes(file);
                  Console.WriteLine(test[0]);
                  Console.WriteLine($"First {test[0]:X}");
                  Console.WriteLine($"First {test[1]:X}");

                  string newTest = ($"{test[0]:X}" + $"{test[1]:X}");
                  Console.WriteLine(newTest);
                  if (newTest.Contains("FFD8"))
                  {
                      Console.WriteLine("Success!");
                  }*/
                byte[] byteArray = new byte[4];
                try
                {
                    FileStream streamy = new FileStream(file, FileMode.Open, FileAccess.Read);
                    streamy.Read(byteArray, 0, byteArray.Length);
                    streamy.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                string concBytes = "";
                foreach (byte newByte in byteArray)
                {
                    concBytes += $"{newByte:X}";
                }
                Console.WriteLine(concBytes);
				Console.WriteLine("Hello World");
            }
        }
    }
}
