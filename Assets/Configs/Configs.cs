using System.IO;
using UnityEngine;

/*
    The internal system configs of moji talk
*/
public class Configs
{
    /*
        Primary Assets Paths
    */
    /// <summary>
    /// PresetPath is path of Preset.
    /// Path: <c>/Assets/Presets</c>
    /// </summary>
    public static string PresetPath;

    /// <summary>
    /// ResourcePath is path of common resources root directory.
    /// Path: <c>/Assets/Resources</c>
    /// </summary>
    public static string ResourcePath;

    /// <summary>
    /// PrefabPath is path of prefab resources root directory.
    /// </summary>
    public static string PrefabPath;


    /*
        Presets Paths
    */
    /// <summary>
    /// ProfileIndexPath is path of Profile Preset.
    /// Path: <c>/Assets/Presets/profiles.json</c>
    /// </summary>
    public static string ProfileIndexPath;

    public static string PresetProfileDirPath;

    /// <summary>
    /// LevelIndexPath is path of Level Index Preset.
    /// Path: <c>/Assets/Presets/levels.json</c>
    /// </summary>
    public static string LevelIndexPath;

    /// <summary>
    /// LevelDirPath is path of Path of Level Data Directory.
    /// Path: <c>/Assets/Presets/levels</c>
    /// </summary>
    public static string LevelDirPath;


    /*
        Resources Paths
    */
    /// <summary>
    /// ResourceEmojiPath is path of emoji resources
    /// Path: <c>/Assets/Resources/Emojis</c>
    /// </summary>
    public static string ResourceEmojiPath;

    /// <summary>
    /// ResourceProfilePath is path of Profile Resource Directory.
    /// Path: <c>/Assets/Resources/Profiles</c>
    /// </summary>
    public static string ResourceProfilePath;

    /// <summary>
    /// ResourceProfileImagePath is path of Profile Image Resource Directory.
    /// Path: <c>/Assets/Resources/Profiles/Images</c>
    /// </summary>
    public static string ResourceProfileImagePath;
    
    static Configs()
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
    }
}
