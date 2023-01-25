using FinalBattle.Logic.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalBattle.Logic
{
    public class Character
    {
        public string Name { get; init; }
        public IAttack StandardAttack { get; init; }

        public Character(string name, IAttack attack)
        {
            Name = name;
            StandardAttack = attack;
        }
    }
}
