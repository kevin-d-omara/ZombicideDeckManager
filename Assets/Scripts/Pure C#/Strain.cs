using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ZombicideDeckManager
{
    /// <summary>
    /// Visual information for a Zombie Strain.
    /// 
    /// A single flavor of zombie (i.e. Standard, Toxic, Seeker, Crows, etc.) and the corresponding
    /// Zombie Types (i.e. Walker, Runner, Seeker, etc.).
    /// </summary>
    public class ZombieStrain
    {
        public string name;
        public Icon icon;
        public ZombieType[] type;

        public ZombieStrain(string name, Icon icon, ZombieType[] type)
        {
            this.name = name;
            this.icon = icon;
            this.type = type;
        }

        public class Icon
        {
            public Sprite sprite;
            public Vector2 offset;
            public float rotation;
            public float scale;
            public Color color;

            public Icon(Sprite sprite, Vector2 offset, float rotation, float scale, Color color)
            {
                this.sprite = sprite;
                this.offset = offset;
                this.rotation = rotation;
                this.scale = scale;
                this.color = color;
            }
        }
    }

    public class ZombieType
    {
        public static Dictionary<string, ZombieType> Type = new Dictionary<string, ZombieType>();

        public Sprite sprite;
        public Vector2 offset;
        public float scale;

        public ZombieType(Sprite sprite, Vector2 offset, float scale)
        {
            this.sprite = sprite;
            this.offset = offset;
            this.scale = scale;
        }

        /// <summary>
        /// Return the ZombieType associated with the strain and type provided.
        /// </summary>
        /// <param name="strain">Strain of the zombie.</param>
        /// <param name="type">Type of the zombie (within the strain).</param>
        public static ZombieType GetType(string strain, string type)
        {
            ZombieType result = null;
            Type.TryGetValue(ToKey(strain, type), out result);
            return result;
        }

        /// <summary>
        /// Add a ZombieType of the provided strain and type.
        /// </summary>
        /// <param name="strain">Strain of the zombie.</param>
        /// <param name="type">Type of the zombie.</param>
        public static void AddType(string strain, string type)
        {
            var key = ToKey(strain, type);
            if (Type.ContainsKey(key)) { return; }
            //Type.Add(key, type);
        }

        /// <summary>
        /// Return the key into Type
        /// </summary>
        private static string ToKey(string strain, string type)
        {
            return strain + "." + type;
        }
    }
}
