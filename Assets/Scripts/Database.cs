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
        private Dictionary<string, Dictionary<string, Sprite>> cache = new Dictionary<string, Dictionary<string, Sprite>>();

        private void Awake()
        {
            cache.Add("Symbols", new Dictionary<string, Sprite>());
            cache.Add("Silhouettes", new Dictionary<string, Sprite>());
        }

        private IEnumerator Start()
        {
            // Load all images into RAM from StreamingAssets/
            yield return StartCoroutine(LoadImagesIn("Symbols/", cache["Symbols"]));
            yield return StartCoroutine(LoadImagesIn("Silhouettes/", cache["Silhouettes"]));
            Debug.Log("Sprites loaded into RAM.");

            // Create Icons (Sprite + metadata) from images
            var path = Application.streamingAssetsPath + "/Images/Symbols/Symbols.json";
            var js = File.ReadAllText(path);
            var icon = JsonUtility.FromJson<Icon>(js);

            //var icon = JsonUtility.FromJson<Icon>();

            // TODO: Free up memory?

        }

        /// <summary>
        /// Load all images from disk into a dictionary, where key=filename and value=sprite.
        /// </summary>
        /// <param name="subFolder">Subfolder in Sprites/ (i.e. "Silhouettes/").</param>
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
