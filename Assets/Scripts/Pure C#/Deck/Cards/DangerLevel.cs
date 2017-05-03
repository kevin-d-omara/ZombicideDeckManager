using System;
using System.Collections.Generic;

namespace ZombicideDeckManager
{
    /// <summary>
    /// Container for what is spawned at a single danger level.
    /// </summary>
    public class DangerLevel
    {
        public readonly string caption;
        public readonly int amount;
        public readonly Icon type;

        public DangerLevel(string caption, int amount, Icon type)
        {
            this.caption = caption;
            this.amount = amount;
            this.type = type;
        }
    }
}
