using FinalBattle.Logic.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalBattle.Logic.Units
{
    public class TrueProgrammer : Character
    {
        public override string Name { get; }
        public override List<IAttack> Attacks { get; } = new List<IAttack> { new Punch() };
        public override int MaxHP { get; } = 25;
        public override int CurrentHP { get; set; } = 25;

        public TrueProgrammer(string name)
        {
            Name = name;
        }
    }
}
