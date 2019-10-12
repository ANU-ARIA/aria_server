using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string a, b;
            a = "{{#!@,1,1,1,1,2,1,#}}";
            b = a.Substring(4, 1);
            Console.WriteLine(b);
        }
    }
}
