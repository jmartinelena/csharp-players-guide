using FinalBattle.Logic.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalBattle.Logic.Units
{
    public class UncodedOne : Character
    {
        public override string Name => "The Uncoded One";
        public override List<IAttack> Attacks => new List<IAttack> { new UnravelingAttack() };
        public override int MaxHP => 15;
        public override int CurrentHP { get; set; } = 15;
    }
}
