using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalBattle.Common;
using FinalBattle.Logic;
using FinalBattle.Logic.Actions;

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
                        DisplayInfo(character);

                        Console.ForegroundColor = _heroPartyTurn ? ConsoleColor.Blue : ConsoleColor.Red;
                        Console.WriteLine($"It is {character.Name}'s turn...");
                        Console.ResetColor();

                        Console.WriteLine(party.Player.ChooseAction(this, character, GetChoice(party.Player, character)).Run(this, character));
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

        public MenuChoice GetChoice(IPlayer player, Character actor)
        {
            if (player is ComputerPlayer)
            {
                return new MenuChoice(ActionChoice.DoNothing, null);
            }
            else
            {
                Console.WriteLine($"\n\t1 - Standard Attack ({actor.StandardAttack.Name})\n\t2 - Do nothing (skips turn)");
                
                int result;
                do
                {
                    string answer = ConsoleHelper.Ask("What do you want to do?");
                    int.TryParse(answer, out result);
                    if (result != 1 && result != 2)
                    {
                        Console.WriteLine("Invalid answer, try again...");
                    }
                } while (result != 1 && result != 2);

                if (result == 2) return new MenuChoice(ActionChoice.DoNothing, null);
                else
                {
                    List<Character> potentialTargets = GetEnemyPartyFor(actor).Characters;
                    
                    for (int index = 0; index < potentialTargets.Count; index++)
                    {
                        Console.WriteLine($"\t{index + 1} - {potentialTargets[index].Name}");
                    }
                    
                    int attackChoice;
                    do
                    {
                        string answer = ConsoleHelper.Ask("Who do you wanna attack?");
                        int.TryParse(answer, out attackChoice);
                        if (attackChoice < 1 || attackChoice > potentialTargets.Count)
                        {
                            Console.WriteLine("Invalid answer, try again...");
                        }
                    } while (attackChoice < 1 || attackChoice > potentialTargets.Count);

                    return new MenuChoice(ActionChoice.Attack, potentialTargets[attackChoice - 1]);
                }
            }
        }

        public void DisplayInfo(Character actor)
        {
            Console.WriteLine("=====================================BATTLE=====================================");
            
            foreach (Character character in HeroParty.Characters)
            {
                if (character == actor) Console.ForegroundColor = ConsoleColor.Yellow;
                string info = $"{character.Name}                 {character.CurrentHP}/{character.MaxHP} HP";
                Console.WriteLine($"{info, -80}");
                Console.ResetColor();
            }

            Console.WriteLine("---------------------------------------VS---------------------------------------");

            foreach (Character character in CurrentEnemyParty.Characters)
            {
                if (character == actor) Console.ForegroundColor = ConsoleColor.Yellow;
                string info = $"{character.Name}                 {character.CurrentHP}/{character.MaxHP} HP";
                Console.WriteLine($"{info, 80}");
                Console.ResetColor();
            }

            Console.WriteLine("================================================================================\n");
        }
    }
}
