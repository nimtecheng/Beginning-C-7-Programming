using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.Console;


namespace Ch13Ex03
{

    class Program
    {
        static void Main(string[] args)
        {
            Connection myconnection1 = new Connection();
            myconnection1.Name = "First connection.";
            Connection myConnection2 = new Connection();
            myConnection2.Name = "Second Connection.";
            Display myDisplay = new Display();
            myconnection1.MessageArrived += myDisplay.DisplayMessage;
            myConnection2.MessageArrived += myDisplay.DisplayMessage;
            myconnection1.Connect();
            myConnection2.Connect();
            System.Threading.Thread.Sleep(200);
            ReadKey();
            
        }
    }
}
