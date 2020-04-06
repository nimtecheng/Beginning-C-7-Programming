using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarliCards.Gui
{
    [Serializable]
    class GameOptions
    {
    public bool PlayAgainst { get; set; }
    public int NumberOfplayers { get; set; }
    public int MinutesBeforeLoss { get; set; }
    public ComputerSkillLevel ComputerSkill { get; set; }
    }
    [Serializable]
    public enum ComputerSkillLevel
    {
        Dumb,
        Good,
        Cheats
    }
}
