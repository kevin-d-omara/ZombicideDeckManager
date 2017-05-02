using System;
using System.Collections.Generic;

namespace ZombicideDeckManager.Deck
{
    public enum ZombieType { Walker, Fatty, Runner, Abomination, Crawler, Seeker, Dog, Crow, Lost, VIP }
    public enum ZombieStrain { Standard, Skinner, Toxic, Berserker, Seeker }

    /// <summary>
    /// Container for what is spawned at a single danger level.
    /// </summary>
    public class DangerLevel
    {
        public readonly string caption;
        public readonly int amount;
        public readonly ZombieType type;

        public DangerLevel(string caption, int amount, ZombieType type)
        {
            this.caption = caption;
            this.amount = amount;
            this.type = type;
        }
    }
}
