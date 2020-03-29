using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Ch11Ex02
{
    public class Animals:CollectionBase
    {
        public void Add(Animal newAnimal) => List.Add(newAnimal);
        public void Remove(Animal oldAnimal) => List.Remove(oldAnimal);

        public Animal this[int animalIndex]
        {
            get { return (Animal)List[animalIndex]; }
            set { List[animalIndex] = value; }
        }
    }
}
