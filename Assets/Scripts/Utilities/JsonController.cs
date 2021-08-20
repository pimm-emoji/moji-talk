using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json.Linq;

/*
    The PresetController
*/
class PresetController  //PresetController 클래스
{
    public static JObject LoadJsonToObject(string path) { return JObject.Parse(File.ReadAllText(path)); }  //Jobject 메소드.  path 스트링을 검색해서 파싱한 뒤 그 JObject를 리턴한다.
    public static JArray LoadJsonToArray(string path) { return JArray.Parse(File.ReadAllText(path)); } // JArray 메소드. path를 받아 파싱한뒤 그 JArray를 리턴한다.

    public static Dictionary<string, T> LoadSingleDepth<T>(JObject Object)  // 이게 뭔지 모르겠음
    {
        Dictionary<string, T> dict = new Dictionary<string, T>();
        foreach (var obj in Object)
        {
            dict.Add(obj.Key, obj.Value.ToObject<T>());    // Obj.Value.ToObject<t>가 무엇인지 모르겠음
        }
        return dict;
    }
    public static List<T> LoadSingleDepth<T>(JArray Array)   // 저 <T>가 뭔지 모르겠음
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
