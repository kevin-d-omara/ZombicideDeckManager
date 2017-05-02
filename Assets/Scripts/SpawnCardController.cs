using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ZombicideDeckManager
{
    /// <summary>
    /// A visual wrapper for SpawnCard.
    /// </summary>
    public class SpawnCardController : MonoBehaviour
    {
        /// <summary>
        /// Spawn Card which this class is wrapping.
        /// </summary>
        public SpawnCard Card { get; private set; }

        [Header("Title")]
        [SerializeField] private Text cardNumber;
        [SerializeField] private Text flavorText;

        [Header("Danger Level")]
        [SerializeField] private DangerLevelController blue;
        [SerializeField] private DangerLevelController yellow;
        [SerializeField] private DangerLevelController orange;
        [SerializeField] private DangerLevelController red;

        /// <summary>
        /// Set the Spawn Card which this class is wrapping, then update this game object's visuals.
        /// </summary>
        public void SetSpawnCard(SpawnCard card)
        {
            Card = card;
            UpdateVisuals();
        }

        /// <summary>
        /// Update this game object's visual elements to match the attached spawn card.
        /// </summary>
        private void UpdateVisuals()
        {
            cardNumber.text = "#" + Card.cardNumber;
            flavorText.text = Card.flavorText.Replace(" + ", "\n");

            blue  .UpdateVisuals(Card.level[0]);
            yellow.UpdateVisuals(Card.level[1]);
            orange.UpdateVisuals(Card.level[2]);
            red   .UpdateVisuals(Card.level[3]);
        }

        [Serializable]
        /// <summary>
        /// A visual wrapper for DangerLevel
        /// </summary>
        public class DangerLevelController
        {
            public Text  caption;
            public Text  amount;
            public Image type;

            public void UpdateVisuals(DangerLevel level)
            {
                caption.text = level.caption;
                if (level.amount > 0)
                {
                    amount.text = "x" + level.amount.ToString();
                }
                else
                {
                    amount.text = "";
                }
                // update type icon
            }
        }
    }
}
