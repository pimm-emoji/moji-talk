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
}
