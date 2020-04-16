using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using Ch13CardLib;

namespace KarliCards.Gui
{
    class GameViewModel:INotifyPropertyChanged
    {
        private GameOptions gameOptions;
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        public GameViewModel()
        {
            Players = new List<Player>();
            gameOptions = GameOptions.Create();
        }
        private Player currentPlayer;
        private List<Player> players;
        private Card availableCard;
        private Deck deck;
        private bool gameStarted;
        public Player CurrentPlayer
        {
            get { return currentPlayer; }
            set
            {
                currentPlayer = value;
                OnPropertyChanged(nameof(CurrentPlayer));
            }
        }
        public List<Player> Players
        {
            get { return players; }
            set
            {
                players = value;
                OnPropertyChanged(nameof(Players));

            }
        }
        public Card CurrentAvailableCard
        {
            get { return availableCard; }
            set
            {
                availableCard = value;
                OnPropertyChanged(nameof(CurrentAvailableCard));
            }
        }
        public Deck GameDeck
        {
            get { return deck; }
            set
            {
                deck = value;
                OnPropertyChanged(nameof(GameDeck));
            }
        }
        public bool GameStarted
        {
            get { return gameStarted; }
            set
            {
                gameStarted = value;
                OnPropertyChanged(nameof(GameStarted));
            }
        }
        public static RoutedCommand StartGameCommand = new RoutedCommand("Start New Game", typeof(GameViewModel),
            new InputGestureCollection(new List<InputGesture>
            { new KeyGesture(Key.N,ModifierKeys.Control)}));
        public static RoutedCommand ShowAboutCommand = new RoutedCommand("Show About Dialog", typeof(GameViewModel));

        public void StartNewGame()
        {
            if (gameOptions.SelectedPlayers.Count < 1 ||
                (gameOptions.SelectedPlayers.Count == 1 && !gameOptions.PlayAgainstComputer))
                return;
            
        }
        private void CreateGameDeck()
        {
            GameDeck = new Deck();
            GameDeck.Shuffle();
        }
        private void CreatePlayers()
        {
            Players.Clear();
            for(var i=0;i<gameOptions.NumberOfplayers;i++)
            {
                if(i<gameOptions.SelectedPlayers.Count)
                    Initial
            }
        }
        private InitializePlayer(Player player)
        {
            player.DrawNewHand(GameDeck);
            player.OnCardDiscarded += player_OnCardDiscard;

        }

    }
   
}
