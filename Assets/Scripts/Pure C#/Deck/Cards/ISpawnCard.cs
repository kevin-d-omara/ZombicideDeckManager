using System;
using System.Collections.Generic;

namespace ZombicideDeckManager.Deck
{
    public interface ISpawnCard
    {
        int CardNumber    { get; }
        string FlavorText { get; }

        ZombieStrain Strain { get; }

        SpawnLevel Blue   { get; }
        SpawnLevel Yellow { get; }
        SpawnLevel Orange { get; }
        SpawnLevel Red    { get; }

        void Display();
    }

    public enum ZombieType { Walker, Fatty, Runner, Abomination, Crawler, Seeker, Dog, Crow, Lost, VIP }
    public enum ZombieStrain { Standard, Skinner, Toxic, Berserker, Seeker }

    public class SpawnLevel
    {
        public readonly int amount;
        public readonly ZombieType type;
        public readonly string caption;

        public override string ToString()
        {
            if (amount > 0)
            {
                return amount + "x" + type + " (" + caption + ")";
            }
            else
            {
                return amount + " (" + caption + ")";
            }
        }
    }
}
