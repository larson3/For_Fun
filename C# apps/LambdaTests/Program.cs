using System;
using System.Collections.Generic;

namespace LambdaTests
{
    class Program
    {
        static void Main(string[] args)
        {
            var myList = new List<string>();
            myList.Add("Hello");
            myList.Add("World");
            myList.Add("Test");
            myList.Add("Hello Again");
            myList.ForEach(entry => Console.WriteLine(entry.Contains("Hello")));

        }
    }
}
