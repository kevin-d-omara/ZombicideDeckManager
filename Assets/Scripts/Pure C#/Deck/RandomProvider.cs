using System;
using System.Collections.Generic;

namespace ZombicideDeckManager.Deck
{
    public static class RandomProvider
    {
        public static Random Random
        {
            get { return _random; }
        }

        private static readonly Random _random = new Random();
    }
}
