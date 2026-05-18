using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StopSoundMMManager : MonoBehaviour
{
    private bool hasLandedInGameScene = false;
    void OnEnable()
    {
       
        // Subscribe to the scene Loaded event
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        // Unsubscribe to prevent memory leaks 
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Check if this is the next scene (replace "NextSceneName")
        if (scene.name == "GameScene (Main)" ) 
        {
            // Stop the sound
           SoundMMManager.Instance.gameObject.SetActive(false);
        }
    }

}