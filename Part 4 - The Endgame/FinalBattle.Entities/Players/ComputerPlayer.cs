using FinalBattle.Logic.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalBattle.Logic
{
    public class ComputerPlayer : IPlayer
    {
        public IAction ChooseAction(Battle battle, Character actor, MenuChoice choice)
        {
            Thread.Sleep(500);

            List<Character> potentialTargets = battle.GetEnemyPartyFor(actor).Characters;

            if (battle.GetPartyFor(actor).Bag.Count > 0 && CheckForPotion().Item1 && actor.CurrentHP <= actor.MaxHP / 2 )
            {
                if (new Random().Next(0, 5) == 0)
                {
                    return new UseItemAction(CheckForPotion().Item2!, actor);
                }
            }
            
            if (potentialTargets.Count > 0)
            {
                return new AttackAction(actor.Attacks[0], battle.GetEnemyPartyFor(actor).Characters[0]);
            } else
            {
                return new DoNothingAction();
            }

            (bool, HpPotion? potion) CheckForPotion()
            {
                foreach (IItem item in battle.GetPartyFor(actor).Bag)
                {
                    if (item is HpPotion potion) return (true, potion);
                }
                return (false, null);
            }
        }
    }
}
