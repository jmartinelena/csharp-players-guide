using FinalBattle.Logic.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalBattle.Logic.Units
{
    public class Skeleton : Character
    {
        public override string Name => "SKELETON";
        public override List<IAttack> Attacks { get; } = new List<IAttack> { new BoneCrunch() };
        public override int MaxHP => 6;
        public override int CurrentHP { get; set; } = 6;
    }
}
