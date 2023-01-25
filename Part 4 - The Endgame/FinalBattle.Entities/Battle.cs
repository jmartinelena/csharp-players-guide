using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalBattle.Logic;

namespace FinalBattle
{
    public class Battle
    {
        public Party HeroParty { get; init; }
        public Party EnemyParty { get; init; }
        private bool _heroPartyTurn = true;

        public Battle(Party heroParty, Party enemyParty)
        {
            HeroParty = heroParty;
            EnemyParty = enemyParty;
        }

        public void Run()
        {
            while (true)
            {
                Party party = _heroPartyTurn ? HeroParty : EnemyParty;

                foreach (Character character in party.Characters)
                {
                    Console.ForegroundColor = _heroPartyTurn ? ConsoleColor.Blue : ConsoleColor.Red;
                    Console.WriteLine($"It is {character.Name}'s turn...");
                    Console.ResetColor();

                    Console.WriteLine(party.Player.ChooseAction(this, character).Run(this, character));
                    Console.WriteLine();
                }

                _heroPartyTurn = !_heroPartyTurn;
            }
        }
    }
}
