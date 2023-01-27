using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalBattle.Logic.Actions
{
    public class MenuChoice
    {
        public ActionChoice Choice { get; }
        public Character? Target { get; } = null;

        public MenuChoice(ActionChoice choice, Character? target)
        {
            Choice = choice;
            Target = target;
        }
    }

    public enum ActionChoice { DoNothing, Attack }
}
