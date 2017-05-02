using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZombicideDeckManager
{
    public class Driver : MonoBehaviour
    {
        public GameObject spawnCardPrefab;

        private void Start()
        {



            /*
            var info = new SpawnCard("142", "IT'S FRAG + TIME!", ZombieStrain.Standard,
                new DangerLevel("GLAD", 0, ZombieType.Walker),
                new DangerLevel("BAD", 1, ZombieType.Runner),
                new DangerLevel("SAD", 2, ZombieType.Fatty),
                new DangerLevel("EGAD!", 3, ZombieType.Abomination));

            var card = Instantiate(spawnCardPrefab);
            card.name = "Spawn Card #" + info.cardNumber;
            card.GetComponent<SpawnCardController>().SetSpawnCard(info);
            */
        }
    }
}
