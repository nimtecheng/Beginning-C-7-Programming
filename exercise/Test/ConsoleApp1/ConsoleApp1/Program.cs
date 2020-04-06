using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ConsoleApp1
{
    interface Imyinterface { }
    struct Mystruct:Imyinterface
    {
        public int Val;
    }
    class Program
    {
        static void Main(string[] args)
        {
            Mystruct valType1 = new Mystruct();
            valType1.Val = 5;
            Imyinterface refType = valType1;
            valType1.Val = 6;
             Mystruct valType2 = (Mystruct)refType;
               WriteLine($"valType2.Val={valType2.Val}");
           //WriteLine($"refType.Val={refType.Val}");
            ReadKey();
        }
    }
}
