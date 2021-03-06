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
        {
            File.Create(Path.Combine(PathVariables.userDataStorageDirectory, PathVariables.userDataStorageFilename));
            UserDataManager.SaveStorage(new UserData());
        }
    }

    public static UserData LoadStorage()
    {
        return JsonIO.LoadJsonFileToObject<UserData>(
            Path.Combine(
                PathVariables.userDataStorageDirectory,
                PathVariables.userDataStorageFilename
            )
        );
    }

    public static void SaveStorage(UserData userData)
    {
        File.WriteAllText(
            Path.Combine(
                PathVariables.userDataStorageDirectory,
                PathVariables.userDataStorageFilename
            ),
            JsonUtility.ToJson(userData)
        );
    }
}
