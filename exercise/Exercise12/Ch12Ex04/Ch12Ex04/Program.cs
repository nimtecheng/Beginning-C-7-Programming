using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Ch12Ex04
{
    class Program
    {
        static void Main(string[] args)
        {
            Farm<Animal> farm = new Farm<Animal>();
            farm.Animals.Add(new Cow("Rual"));
            farm.Animals.Add(new Chicken("Donna"));
            farm.Animals.Add(new Chicken("Mary"));
            farm.Animals.Add(new SuperCow("Ben"));
            farm.MakeNoises();
            Farm<Cow> diaryFarm = farm.GetCows();
            diaryFarm.FeedTheAnimals();
            foreach (Cow cow in diaryFarm)
            {
                if (cow is SuperCow)
                {
                    (cow as SuperCow).Fly();
                }
            }
            ReadKey();
        }
    }
}
