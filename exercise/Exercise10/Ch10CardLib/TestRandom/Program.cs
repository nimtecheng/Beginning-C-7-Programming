using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace TestRandom
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] testInt = new int[3];
            for (int i = 0; i < 3; i++)
                testInt[i] = i;
            int[] temp = new int[3];
            int[] intReverse = new int[3];
            bool[] testBool = new bool[3];
            bool[] testBoolReverse = new bool[3];
            for (int i = 0; i < 3; i++)
            { testInt[i] = i;testBool[i] = false; testBoolReverse[i] = false; } 
            Random testRandom = new Random();
            for (int j = 0; j < 3; j++)
            {
                int k;
                do
                {
                    k = testRandom.Next(3);
                } while (testBool[k] == true);
                testBool[k] = true;

                temp[j] = testInt[k];

            }
            for (int j = 0; j < 3; j++)
            {
                int k;
                do
                {
                    k = testRandom.Next(3);
                } while (testBoolReverse[k] == true);
                testBoolReverse[k] = true;
                intReverse[j]=temp[k];
                Write(intReverse[j]);

            }
            ReadKey();

        }
    }
}
