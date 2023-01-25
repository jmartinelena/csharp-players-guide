using FinalBattle;
using FinalBattle.Common;
using FinalBattle.Logic;
using FinalBattle.Logic.Actions;
using FinalBattle.Logic.Units;

string name = ConsoleHelper.Ask("True Programmer, what is your name?");

TrueProgrammer trueProgrammer = new TrueProgrammer(name);

Party heroParty = new Party(new ComputerPlayer(), new List<Character> { trueProgrammer });
//Party enemyParty = new Party(new ComputerPlayer(), new List<Character> { new Skeleton() });
List<Party> enemyParties = new List<Party> { new Party(new ComputerPlayer(), new List<Character> { new Skeleton() }),
new Party(new ComputerPlayer(), new List<Character> { new Skeleton(), new Skeleton() }) };

Battle battle = new Battle(heroParty, enemyParties);
battle.Run();