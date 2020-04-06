using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using Ch10CardLib;

namespace Exercise_flush
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck myDeck = new Deck();
            myDeck.Shuffle();
            Random randomPick = new Random();
            int rmPick;
           bool[] picked = new bool[52];
            Card[] tempCard = new Card[5];
            bool isFlush = false;

            
            for (int i=0;i<52;i++)
            {
                picked[i] = false;
            }


            for (int i = 0; i < 17; i++)

            {

                int numberOfEqual = 0;
                do
                {
                    rmPick = randomPick.Next(52);
                }
                while (picked[rmPick] == true);
                picked[rmPick] = true;
                int firstPick = rmPick;
                tempCard[0] = myDeck.GetCard(firstPick);

                for (int j = 0; j < 2; j++)

                {
                    do
                    {
                        rmPick = randomPick.Next(52);
                    }
                    while (picked[rmPick] == true);
                    picked[rmPick] = true;
                    tempCard[j + 1] = myDeck.GetCard(rmPick);
                    if (tempCard[0].suit == tempCard[j + 1].suit)

                        numberOfEqual++;
                }
                for (int k = 0; k < 3; k++)
                { Write(tempCard[k].ToString()); Write("\n"); }

                if (numberOfEqual == 2)
                {
                    isFlush = true;
                    WriteLine("Flush\n");
                    ReadKey();
                }

                
            }

            if (isFlush == false) { WriteLine("No Flush\n"); ReadKey();}
            
            

        }
    }
}
