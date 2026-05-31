using UnityEngine;
using UnityEngine.SceneManagement;

public class GGameManager : MonoBehaviour
{
  public static GGameManager Instance { get; private set; }

  public PlayerData LoadedData { get; private set; }

  private void Awake()
  {

          if (Instance == null)     
          {
               Instance = this;
               DontDestroyOnLoad(gameObject);
          }

        else
        {
            Destroy(gameObject);
        }
  }
  
    public void OnLoadButtonPressed(string sceneName)
    {
        // 1. Fetch the data right now in the menu scene
        LoadedData = SaveSystem.LoadPlayer();

        if (LoadedData != null)
        {
            Debug.LogWarning("No save file found! Cannot load scene.");
            return;
        }

        SceneManager.LoadScene(sceneName);
    }

    public void ClearLoadedData()
    {
        LoadedData = null;
    }

}

