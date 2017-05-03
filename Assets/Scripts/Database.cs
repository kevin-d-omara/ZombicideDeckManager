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
        public Dictionary<string, ZombieStrain> Strains { get; private set; }

        private Dictionary<string, Sprite> icons = new Dictionary<string, Sprite>();
        private Dictionary<string, Sprite> silhouettes = new Dictionary<string, Sprite>();

        private void Awake()
        {
            Strains = new Dictionary<string, ZombieStrain>();
        }

        private IEnumerator Start()
        {
            // Load all sprites into RAM.
            yield return StartCoroutine(LoadImagesIn("Icons/", icons));
            yield return StartCoroutine(LoadImagesIn("Silhouettes/", silhouettes));
            Debug.Log("Sprites loaded into RAM.");

            // Create Strains.
            CreateStrains();
            Debug.Log("Strains created.");
            
            // TODO: Free up memory?
        }

        private void CreateStrains()
        {
            var doc = new XmlDocument();
            doc.Load(Application.streamingAssetsPath + "/Strains.xml");

            foreach (XmlNode strain in doc.DocumentElement)
            {
                var name = strain["name"].InnerText;

                // Load icon.
                var iconNode = strain["icon"];
                var icon = new Icon(icons[iconNode["image"].InnerText]);
                // color, etc.
                Strains.Add(name, new ZombieStrain(name, icon));

                // Load Types.
            }
        }


        /// <summary>
        /// Load all images from disk into a dictionary, where key=filename and value=sprite.
        /// </summary>
        /// <param name="subFolder">Subfolder in Sprites/ (i.e. "Silhouettes/").</param>
        /// <param name="dictionary">Dictionary to place loaded sprites into.</param>
        private IEnumerator LoadImagesIn(string subFolder, Dictionary<string, Sprite> dictionary)
        {
            var absoluteFolderPath = Application.streamingAssetsPath + "/Sprites/" + subFolder;

            var imageNames = Directory.GetFiles(absoluteFolderPath, @"*.png");
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
