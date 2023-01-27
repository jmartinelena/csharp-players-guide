using FinalBattle.Logic.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalBattle.Logic.Players
{
    public class HumanPlayer : IPlayer
    {
        public IAction ChooseAction(Battle battle, Character actor, MenuChoice choice)
        {
            Thread.Sleep(500);

            IAction result = choice.Choice switch
            {
                ActionChoice.Attack when choice.Target != null => new AttackAction(actor.Attacks[choice.ChoiceIndex], choice.Target),
                ActionChoice.UseItem => new UseItemAction(battle.GetPartyFor(actor).Bag[choice.ChoiceIndex], actor),
                _ => new DoNothingAction()

            };

            return result;
        }
    }
}
