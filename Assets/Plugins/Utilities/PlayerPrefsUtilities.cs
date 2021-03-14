using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsUtilities : MonoBehaviour
{
    public string ExitToScene = "LevelSelector";
    public void ClearPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        SceneManagerExtension.LoadSceneWithFades(ExitToScene, 0.5f);
    }
}
