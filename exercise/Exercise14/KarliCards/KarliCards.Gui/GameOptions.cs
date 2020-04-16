using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Input;
using Ch13CardLib;



namespace KarliCards.Gui
{
    [Serializable]
    public class GameOptions
    {
        private ObservableCollection<string> playerNames = new ObservableCollection<string>();
        public List<string> SelectedPlayers { get; set; } = new List<string>();
 
        public ObservableCollection<string> PlayerNames
        {
            get { return playerNames; }
            set
            {
                playerNames = value;
                OnPropertyChanged("PlayerNames");
            }
        }
        public void AddPlayer(string playerName)
        {
            if (PlayerNames.Contains(playerName))
                return;
            PlayerNames.Add(playerName);
            OnPropertyChanged("PlayerNames");
        }
    
 
        private bool playAgainstComputer = true;
        private int numberOfplayers = 2;
        private ComputerSkillLevel computerSkill = ComputerSkillLevel.Dumb;        
        public int NumberOfplayers
            {
                get { return numberOfplayers; }

                set { numberOfplayers = value;OnPropertyChanged(nameof(NumberOfplayers)); }
            }
        public bool PlayAgainstComputer
        {
            get { return playAgainstComputer; }
            set
            {
                playAgainstComputer = value;
                OnPropertyChanged(nameof(PlayAgainstComputer));
            }
        }
        public ComputerSkillLevel ComputerSkill
            {
                get { return computerSkill; }
                set
                {
                    computerSkill = value;
                    OnPropertyChanged(nameof(ComputerSkill));

                }
            }
        public int MinutesBeforeLoss { get; set; }
  
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        public static RoutedCommand OptionsCommand = new RoutedCommand("Show Options",
    typeof(GameOptions), new InputGestureCollection(new List<InputGesture> {
            new KeyGesture(Key.O,ModifierKeys.Control)}));

        public void Save()
        {
            using (var stream = File.Open("GameOptions.xml", FileMode.Create))
            {
                var serializer = new XmlSerializer(typeof(GameOptions));
                serializer.Serialize(stream, this);
            }
        }
        public static GameOptions Create()
        {
            if (File.Exists("GameOptions.xml"))
            {
                using (var stream = File.OpenRead("GameOptions.xml"))
                {
                    var serializer = new XmlSerializer(typeof(GameOptions));
                    return serializer.Deserialize(stream) as GameOptions;
                }
            }
            else
                return new GameOptions();
        }
    }



}
