using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalBattle.Logic
{
    public class AttackAction: IAction
    {
        private IAttack _attack;
        private Character _target;

        public AttackAction(IAttack attack, Character target)
        {
            _attack = attack;
            _target = target;
        }

        public string Run(Battle battle, Character actor)
        {
            int damageDealt = _target.CurrentHP > 0 ? actor.Attacks[0].Damage : 0;
            _target.CurrentHP -= damageDealt;

            string result = $"{actor.Name} used {_attack.Name} on {_target.Name}." +
                $"\n{_attack.Name} dealt {damageDealt} damage to {_target.Name}." +
                $"\n{_target.Name} is now at {_target.CurrentHP}/{_target.MaxHP} HP.";

            if (_target.CurrentHP <= 0)
            {
                battle.GetPartyFor(_target).Characters.Remove(_target);
                result += $"\n{_target.Name} has been defeated!";
            }

            return result;
        }
    }
}
