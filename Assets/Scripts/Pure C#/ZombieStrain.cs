using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ZombicideDeckManager
{
    /// <summary>
    /// Visual information for a Zombie Strain.
    ///     Zombie Strain == Standard, Toxic, Seeker, etc.
    ///     Zombie Type == Walker, Runner, Seeker, Crows, etc.
    /// </summary>
    public class ZombieStrain
    {
        public string name;
        public Icon icon;
        public Dictionary<string, Icon> type = new Dictionary<string, Icon>();

        public ZombieStrain(string name, Icon icon)
        {
            this.name = name;
            this.icon = icon;
        }
    }
}
