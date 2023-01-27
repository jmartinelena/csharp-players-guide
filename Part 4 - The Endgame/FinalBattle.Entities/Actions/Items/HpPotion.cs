using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalBattle.Logic.Actions
{
    public class HpPotion : IItem
    {
        public string Name => "HP Potion";
        public string Description => "Heals the character for 10 health points.";
    }
}
