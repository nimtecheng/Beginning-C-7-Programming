using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Ch13CardClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //display instruction
            WriteLine("BenJaminCards: a new and exciting card game.");
            WriteLine("To win you must have 7 cards of the same suit in your hand");
            WriteLine();
            //prompt for number of players
            bool inputOK = false;
            int choice = -1;
            do
            {
                WriteLine("How many players (2-7) ?");
                string input = ReadLine();
                try
                {
                    //Attempt to convert input to a valid number of player.
                    choice = Convert.ToInt32(input);
                    if ((choice >= 2) && (choice <= 7))
                        inputOK = true;
                }
                catch
                {
                    //ignore failed conversations,just continue prompting
                }
            } while (inputOK==false);

            //initialize array of player objects
            Player[] players = new Player[choice];
            //get player names
            for (int p = 0; p < players.Length; p++)
            {
                WriteLine($"Player {p + 1} ,enter your name:");
                string playerName = ReadLine();
                players[p] = new Player(playerName);

            }
            //start game
            Game newGame = new Game();
            newGame.SetPlayers(players);
            int whoWon = newGame.PlayGame();
            //Display winning player
            WriteLine($"{players[whoWon].Name} has won the game!");

        }
    }
}
