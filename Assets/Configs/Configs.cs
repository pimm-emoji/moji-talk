using System.IO;
using UnityEngine;

/*
    The internal system configs of moji talk
*/
class Configs
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


    /*
        Presets Paths
    */
    /// <summary>
    /// ProfilePath is path of Profile Preset.
    /// Path: <c>/Assets/Presets/profiles.json</c>
    /// </summary>
    public static string ProfilePath;

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
    /// EmojiPath is path of emoji resources
    /// Path: <c>/Assets/Resources/Emojis</c>
    /// </summary>
    public static string EmojiPath;
    
    static Configs()
    {
        PresetPath = Path.Combine(Application.dataPath, "Presets");
        ResourcePath = Path.Combine(Application.dataPath, "Resources");

        ProfilePath = Path.Combine(PresetPath, "profiles.json");
        LevelIndexPath = Path.Combine(PresetPath, "levels.json");
        LevelDirPath = Path.Combine(PresetPath, "levels");

        EmojiPath = Path.Combine(ResourcePath, "Emojis");
    }
}