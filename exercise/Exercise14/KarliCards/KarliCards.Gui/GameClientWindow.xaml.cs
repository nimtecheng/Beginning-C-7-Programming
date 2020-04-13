using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace KarliCards.Gui
{
    /// <summary>
    /// Interaction logic for GameClientWindow.xaml
    /// </summary>
    public partial class GameClientWindow : Window
    {
        public GameClientWindow()
        {
            InitializeComponent();
            var position = new Point(15, 15);
            for(var i=0;i<4;i++)
            {
                var suit = (Ch13CardLib.Suit)i;
                position.Y = 15;
                for(int rank=1;rank<14;rank++)
                {
                    position.Y += 30;
                    var card = new CardControl(new Ch13CardLib.Card((Ch13CardLib.Suit)suit, (Ch13CardLib.Rank)rank));
                    card.VerticalAlignment = VerticalAlignment.Top;
                    card.HorizontalAlignment = HorizontalAlignment.Left;
                    card.Margin = new Thickness(position.X, position.Y, 0, 0);
                    ContentGrid.Children.Add(card);
                }
                position.X += 112;
            }
        }
    }
}
