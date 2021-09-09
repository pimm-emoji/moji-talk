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
}