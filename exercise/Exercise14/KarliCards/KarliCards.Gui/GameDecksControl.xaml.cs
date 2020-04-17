using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Ch13CardLib;

namespace KarliCards.Gui
{
    /// <summary>
    /// Interaction logic for GameDecksControl.xaml
    /// </summary>
    public partial class GameDecksControl : UserControl
    {
        public GameDecksControl()
        {
            InitializeComponent();
        }


        public bool GameStarted
        {
            get { return (bool)GetValue(GameStartedProperty); }
            set { SetValue(GameStartedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for GameStarted.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GameStartedProperty =
            DependencyProperty.Register("GameStarted", typeof(bool), typeof(GameDecksControl), new PropertyMetadata(false));



        public Player CurrentPlayer
        {
            get { return (Player)GetValue(CurrentPlayerProperty); }
            set { SetValue(CurrentPlayerProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CurrentPlayer.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentPlayerProperty =
            DependencyProperty.Register("CurrentPlayer", typeof(Player), typeof(GameDecksControl), new PropertyMetadata(null));


        public Deck Deck
        {
            get { return (Deck)GetValue(DeckProperty); }
            set { SetValue(DeckProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Deck.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DeckProperty =
            DependencyProperty.Register("Deck", typeof(Deck), typeof(GameDecksControl), new PropertyMetadata(null));


        public Card AvailableCard
        {
            get { return (Card)GetValue(AvailableCardProperty); }
            set { SetValue(AvailableCardProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AvailableCard.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AvailableCardProperty =
            DependencyProperty.Register("AvailableCard", typeof(Card), typeof(GameDecksControl), new PropertyMetadata(null));


    private void DrawDecks()
        {
            controlCanvas.Children.Clear();
            if (CurrentPlayer == null || Deck == null || !GameStarted)
                return;
            List<CardControl> stackedCards = new List<CardControl>();
            for (int i = 0; i < Deck.CardsInDeck; i++)
                stackedCards.Add(new CardControl(Deck.GetCard(i))
                {
                    Margin = new Thickness(150 + (i * 1.25), 25 - (i * 1.25), 0, 0),
                    IsFaceUp = false
                });
            if (stackedCards.Count > 0)
                stackedCards.Last().MouseDoubleClick += Deck_Mouse
        ;
        }

    }
    void AvailableCard_MouseDoubleClick(object sender,MouseButtonEventArgs e)
    {
        if()
    }
    void Deck_MouseDoubleClick(object sender,MouseButtonEventArgs e)
    {
        if()
         
    }
}
