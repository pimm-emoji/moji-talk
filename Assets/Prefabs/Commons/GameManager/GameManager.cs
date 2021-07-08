using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using Newtonsoft.Json.Linq;

/*
    The GameManager Class
    GameManager should be only one.
*/
/// <summary>
/// The GameManager Class
/// GameManager should be only one.
/// <example>
/// <code>
/// GameManager.instance
/// </code>
/// </example>
/// <item>
/// <term>instance</term>
/// <description>Call <c>GameManager.instance</c> when need to use <c>GameManager</c>.</description>
/// </item>
/// </summary>
public class GameManager : MonoBehaviour
{
    /// <summary>
    /// Call <c>GameManager.instance</c> when need to use <c>GameManager</c>.
    /// </summary>
    public static GameManager instance = null;
    
    public Dictionary<string, LevelData> levels;
    public List<string> ProfileIndex;
    public Flow Flow;

    private void Awake()
    {
        // Set GameManager unique.
        if (instance == null) instance = this;
        else if (instance != this) Destroy(this.gameObject);
        DontDestroyOnLoad(this.gameObject);

        // Load Levels Preset.
        LoadLevelsPreset();
    }

    /// <summary>
    /// Loads levels preset in <c>"/Assets/Presets/levels.json"</c>.
    /// This method should be called once at GameManager awakes.
    /// </summary>
    [ContextMenu("Load Levels Preset")]
    public void LoadLevelsPreset()
    {
        levels = PresetController.LoadSingleDepth<LevelData>(
            PresetController.LoadJsonToObject(Configs.LevelIndexPath)
        );
    }
    public Dictionary<string, LevelData> GetLevelsPreset() { LoadLevelsPreset(); return this.levels; }

    [ContextMenu("Load Profile Index")]
    public void LoadProfileIndexPreset()
    {
        ProfileIndex = PresetController.LoadSingleDepth<string>(
            PresetController.LoadJsonToArray(Configs.ProfileIndexPath)
        );
        //print(PresetController.LoadJson(Configs.ProfileIndexPath).GetType());
        /*ProfileIndex = PresetController.LoadSingleList<string>(
            PresetController.LoadJson(Configs.ProfileIndexPath)
        );*/
    }
    public List<string> GetProfileIndexPreset() { LoadProfileIndexPreset(); return this.ProfileIndex; }

    public void LoadLevelFlow(string LevelID)
    {
        Flow.flow = PresetController.LoadSingleDepth<Level>(
            PresetController.LoadJsonToArray(Path.Combine(Configs.LevelDirPath, LevelID, "flow.json"))
        );
    }
    public Flow GetLevelFlow(string LevelID) { LoadLevelFlow(LevelID); return Flow; }


    [ContextMenu("Load Specific Level Flow")]
    public void DebugLoadLevelFlow() { LoadLevelFlow("first"); }

    /*
        The LoadScene Method
        This Method should be enabled when scene number has been assigned.
    // ***********
    /// <summary>
    /// It is recommended to use the GameManager for loading scenes.
    /// This is because most code editors support the reference backlink function,
    /// which makes it convenient to backtrack the scene load code.
    /// <example>
    /// <code>
    /// GameManager.instance.LoadScene(3);
    /// </code>
    /// <code>
    /// GameManager.instance.LoadScene("prev");
    /// </code>
    /// </example>
    /// </summary>
    public void LoadScene(int n)
    {
        SceneManager.LoadScene(n);
    }
    public void LoadScene(string operation)
    {
        int current = SceneManager.GetActiveScene().buildIndex;
        if (operation == "next") SceneManager.LoadScene(current + 1);
        else if (operation == "prev") SceneManager.LoadScene(current - 1);
    }
    */
}
