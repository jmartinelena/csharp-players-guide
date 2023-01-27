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

            if (choice.Target == null || choice.Choice == ActionChoice.DoNothing)
            {
                return new DoNothingAction();
            }
            else
            {
                return new AttackAction(actor.StandardAttack, choice.Target);
            }
        }
    }
}
