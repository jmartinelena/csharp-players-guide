using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalBattle.Logic
{
    public interface IAction
    {
        public string Run(Battle battle, Character actor);
    }
}
