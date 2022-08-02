using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sandbox
{
    public delegate void myDlgt(string str);
    internal class Program
    {
        static void Main(string[] args)
        {
            SayHelloTo("bb");
            var kuni = new myDlgt(SayHelloTo);
            kuni("sara");

        }
        static void SayHelloTo(string name)
        {
            Console.WriteLine($"hello {name}");
        }
    }
}