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
        public int ChoiceIndex { get; } = 0;

        public MenuChoice(ActionChoice choice, Character? target, int index)
        {
            Choice = choice;
            Target = target;
            ChoiceIndex = index;
        }
    }

    public enum ActionChoice { Attack = 1, UseItem, DoNothing }
}
