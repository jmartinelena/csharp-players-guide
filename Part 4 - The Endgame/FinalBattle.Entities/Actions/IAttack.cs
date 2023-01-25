using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalBattle.Logic
{
    public interface IAttack
    {
        public string Name { get; }
        public int Damage { get; }
    }
}
