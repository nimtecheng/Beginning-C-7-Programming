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

        public static bool operator ==(Card card1, Card card2) => (card1?.suit == card2?.suit) && (card1?.rank == card2?.rank);
        public static bool operator !=(Card card1, Card card2) => !(card1 == card2);

        public override bool Equals(object card) => this == (Card)card;
       // public override int GetHashCode() => 13 * (int)suit + (int)rank;


    }
}