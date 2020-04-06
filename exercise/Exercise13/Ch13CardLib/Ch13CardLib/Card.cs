using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ch13CardLib
{
    public class Card:ICloneable
    {
        public readonly Rank rank;
        public readonly Suit suit;
        public object Clone() => MemberwiseClone();
        private Card()
        {
            throw new System.NotImplementedException();
        }

        public Card(Suit newSuit, Rank newRank)
        {
            suit=newSuit;
            rank = newRank;
        }

        public override string ToString()=>"The "+ rank+" of "+ suit +"s";
       
    }
}