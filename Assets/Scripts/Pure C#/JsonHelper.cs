using UnityEngine;

namespace ZombicideDeckManager
{
    // Author: ffleurey
    // Source: https://forum.unity3d.com/threads/how-to-load-an-array-with-jsonutility.375735/#post-2585129
    public class JsonHelper
    {
        /// <summary>
        /// Parse JSON w/ an array at the outermost layer.
        /// </summary>
        public static T[] GetJsonArray<T>(string json)
        {
            string newJson = "{ \"array\": " + json + "}";
            Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(newJson);
            return wrapper.array;
        }

        [System.Serializable]
        private class Wrapper<T>
        {
            public T[] array = null;
        }
    }
}
