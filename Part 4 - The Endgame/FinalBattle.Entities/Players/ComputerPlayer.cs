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

            if (battle.GetPartyFor(actor).Bag.Count > 0 && actor.CurrentHP <= actor.MaxHP / 2 )
            {
                return new DrinkPotionAction((HpPotion)battle.GetPartyFor(actor).Bag[choice.ChoiceIndex], actor);
            }
            
            if (potentialTargets.Count > 0)
            {
                return new AttackAction(actor.Attacks[0], battle.GetEnemyPartyFor(actor).Characters[0]);
            } else
            {
                return new DoNothingAction();
            }
        }
    }
}
