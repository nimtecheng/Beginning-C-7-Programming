using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
namespace Ch13CardLib
{
    public class Deck:ICloneable
    {
        private Cards cards=new Cards();
        public event EventHandler LastCardDrawn;

        public object Clone()
        {
            Deck newDeck = new Deck(cards.Clone() as Cards);
            return newDeck;
        }
        private Deck(Cards newCards) => cards = newCards;
        public Deck()
        {
           
            for (int rankVal = 1; rankVal < 14; rankVal++)
            {
                for(int suitVal = 0; suitVal < 4; suitVal++)
                {
                    cards.Add(new Card((Suit)suitVal, (Rank)rankVal));
                    ///cards[suitVal+ (rankVal-1) *4] = new Card((Suit)suitVal, (Rank)rankVal);
                }
            }
        }

        public Card GetCard(int cardNum)
        {
            if (cardNum >= 0 && cardNum <= 51)
            {
                if ((cardNum == 51) && (LastCardDrawn != null))
                    LastCardDrawn(this, EventArgs.Empty);
                return cards[cardNum];
            } 
            else
                throw (new System.ArgumentOutOfRangeException("cardNum", cardNum, "Value must be between 0 and 51."));

        }

        public void Shuffle()
        {
            Cards newDeck = new Cards();
            bool[] assigned = new bool[52];
            Random sourceGen = new Random();
            for (int i = 0; i < 52; i++)
            {
                int destCard = 0;
                bool foundCard = false;
                while (foundCard == false)
                {
                    destCard = sourceGen.Next(52);
                    if (assigned[destCard] == false)
                        foundCard = true;
                }
                assigned[destCard] = true;
                //Write(destCard);
                //Write (" ");
                newDeck.Add(cards[destCard]);

            }
            newDeck.CopyTo(cards);
           
        }
        
    }
}