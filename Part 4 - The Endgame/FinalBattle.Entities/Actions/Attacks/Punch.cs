using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalBattle.Logic.Actions
{
    public class Punch : IAttack
    {
        public string Name => "PUNCH";
        public int Damage => 1;
    }
}
