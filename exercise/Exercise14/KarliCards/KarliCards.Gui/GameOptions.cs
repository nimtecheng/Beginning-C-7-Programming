using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace KarliCards.Gui
{
    [Serializable]
    public class GameOptions
    {
    private bool playAgainstComputer = true;
    private int numberOfplayers = 2;
    private ComputerSkillLevel computerSkill = ComputerSkillLevel.Dumb;

    public bool PlayAgainst { get; set; }
    public int NumberOfplayers
        {
            get { return numberOfplayers; }

            set { numberOfplayers = value;OnpropertyChanged(nameof(NumberOfplayers)); }
        }
    public bool PlayAgainstComputer
        {
            get { return playAgainstComputer; }
            set { playAgainstComputer = value;
                OnpropertyChanged(nameof(PlayAgainstComputer));
            }
        }
    public ComputerSkillLevel ComputerSkill
        {
            get { return computerSkill; }
            set
            {
                computerSkill = value;
                OnpropertyChanged(nameof(ComputerSkill));

            }
        }
    public int MinutesBeforeLoss { get; set; }
  
    public event PropertyChangedEventHandler PropertyChanged;
    private void OnpropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
  
    [Serializable]
    public enum ComputerSkillLevel
    {
        Dumb,
        Good,
        Cheats
    }
}
