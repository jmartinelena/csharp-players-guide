using FinalBattle.Logic.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalBattle.Logic
{
    public abstract class Character
    {
        public abstract string Name { get; }
        public abstract List<IAttack> Attacks { get; }
        public abstract int MaxHP { get; }
        public abstract int CurrentHP { get; set; }

    }
}
