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
    public static JObject LoadJson(string path)
    {
        string jsonData = File.ReadAllText(path);
        JObject obj = JObject.Parse(jsonData);
        return obj;
    }

    public static List<T> LoadSingleList<T>(JObject ObjectSet)
    {
        // Todo..
    }

    public static Dictionary<string, T> LoadSingleDepth<T>(JObject ObjectSet)
    {
        Dictionary<string, T> dict = new Dictionary<string, T>();
        foreach (var obj in ObjectSet)
        {
            dict.Add(obj.Key, obj.Value.ToObject<T>());
        }
        return dict;
    }
}
