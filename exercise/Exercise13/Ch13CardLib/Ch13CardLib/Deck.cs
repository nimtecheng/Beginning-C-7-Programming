
using System.Collections.Generic;
using System;
using System.Linq;
namespace Ch13CardLib
{
    public delegate void LastCardDrawnHandler(Deck currentDeck);
    public class Deck:ICloneable
    {
        public event LastCardDrawnHandler LastCardDrawn;
        private Cards cards=new Cards();
      
        public object Clone()
        {
            Deck newDeck = new Deck(cards.Clone() as Cards);
            return newDeck;
        }
    
        public Deck()
        {
            InsertAllCards();
        }
        protected Deck(Cards newCards)
        {
            cards = newCards;
        }
        public int  CardsInDeck
        {
            get { return cards.Count; }
        }
        public Card GetCard(int cardNum)
        {
            if (cardNum >= 0 && cardNum <= 51)
            {
                if ((cardNum == 51) && (LastCardDrawn != null))
                    LastCardDrawn(this);
                return cards[cardNum];
            } 
            else
                throw (new System.ArgumentOutOfRangeException("cardNum", cardNum, "Value must be between 0 and 51."));

        }

        public void Shuffle()
        {
            Cards newDeck = new Cards();
            bool[] assigned = new bool[cards.Count];
            Random sourceGen = new Random();
            for (int i = 0; i < cards.Count; i++)
            {
                int destCard = 0;
                bool foundCard = false;
                while (foundCard == false)
                {
                    destCard = sourceGen.Next(cards.Count);
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

        public void ReshuffleDiscarded(List<Card> cardsInPlay)
        {
            InsertAllCards(cardsInPlay);
            Shuffle();
        }
        public Card Draw()
        {
            if (cards.Count == 0) return null;
            var card = cards[0];
            cards.RemoveAt(0);
            return card;
        }
        public Card SelectCardOfSpecificSuit(Suit suit)
        {
            Card selectedCard = cards.FirstOrDefault(card => card?.suit == suit);
            if (selectedCard == null) return Draw();
            cards.Remove(selectedCard);
            return selectedCard;
        }
        private void InsertAllCards()
        {
            for(int suitVal=0;suitVal<4;suitVal++)
                for(int rankVal=1;rankVal<14;rankVal++)
                {
                    cards.Add(new Card((Suit)suitVal, (Rank)rankVal));
                }
        }
        private void InsertAllCards(List<Card>except)
        {
            for (int suitVal = 0; suitVal < 4; suitVal++)
                for (int rankVal = 1; rankVal < 14; rankVal++)
                {
                    var card = new Card((Suit)suitVal, (Rank)rankVal);
                    if (except?.Contains(card) ?? false)
                        cards.Add(card);
                }
        }
        
    }
}