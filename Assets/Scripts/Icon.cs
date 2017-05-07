using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ZombicideDeckManager
{
    /// <summary>
    /// Metadata for a sprite.
    /// 
    /// Note: Sprites used as an Image (UI) will automatically have 'width' and 'height' set to
    /// native values via Image.SetNativeSize.
    /// </summary>
    [Serializable]
    public class Icon
    {
        public Sprite sprite;
        public string image = "";
        public Vector2 offset = Vector2.zero;
        public float rotation = 0.0f;
        public float scale = 1.0f;
        public Color color = Color.white;

        /// <summary>
        /// Set the Image with this Sprite and metadata.
        /// </summary>
        public void SetImage(Image image)
        {
            image.sprite = sprite;
            image.SetNativeSize();
            image.color = color;

            var rect = image.rectTransform;
            rect.localEulerAngles = new Vector3(0f, 0f, rotation);
            rect.localScale = new Vector3(scale, scale, scale);

            // TODO: Make offsets not stack (i.e. if A.SetImage(B) is called twice, B's positions should be the same both times).
            var x = rect.localPosition.x + offset.x;
            var y = rect.localPosition.y + offset.y;
            var z = rect.localPosition.z;
            rect.localPosition = new Vector3(x, y, z);
        }
    }
}
