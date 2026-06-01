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

    public static void SavePrologueState(bool hasPlayed)
    {
        PlayerPrefs.SetInt("ProloguePlayed", hasPlayed ? 1 : 0);
        PlayerPrefs.Save();
    }

    public static bool HasPlayedPrologue()
    {
        return PlayerPrefs.GetInt("ProloguePlayed", 0) == 1;
    }
}
