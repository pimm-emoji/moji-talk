using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilitiesDebugger : MonoBehaviour
{
    [ContextMenu("Debug JsonIO LoadJsonFileToObject")]
    public void DebugJsonIOLoadJsonFileToObject()
    {
        JsonIO.LoadJsonFileToObject<List<UtilitiesDebuggingDataContainer>>(
            Path.Combine(Application.dataPath, "Scripts", "Utilities", "UtilitiesDebuggingDataContrainer.json")
        );
    }
}

[System.Serializable]
public class UtilitiesDebuggingDataContainer
{
    string name;
    string id;
    public UtilitiesDebuggingDataContainer()
    {
        name = "Name";
        id = "ID";
    }
    public UtilitiesDebuggingDataContainer(string Name)
    {
        name = Name;
        id = "ID";
    }
    public UtilitiesDebuggingDataContainer(string Name, string ID)
    {
        name = Name;
        id = ID;
    }
}