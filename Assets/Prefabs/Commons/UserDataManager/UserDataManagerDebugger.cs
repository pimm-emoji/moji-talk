using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserDataManagerDebugger : MonoBehaviour
{
    [ContextMenu("Debug Init Storage")] void DebugInitStorage() { UserDataManager.InitStorage(); }
}
