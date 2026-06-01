using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private const string LEVEL_KEY = "SavedLevel";

    public static void SaveLevel(int levelINdex)
    {
        PlayerPrefs.SetInt(LEVEL_KEY, levelINdex);
        PlayerPrefs.Save();
    }

    public static int LoadLevel()
    {
        return PlayerPrefs.GetInt(LEVEL_KEY, 1);
    }

    public static void DeleteSave()
    {
        PlayerPrefs.DeleteKey(LEVEL_KEY);
    }

    public static bool SaveExists()
    {
        return PlayerPrefs.HasKey(LEVEL_KEY);
    }


}
