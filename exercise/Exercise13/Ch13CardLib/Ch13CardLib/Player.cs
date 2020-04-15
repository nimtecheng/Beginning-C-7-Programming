using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Ch13CardLib
{
    [Serializable]
    class Player:INotifyPropertyChanged
    {
        public int Index { get; set; }
        protected Cards Hand { get; set; }
        private string name;
        private PlayerState state;
        public event EventHandler<CardEventArgs> OnCardDiscarded;
        public event EventHandler<PlayerEventArgs> OnPlayerHasWon;
        public PlayerState State
        {
            get { return state; }
            set
            {
                state = value;
                OnPropertyChanged(nameof(State));
            }
        }
        public virtual string PlayerName
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged(nameof(PlayerName));
            }
        }
       
    }
}
