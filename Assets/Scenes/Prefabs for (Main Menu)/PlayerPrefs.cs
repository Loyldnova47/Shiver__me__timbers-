using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class PlayerSaver : MonoBehaviour
{
    // the key is used to identify the saved level data
    private const string LevelKey = "CurrentPlayerLevel";

    public static void SaveLevel(int levelIndex)
    {
        PlayerPrefs.SetInt(LevelKey, levelIndex);
        PlayerPrefs.Save();
        Debug.Log("Level saved: " + levelIndex);
    }

    // This method retrieves the saved level index. If no data is found, it returns 0 (or a default level index).
    public static int LoadLevel()
    {
        return PlayerPrefs.GetInt(LevelKey, 1);  
    }

    public static bool HasSaveData()
    {
        return PlayerPrefs.HasKey(LevelKey);
    }

    public static void LoadAndChangeScene()
    {
        int savedLevel = LoadLevel();

        SceneManager.LoadScene(savedLevel);
    }
}
