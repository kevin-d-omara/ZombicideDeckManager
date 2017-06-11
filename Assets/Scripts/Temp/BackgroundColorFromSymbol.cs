using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ZombicideDeckManager
{
    public class BackgroundColorFromSymbol : MonoBehaviour
    {
        public Image symbol;
        public Image background;

        private void Awake()
        {
            float h, s, v;
            Color.RGBToHSV(symbol.color, out h, out s, out v);

            background.color = Color.HSVToRGB(h, s, 1);
        }
    }
}
