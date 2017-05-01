using System;
using System.Collections.Generic;

namespace ZombicideDeckManager.Deck
{
    /// <summary>
    /// The base features of all Zombie Spawn cards. Spawn cards are immutable.
    /// </summary>
    public class SpawnCard : ISpawnCard
    {
        public int CardNumber    { get; private set; }
        public string FlavorText { get; private set; }

        public ZombieStrain Strain { get; private set; }

        public SpawnLevel Blue   { get; private set; }
        public SpawnLevel Yellow { get; private set; }
        public SpawnLevel Orange { get; private set; }
        public SpawnLevel Red    { get; private set; }

        public void Display()
        {
            Console.WriteLine(CardNumber + ", " + FlavorText);
            Console.WriteLine(Strain);
            Console.WriteLine("Red    : " + Red   .ToString());
            Console.WriteLine("Orange : " + Orange.ToString());
            Console.WriteLine("Yellow : " + Yellow.ToString());
            Console.WriteLine("Blue   : " + Blue  .ToString());
        }
    }
}
