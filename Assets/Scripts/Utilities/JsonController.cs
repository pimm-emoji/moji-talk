using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json.Linq;

/*
    The PresetController
*/
class PresetController  //PresetController Ŭ����
{
    public static JObject LoadJsonToObject(string path) { return JObject.Parse(File.ReadAllText(path)); }  //Jobject �޼ҵ�.  path ��Ʈ���� �˻��ؼ� �Ľ��� �� �� JObject�� �����Ѵ�.
    public static JArray LoadJsonToArray(string path) { return JArray.Parse(File.ReadAllText(path)); } // JArray �޼ҵ�. path�� �޾� �Ľ��ѵ� �� JArray�� �����Ѵ�.

    public static Dictionary<string, T> LoadSingleDepth<T>(JObject Object)  // �̰� ���� �𸣰���
    {
        Dictionary<string, T> dict = new Dictionary<string, T>();
        foreach (var obj in Object)
        {
            dict.Add(obj.Key, obj.Value.ToObject<T>());    // Obj.Value.ToObject<t>�� �������� �𸣰���
        }
        return dict;
    }
    public static List<T> LoadSingleDepth<T>(JArray Array)   // �� <T>�� ���� �𸣰���
    {
        List<T> arr = new List<T>();
        foreach (var obj in Array)
        {
            arr.Add(obj.ToObject<T>());
        }
        return arr;
    }
    
    public static EmojiGenerations LoadGenData(JObject JObject)
    {
        List<Emoji> positiveEmojis = JObject["positiveEmojis"].ToObject<List<Emoji>>();
        var negativeEmojis = JObject["negativeEmojis"].ToObject<List<Emoji>>();
        EmojiGenerations EmojiGenerations = JObject.ToObject<EmojiGenerations>();
        EmojiGenerations.positiveEmojis = positiveEmojis;
        EmojiGenerations.negativeEmojis = negativeEmojis;
        return EmojiGenerations;
    }
}

class AssetLoader : MonoBehaviour
{
    public static JObject LoadJsonToObject(string path) { return JObject.Parse(Resources.Load<TextAsset>(path).text); }
    public static JArray LoadJsonToArray(string path) { return JArray.Parse(Resources.Load<TextAsset>(path).text); }
}
