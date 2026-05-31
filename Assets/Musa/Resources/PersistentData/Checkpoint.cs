using UnityEngine;

public class Checkpoint : MonoBehaviour
{
   private const string Level_KEY = "SavedLevel";

   public static void SaveLevel(int levelIndex)
   {
      PlayerPrefs.SetInt(Level_KEY, levelIndex);
      PlayerPrefs.Save();
   }

    public static int LoadLevel()
    {
        return PlayerPrefs.GetInt(Level_KEY, 1); //Start at level 1 if no save exists
    }

    public static void DeleteSave()
    {
        PlayerPrefs.DeleteKey(Level_KEY);
    }

    public static bool SaveExists()
    {
        return PlayerPrefs.HasKey(Level_KEY);
    }
}
