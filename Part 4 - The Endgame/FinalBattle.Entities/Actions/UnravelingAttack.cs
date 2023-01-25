using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalBattle.Logic.Actions
{
    public class UnravelingAttack : IAttack
    {
        public string Name => "UNRAVELING ATTACK";
        public int Damage => new Random().Next(0,3);
    }
}
