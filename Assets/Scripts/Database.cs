using System.Text;
using System.Xml;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZombicideDeckManager
{
    public class Database : MonoBehaviour
    {
        public Dictionary<string, ZombieStrain> Strains { get; private set; }

        private void Awake()
        {
            Strains = new Dictionary<string, ZombieStrain>();
        }

        private void Start()
        {
            // Build database.
            var doc = new XmlDocument();
            doc.Load(Application.streamingAssetsPath + "/Strains.xml");

            // Load Strains.
            foreach (XmlNode strain in doc.DocumentElement)
            {
                var name = strain["name"].InnerText;

                var icon = strain["icon"];
                var pathToIcon = "/Sprites/Icons/" + icon["image"].InnerText;

                var types = strain["types"];
            }
        }
    }
}
