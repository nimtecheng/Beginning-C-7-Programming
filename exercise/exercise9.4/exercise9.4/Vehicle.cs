using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise9._4
{
    public abstract class Vehicle
    {
        //top base class
    }
    public abstract class Car : Vehicle { }
    public abstract class Train : Vehicle{}
    public interface IpassengerCarrier { }
    internal interface Iheavyloadcarrier { }
    public class Compact : Car,IpassengerCarrier { }
    public class suv : Car ,IpassengerCarrier{ }
    public class pickup : Car,IpassengerCarrier,Iheavyloadcarrier { }
    public class passengerTrain : Train,IpassengerCarrier { }
    public class FreightTrain : Train ,Iheavyloadcarrier{ }
    public class _424DoubleBogey : Train { }

}
