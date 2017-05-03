using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ZombicideDeckManager
{
    /// <summary>
    /// Metadata for a sprite.
    /// </summary>
    public class Icon
    {
        public Sprite sprite;
        public Vector2 offset = Vector2.zero;
        public float rotation = 0.0f;
        public float scale = 1.0f;
        public Color color = Color.white;

        public Icon(Sprite sprite)
        {
            this.sprite = sprite;
        }

        // rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, texture.width);
    }
}
