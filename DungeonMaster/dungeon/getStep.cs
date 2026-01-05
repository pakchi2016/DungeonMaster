using System;
using DungeonMaster;
using DungeonMaster.status;

namespace DungeonMaster.dungeon
{
    internal class getStep
    {
        private Random random = new Random();
        public int getRandomStep(int speed)
        {
            return random.Next(1, speed + 1);
        }
    }
}
