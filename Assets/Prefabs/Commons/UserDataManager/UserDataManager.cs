using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
        return JObject.Parse(
            File.ReadAllText(
                Path.Combine(
                    PathVariables.userDataStorageDirectory,
                    PathVariables.userDataStorageFilename
                )
            )
        ).ToObject<UserData>();
    }

    public static void SaveStorage(UserData userData)
    {
        File.WriteAllText(
            Path.Combine(
                PathVariables.userDataStorageDirectory,
                PathVariables.userDataStorageFilename
            ),
            JsonConvert.SerializeObject(userData)
        );
    }
}
