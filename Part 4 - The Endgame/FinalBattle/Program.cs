using FinalBattle;
using FinalBattle.Common;
using FinalBattle.Logic;

string name = ConsoleHelper.Ask("True Programmer, what is your name?");

Character trueProgrammer = new Character(name);

Party heroParty = new Party(new ComputerPlayer(), new List<Character> { trueProgrammer });
Party enemyParty = new Party(new ComputerPlayer(), new List<Character> { new Character("SKELETON") });

Battle battle = new Battle(heroParty, enemyParty);
battle.Run();