using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using exercise9._4;



namespace exercise9._5
{
    class Program
    {
        static void Main(string[] args)
        {

            AddPassenger(new Compact());
            AddPassenger(new suv());
            AddPassenger(new pickup());
            AddPassenger(new passengerTrain());
            ReadKey();
        }
        static void AddPassenger(IpassengerCarrier Vehicle)
        { WriteLine(Vehicle.ToString()); }
    }
}
