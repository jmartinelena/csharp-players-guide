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

        public string Use(Character actor, Character target)
        {
            target.CurrentHP = Math.Clamp(target.CurrentHP + 10, target.CurrentHP, target.MaxHP);

            string result = $"{actor.Name} used {Name} on {target.Name}." +
                $"\n{target.Name} heals for 10 HP and is now at {target.CurrentHP} HP.";

            return result;
        }
    }
}
