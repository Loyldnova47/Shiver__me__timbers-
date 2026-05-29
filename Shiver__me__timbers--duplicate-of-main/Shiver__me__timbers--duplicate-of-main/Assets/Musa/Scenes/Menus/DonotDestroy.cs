using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DonotDestroy : MonoBehaviour
{
    private void Awake()
    {
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("GameMusic");
        if (musicObj.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    public class MusicTransition : MonoBehaviour
    {
        private static MusicTransition instance;
        public string stopAtScene = "GameScene (Main)";
        private AudioSource audioSource;

        void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(instance);
                SceneManager.sceneLoaded += OnSceneLoaded;
            }
            else
            {
                Destroy(gameObject);
                return;
            }

            instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();
        }

        void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (scene.name == stopAtScene)
            {
                audioSource.Stop();
            }
            else if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }

            {    Destroy(gameObject);
                Debug.Log("The music stopped!");
            }
        }
    }

}
