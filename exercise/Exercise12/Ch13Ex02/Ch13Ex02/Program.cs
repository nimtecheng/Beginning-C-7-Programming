using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.Console;


namespace Ch13Ex02
{

    class Program
    {
        static void Main(string[] args)
        {
            Connection myconnection = new Connection();
            Display myDisplay = new Display();
            myconnection.MessageArrived += new MessageHandler(myDisplay.DisplayMessage);
            myconnection.Connect();
            ReadKey();
        }
    }
}
