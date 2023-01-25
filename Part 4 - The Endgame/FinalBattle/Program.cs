using FinalBattle;
using FinalBattle.Common;
using FinalBattle.Logic;
using FinalBattle.Logic.Actions;

string name = ConsoleHelper.Ask("True Programmer, what is your name?");

Character trueProgrammer = new Character(name, new Punch());

Party heroParty = new Party(new ComputerPlayer(), new List<Character> { trueProgrammer });
Party enemyParty = new Party(new ComputerPlayer(), new List<Character> { new Character("SKELETON", new BoneCrunch()) });

Battle battle = new Battle(heroParty, enemyParty);
battle.Run();