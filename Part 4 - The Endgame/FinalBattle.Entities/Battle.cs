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
        public List<Party> EnemyParties { get; }
        public Party CurrentEnemyParty { get; set; }
        private bool _heroPartyTurn = true;

        public Battle(Party heroParty, List<Party> enemyParties)
        {
            HeroParty = heroParty;
            EnemyParties = enemyParties;
            CurrentEnemyParty = enemyParties[0];
        }

        public void Run()
        {
            for (int index = 0; index < EnemyParties.Count; index++)
            {
                _heroPartyTurn = true;
                CurrentEnemyParty = EnemyParties[index];
                
                while (true)
                {
                    Party party = _heroPartyTurn ? HeroParty : CurrentEnemyParty;

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
                    else if (CurrentEnemyParty.Characters.Count == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("The heroes have won this fight!\n--------------------------------------------\n");
                        Console.ResetColor();
                        break;
                    }

                    _heroPartyTurn = !_heroPartyTurn;
                }

                if (HeroParty.Characters.Count == 0) break;
            }
            
            if (HeroParty.Characters.Count != 0)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("The heroes have won, and the evil reign of the Uncoded One is no more!");
                Console.ResetColor();
            }
        }

        public Party GetPartyFor(Character character)
        {
            return HeroParty.Characters.Contains(character) ? HeroParty : CurrentEnemyParty;
        }
        public Party GetEnemyPartyFor(Character character)
        {
            return HeroParty.Characters.Contains(character) ? CurrentEnemyParty : HeroParty;
        }
        public bool BattleIsOver => HeroParty.Characters.Count == 0 || CurrentEnemyParty.Characters.Count == 0;
    }
}
