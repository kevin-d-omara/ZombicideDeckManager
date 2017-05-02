using System;
using System.Collections.Generic;

namespace ZombicideDeckManager.Deck
{
    /// <summary>
    /// The base features of all Zombie Spawn cards. Spawn cards are immutable.
    /// </summary>
    public class SpawnCard
    {
        public readonly string cardNumber;
        public readonly string flavorText;
        public readonly ZombieStrain strain;
        public readonly DangerLevel[] level = new DangerLevel[4];

        public SpawnCard(string cardNumber, string flavorText, ZombieStrain strain,
            DangerLevel blue, DangerLevel yellow, DangerLevel orange, DangerLevel red)
        {
            this.cardNumber = cardNumber;
            this.flavorText = flavorText;
            this.strain = strain;
            level[0] = blue;
            level[1] = yellow;
            level[2] = orange;
            level[3] = red;
        }
    }
}
