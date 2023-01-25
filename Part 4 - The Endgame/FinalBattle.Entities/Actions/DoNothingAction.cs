using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalBattle.Logic
{
    public class DoNothingAction : IAction
    {
        public string Run(Battle battle, Character actor)
        {
            return $"{actor.Name} did NOTHING.";
        }
    }
}
