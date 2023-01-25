using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalBattle.Logic
{
    public class Character
    {
        public string Name { get; init; }

        public Character(string name)
        {
            Name = name;
        }

        public string DoNothing()
        {
            return $"{Name} did NOTHING.";
        }
    }
}
