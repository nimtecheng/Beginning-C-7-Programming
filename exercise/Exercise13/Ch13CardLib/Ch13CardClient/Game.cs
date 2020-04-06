using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ch13CardLib;
using static System.Console;

namespace Ch13CardClient
{
    public class Game
    {
        private int currentCard;
        private Deck playDeck;
        private Player[] players;
        private Cards discardedCards;
        public Game()
        {
            currentCard = 0;
            playDeck = new Deck();
            playDeck.LastCardDrawn += Reshuffle;
            playDeck.Shuffle();
            discardedCards = new Cards();

        }
        private void Reshuffle(object source, EventArgs args)
        {
            WriteLine("Discarded cards reshuffled into deck.");
            ((Deck)source).Shuffle();
            discardedCards.Clear();
            currentCard = 0;
        }
        public void SetPlayers(Player[] newPlayers)
        {
            if (newPlayers.Length > 7)
                throw new ArgumentException("A maximum of 7 players may play this game.");
            if (newPlayers.Length < 2)
                throw new ArgumentException("A minimum of 2 players may play this game.");
            players = newPlayers;
        }
        private void DealHands()
        {

            for (int p = 0; p < players.Length; p++)
            {
                for (int c = 0; c < 7; c++)
                {
                    players[p].PlayHand.Add(playDeck.GetCard(currentCard++));
                }
            }
        }
        public int PlayGame()
        {
            //only play if players exist
            if (players == null)
                return -1;
            //Deal initial hands
            DealHands();
            //initialize game vars,including an initial card to place on the table playCard
            bool GameWon = false;
            int currentPlayer;
            Card playCard = playDeck.GetCard(currentCard++);
            discardedCards.Add(playCard);
            //main game loop,continues until GameWon==true.
            do
            {
                //loop through players in each game round
                for (currentPlayer = 0; currentPlayer < players.Length; currentPlayer++)
                {
                    //Write out current player,player hand , and the card on the table
                    WriteLine($"{players[currentPlayer].Name}'s Turn.");
                    WriteLine("Current hand:");
                    foreach (Card card in players[currentPlayer].PlayHand)
                    { WriteLine(card); }
                    WriteLine($"Card in play:{playCard}");
                    //prompt players to pick up card on table or draw a new one 
                    bool inputOK = false;
                    do
                    {
                        WriteLine("Press T to take card in play or D to draw:");
                        string input = ReadLine();
                        if (input.ToLower() == "t")
                        {
                            //Add card from table to player hand.
                            WriteLine($"Drawn:{playCard}");
                            //Remove from discarded cards if possible
                            //if deck is reshuffled it won't be there any more
                            if (discardedCards.Contains(playCard))
                            {
                                discardedCards.Remove(playCard);
                            }
                            players[currentPlayer].PlayHand.Add(playCard);
                            inputOK = true;
                        }
                        if (input.ToLower() == "d")
                        {
                            //add new deck from deck to player hand.
                            Card newCard;
                            //only add card if it isn't already in a player hand
                            //or in the discard pile
                            bool cardIsAvailable;
                            do
                            {
                                newCard = playDeck.GetCard(currentCard++);
                                //check if card is in discard pile
                                cardIsAvailable = !discardedCards.Contains(newCard);
                                if (cardIsAvailable)
                                {
                                    //loop through all players hands to see if newCard is already in a hand
                                    foreach (Player testPlayer in players)
                                    {
                                        if (testPlayer.PlayHand.Contains(newCard))
                                        {
                                            cardIsAvailable = false;
                                            break;

                                        }
                                    }
                                }
                            } while (!cardIsAvailable);
                            //add the card found to player hand.
                            WriteLine($"Drawn:{newCard}");
                            players[currentPlayer].PlayHand.Add(newCard);
                            inputOK = true;
                        }


                    } while (inputOK == false) ;
                        //display new hand with cards numbered
                        WriteLine("New hand:");
                        for (int i = 0; i < players[currentPlayer].PlayHand.Count; i++)
                        {
                            WriteLine($"{i + 1}: {players[currentPlayer].PlayHand[i]}");
                        }
                        //prompt players for a card to discard
                        inputOK = false;
                        int choice = -1;
                        do
                        {
                            WriteLine("choose card to discard:");
                            string input1 = ReadLine();
                            try
                            {
                                //Attempt to convert input into a valid card number
                                choice = Convert.ToInt32(input1);
                                if ((choice > 0) && (choice <= 8))
                                    inputOK = true;
                            }
                            catch
                            {
                                //ingnore failed conversation,just continue prompting
                            }

                        } while (inputOK == false);
                        //place reference to removed card in playerCard 
                        //place the card on the table then remove card from player hand and add to discard pile
                        playCard = players[currentPlayer].PlayHand[choice - 1];
                        players[currentPlayer].PlayHand.RemoveAt(choice - 1);
                        discardedCards.Add(playCard);
                        WriteLine($"Discarding:{playCard}");
                        //sapce out text for players
                        WriteLine();
                        //check to see if player has won the game,and exit the player
                        //loop id so.
                        GameWon = players[currentPlayer].HasWon();
                        if (GameWon == true)
                            break;
                }
            } while (GameWon == false);
            //End game,noting the wining player
            return currentPlayer;

        }
    }
}
