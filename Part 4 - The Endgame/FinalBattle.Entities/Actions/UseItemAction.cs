using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalBattle.Logic.Actions
{
    public class UseItemAction: IAction
    {
        private IItem _item;
        private Character _target;
        public UseItemAction(IItem item, Character target)
        {
            _item = item;
            _target = target;
        }

        public string Run(Battle battle, Character actor)
        {
            List<IItem> bag = battle.GetPartyFor(actor).Bag;

            string result = _item.Use(actor, _target);

            bag.Remove(_item);
            return result;
        }

    }
}
