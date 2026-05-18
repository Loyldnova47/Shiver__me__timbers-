using UnityEngine;
using UnityEngine.SceneManagement;

public class Re_enable: MonoBehaviour
{
    public GameObject soundMMManager;

    

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Menus")
        {
            SoundMMManager.Instance.gameObject.SetActive(true);
        }
    }
}
