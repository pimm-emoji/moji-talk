using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using Newtonsoft.Json.Linq;

/*
    The GameManager Class
    GameManager should be only one in game.
*/
/// <summary>
/// The GameManager Class
/// GameManager should be only one in game.
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

    // "score" variable is gameflow's score.
    // It must be updated through methods
    // * InitScore()
    // * UpdateScore()
    // * SetScore()
    public float score = 0f;
    
    /*
        These are related to IngamePlayScene.
    */
    public string IngamePlaySceneLevel;
    public LevelData IngamePlaySceneLevelData;
    public List<Profile> IngamePlaySceneParticipants;
    public Flow Flow;

    private void Awake()
    {
        // Set GameManager unique.
        if (instance == null) instance = this;
        else if (instance != this) Destroy(this.gameObject);
        DontDestroyOnLoad(this.gameObject);
    }

    [ContextMenu("Debug InitScore")] public void InitScore() { score = 0f; }
    public void AddScore(float ScoreDelta) { score += ScoreDelta; }
    public void SetScore(float Score) { score = Score; }
    public float GetScore() { return score; }
    [ContextMenu("Debug AddScore (ScoreDelta: 1)")] public void DebugAddScore() { AddScore(1); }
    [ContextMenu("Debug SetScore (Score: 4)")] public void DebugSetScore() { SetScore(4); }
    [ContextMenu("Debug GetScore through Print")] public void DebugGetScore() { print(GetScore()); }

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
