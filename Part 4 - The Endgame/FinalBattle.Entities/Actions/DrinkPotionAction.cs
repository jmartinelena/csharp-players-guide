using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalBattle.Logic.Actions
{
    internal class DrinkPotionAction : UseItemAction
    {
        public DrinkPotionAction(HpPotion hpPotion, Character target) : base(hpPotion, target)
        {
        }

        public override string Run(Battle battle, Character actor)
        {
            List<IItem> bag = battle.GetPartyFor(actor).Bag;

            _target.CurrentHP = Math.Clamp(_target.CurrentHP + 10, _target.CurrentHP, _target.MaxHP);
            
            string result = $"{actor.Name} used {_item.Name} on {_target.Name}." +
                $"\n{_target.Name} heals for 10 HP and is now at {_target.CurrentHP} HP.";

            bag.Remove(_item);
            return result;
        }
    }
}
