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

                    if (BattleIsOver) break;
                }

                if (HeroParty.Characters.Count == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("The heroes have lost, and the Uncoded One's forces have prevailed...");
                    Console.ResetColor();
                    break;
                }
                else if (EnemyParty.Characters.Count == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("The heroes have won, and the Uncoded One's evil reign is over!");
                    Console.ResetColor();
                    break;
                }
                
                _heroPartyTurn = !_heroPartyTurn;
            }
        }

        public Party GetPartyFor(Character character)
        {
            return HeroParty.Characters.Contains(character) ? HeroParty : EnemyParty;
        }
        public Party GetEnemyPartyFor(Character character)
        {
            return HeroParty.Characters.Contains(character) ? EnemyParty : HeroParty;
        }
        public bool BattleIsOver => HeroParty.Characters.Count == 0 || EnemyParty.Characters.Count == 0;
    }
}
