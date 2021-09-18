using System.IO;
using UnityEngine;

public class PathVariables
{
    public static string PresetPath;
    public static string ResourcePath;
    public static string PrefabPath;
    public static string ProfileIndexPath;
    public static string PresetProfileDirPath;
    public static string LevelIndexPath;
    public static string LevelDirPath;
    public static string ResourceEmojiPath;
    public static string ResourceProfilePath;
    public static string ResourceProfileImagePath;
    public static string userDataStorageDirectory;
    public static string userDataStorageFilename = "DataStorage.moji";
    
    static PathVariables()
    {
        PresetPath = Path.Combine(Application.dataPath, "Presets");
        ResourcePath = Path.Combine(Application.dataPath, "Resources");
        PrefabPath = Path.Combine(Application.dataPath, "Prefabs");

        ProfileIndexPath = Path.Combine(PresetPath, "profiles.json");
        PresetProfileDirPath = Path.Combine(PresetPath, "profiles");
        LevelIndexPath = Path.Combine(PresetPath, "levels.json");
        LevelDirPath = Path.Combine(PresetPath, "levels");

        ResourceEmojiPath = Path.Combine(ResourcePath, "Emojis");
        ResourceProfilePath = Path.Combine(ResourcePath, "Profiles");
        ResourceProfileImagePath = Path.Combine(ResourceProfilePath, "Images");

        userDataStorageDirectory = Path.Combine(Application.dataPath, "Saves");
    }
}
