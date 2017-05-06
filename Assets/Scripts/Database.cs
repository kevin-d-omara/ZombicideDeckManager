using System.IO;
using System.Text;
using System.Xml;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZombicideDeckManager
{
    public class Database : MonoBehaviour
    {
        /// <summary>
        /// Holds all images in RAM from StreamingAssets/
        /// </summary>
        private Dictionary<string, Dictionary<string, Sprite>> cache = new Dictionary<string, Dictionary<string, Sprite>>();

        /// <summary>
        /// Holds all the Icons (Sprite + metadata) from StreamingAssets/
        /// </summary>
        private Dictionary<string, Dictionary<string, Icon>> icons = new Dictionary<string, Dictionary<string, Icon>>();

        private void Awake()
        {
            cache.Add("Symbols", new Dictionary<string, Sprite>());
            cache.Add("Silhouettes", new Dictionary<string, Sprite>());

            icons.Add("Symbols", new Dictionary<string, Icon>());
            icons.Add("Silhouettes", new Dictionary<string, Icon>());
        }

        private IEnumerator Start()
        {
            // Load all images into RAM from StreamingAssets/
            yield return StartCoroutine(LoadImagesIn("Symbols/", cache["Symbols"]));
            yield return StartCoroutine(LoadImagesIn("Silhouettes/", cache["Silhouettes"]));
            Debug.Log("Sprites loaded into RAM.");

            // Create Icons (Sprite + metadata) from images
            MakeIcons("Symbols/Symbols.json", "Symbols", icons["Symbols"]);

            // Release memory (i.e. de-reference all unused images) & Create sprite atlas.

        }

        /// <summary>
        /// Create Icons from metadata in a JSON file.
        /// </summary>
        /// <param name="subFilePath">Sub-path in Images/ (i.e. Symbols/Symbols.json).</param>
        /// <param name="cacheKey">Key in 'cache' to get Sprites (i.e. "Symbols").</param>
        /// <param name="dictionary">Dictionary to place icons into.</param>
        private void MakeIcons(string subFilePath, string cacheKey, Dictionary<string, Icon> dictionary)
        {
            // Read metadata from JSON file.
            var path = Application.streamingAssetsPath + "/Images/" + subFilePath;
            var js = File.ReadAllText(path);
            var icons = JsonHelper.GetJsonArray<Icon>(js);

            // Create Icons based by metadata.
            foreach (Icon icon in icons)
            {
                icon.sprite = cache[cacheKey][icon.image];
                dictionary.Add(icon.image, icon);
            }
        }

        /// <summary>
        /// Load all images from disk into a dictionary, where key=filename and value=sprite.
        /// </summary>
        /// <param name="subFolder">Subfolder in Images/ (i.e. "Silhouettes/").</param>
        /// <param name="dictionary">Dictionary to place loaded sprites into.</param>
        private IEnumerator LoadImagesIn(string subFolder, Dictionary<string, Sprite> dictionary)
        {
            var path = Application.streamingAssetsPath + "/Images/" + subFolder;

            var imageNames = Directory.GetFiles(path, @"*.png");
            for (int i = 0; i < imageNames.Length; ++i)
            {
                Sprite sprite = null;
                yield return StartCoroutine(LoadImageInto((x) => sprite = x, imageNames[i]));

                var imageName = Path.GetFileName(imageNames[i]);
                dictionary.Add(imageName, sprite);
            }
        }

        /// <summary>
        /// Load an image from disk into a sprite.
        /// </summary>
        /// <param name="sprite">Lambda function to set sprite: (x) => sprite = x</param>
        private IEnumerator LoadImageInto(System.Action<Sprite> sprite, string absolutePathToImage)
        {
            var www = new WWW("file:///" + absolutePathToImage);
            yield return www;

            Texture2D texture = new Texture2D(1, 1);
            www.LoadImageIntoTexture(texture);

            var rect = new Rect(0, 0, texture.width, texture.height);
            var pivot = new Vector2(texture.width / 2.0f, texture.height / 2.0f);
            var newSprite = Sprite.Create(texture, rect, pivot);
            sprite(newSprite);
        }
    }
}
