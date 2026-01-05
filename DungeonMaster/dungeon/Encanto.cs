using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonMaster.dungeon
{
    internal class Encanto
    {
        private Random random = new Random();
        public string[] encantoType = new string[]
        {
            "",
            "罠が発動した",
            "モンスターが出現した",
            "宝箱を発見した"
        };
        public int setEncanto()
        {
            int encanto = random.Next(1, 9);
            int encantoPoint = encanto switch
            {
                < 6 => 0,
                < 7 => 1,
                < 8 => 2,
                < 9 => 3,
                _ => 4,
            };
            return encantoPoint;
        }
    }
}
