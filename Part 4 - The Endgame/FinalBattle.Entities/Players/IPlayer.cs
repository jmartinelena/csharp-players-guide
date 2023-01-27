using FinalBattle.Logic.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalBattle.Logic
{
    public interface IPlayer
    {
        IAction ChooseAction(Battle battle, Character actor, MenuChoice choice);
    }
}
