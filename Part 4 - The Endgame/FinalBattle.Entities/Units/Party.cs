using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalBattle.Logic
{
    public class Party
    {
        public IPlayer Player { get; init; }
        public List<Character> Characters { get; init; }

        public Party(IPlayer player, List<Character> characters)
        {
            Player = player;
            Characters = characters;
        }
    }
}
