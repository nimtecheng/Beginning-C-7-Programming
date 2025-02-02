﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Ch12Ex04
{
    public class Farm<T> : IEnumerable<T> where T : Animal

    {
        
            private List<T> animals = new List<T>();
            public List<T> Animals
            {
                get { return animals; }

            }

            public IEnumerator<T> GetEnumerator() => animals.GetEnumerator();
            IEnumerator IEnumerable.GetEnumerator() => animals.GetEnumerator();
            public void MakeNoises()
            {
                foreach (T animal in animals)
                {
                    animal.MakeNoise();
                }
            }

            public void FeedTheAnimals()
            {
                foreach (T animal in animals)
                {
                    animal.Feed();
                }
            }

            public Farm<Cow> GetCows()
            {
                 Farm<Cow> cowFarm = new Farm<Cow>();
                foreach (T animal in animals)
                {
                    if (animal is Cow)
                    {
                        cowFarm.Animals.Add(animal as Cow);
                    }
                }
                return cowFarm;
            }
            
            

        }

    
}
