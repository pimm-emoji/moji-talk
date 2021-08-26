using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserDataManager
{
    public static void InitStorage()
    {
        if (!Directory.Exists(PathVariables.userDataStorageDirectory)) Directory.CreateDirectory(PathVariables.userDataStorageDirectory);
        if (!File.Exists(Path.Combine(PathVariables.userDataStorageDirectory, PathVariables.userDataStorageFilename)))
            File.Create(Path.Combine(PathVariables.userDataStorageDirectory, PathVariables.userDataStorageFilename));
    }
}
