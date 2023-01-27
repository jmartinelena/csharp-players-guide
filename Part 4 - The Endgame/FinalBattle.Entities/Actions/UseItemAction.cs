using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalBattle.Logic.Actions
{
    public abstract class UseItemAction: IAction
    {
        protected IItem _item;
        protected Character _target;

        public abstract string Run(Battle battle, Character actor);

        public UseItemAction(IItem item, Character target)
        {
            _item = item;
            _target = target;
        }
    }
}
