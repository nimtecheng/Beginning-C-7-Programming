using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch13CardLib
{
    [Serializable]
 public class ComputerPlayer:Player
    {
        private Random random = new Random();
        public ComputerSkillLevel Skill { get; set; }
        public override string PlayerName => $"Computer {Index}";
        public void PerformDraw(Deck deck,Card availableCard)
        {
            if (Skill == ComputerSkillLevel.Dumb)
                DrawCard(deck);
            else
                DrawBestCard(deck, availableCard, (Skill == ComputerSkillLevel.Cheats));
        }
        public void PerformDiscard(Deck deck)
        {
            if (Skill == ComputerSkillLevel.Dumb)
                DiscardCard(Hand[random.Next(Hand.Count)]);
            else
                DiscardWorstCard();
        }
        private void DrawBestCard(Deck deck,Card availableCard,bool cheat=false)
        {
            var bestSuit = CalculateBestSuit();
            if (availableCard.suit == bestSuit)
                AddCard(availableCard);
            else if (cheat == false)
                DrawCard(deck);
            else
                AddCard(deck.SelectCardOfSpecificSuit(bestSuit));
        }
        private void DiscardWorstCard()
        {
            DiscardCard(Hand.First(x => x.suit == CalculateWorstSuit()));
        }

        private Suit CalculateBestSuit() => OrderSuitsInhand().Last();
        private Suit CalculateWorstSuit() => OrderSuitsInhand().First();

        private List<Suit> OrderSuitsInhand()
        {
            var cardSuits = new Dictionary<Suit, int>
            {
                { Suit.Club,0},
                { Suit.Diamond,0},
                { Suit.Heart,0},
                { Suit.Spade,0},
            };
            foreach (var card in Hand)
                cardSuits[card.suit]++;
            return cardSuits.OrderBy(x => x.Value).Select(y => y.Key).ToList();
        }
    }
}
