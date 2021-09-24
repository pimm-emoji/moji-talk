using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

class JsonIO
{
    public static T LoadJsonFileToObject<T>(string path)
    {
        return JsonUtility.FromJson<T>(File.ReadAllText(path));
    }
    public static T LoadJsonAssetToObject<T>(string path)
    {
        TextAsset textAsset = Resources.Load<TextAsset>(path);
        return JsonUtility.FromJson<T>(textAsset.text);
    }
}

/*
[System.Serializable]
public class DictionarySerializableObject<TKey, TValue> : ISerializationCallbackReceiver
{
    [SerializeField] List<TKey> keys;
    [SerializeField] List <TValue> values;
    
    Dictionary<TKey, TValue> target;
    public Dictionary<TKey, TValue> ToDictionary() { return target; }

    public DictionarySerializableObject(Dictionary<TKey, TValue> Target)
    {
        target = Target;
    }
    public void OnBeforeSerialize() 
    {
        keys = new List<TKey>(target.Keys);
        values = new List<TValue>(target.Values);
    }
    public void OnAfterDeserialize()
    {
        var count = Math.Min(keys.Count, values.Count);
        target = new Dictionary<TKey, TValue>(count);
        for (var i = 0; i < count; ++i)
        {
            target.Add(keys[i], values[i]);
        }
    }
}
*/
