﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Ch12Ex04
{
   public class SuperCow:Cow
    {
        public void Fly()
        {
            WriteLine($"{name} is flying!");

        }
        public SuperCow(string newName) : base(newName)
        {
        }
        public override void MakeNoise()
        {
            WriteLine($"{name} says 'here I come to save the day!';");
        }
    }
}
