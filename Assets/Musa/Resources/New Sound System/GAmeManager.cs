using UnityEngine;
using UnityEngine.SceneManagement;

public class GAmeManager : MonoBehaviour
{
    public GameObject SoundMMManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            Debug.Log("We are in scene 1");
            SoundMMManager.SetActive(true);
        }

        Debug.Log(SceneManager.GetActiveScene().name);
    }
}
