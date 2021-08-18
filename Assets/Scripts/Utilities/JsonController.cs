using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json.Linq;

/*
    The PresetController
*/
class PresetController
{
    public static JObject LoadJsonToObject(string path) { return JObject.Parse(File.ReadAllText(path)); }
    public static JArray LoadJsonToArray(string path) { return JArray.Parse(File.ReadAllText(path)); }

    public static Dictionary<string, T> LoadSingleDepth<T>(JObject Object)
    {
        Dictionary<string, T> dict = new Dictionary<string, T>();
        foreach (var obj in Object)
        {
            dict.Add(obj.Key, obj.Value.ToObject<T>());
        }
        return dict;
    }
    public static List<T> LoadSingleDepth<T>(JArray Array)
    {
        List<T> arr = new List<T>();
        foreach (var obj in Array)
        {
            arr.Add(obj.ToObject<T>());
        }
        return arr;
    }
}

class AssetLoader : MonoBehaviour
{
    public static JObject LoadJsonToObject(string path) { return JObject.Parse(Resources.Load<TextAsset>(path).text); }
    public static JArray LoadJsonToArray(string path) { return JArray.Parse(Resources.Load<TextAsset>(path).text); }
}
