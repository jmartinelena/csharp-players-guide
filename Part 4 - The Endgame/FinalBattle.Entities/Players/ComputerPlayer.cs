using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalBattle.Logic
{
    public class ComputerPlayer : IPlayer
    {
        public IAction ChooseAction(Battle battle, Character actor)
        {
            Thread.Sleep(500);
            return new AttackAction(actor.StandardAttack, battle.GetEnemyPartyFor(actor).Characters[0] );
        }
    }
}
