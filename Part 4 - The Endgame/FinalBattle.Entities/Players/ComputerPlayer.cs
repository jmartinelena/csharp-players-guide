﻿using FinalBattle.Logic.Actions;
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

            if (potentialTargets.Count > 0)
            {
                return new AttackAction(actor.StandardAttack, battle.GetEnemyPartyFor(actor).Characters[0]);
            } else
            {
                return new DoNothingAction();
            }
        }
    }
}
