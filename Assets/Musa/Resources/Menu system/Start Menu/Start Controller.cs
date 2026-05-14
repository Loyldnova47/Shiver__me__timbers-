using UnityEngine;
using UnityEngine.SceneManagement;

public class StartController : MonoBehaviour
{
    public AudioClip[] ButtonSound;
    public void ChangeScene(string MainMenu)
    {
        SSSoundManager.Instance.PlayMusicEffect(SSSoundManager.Instance.EffectSource2.clip);
        SceneManager.LoadScene(MainMenu);
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
