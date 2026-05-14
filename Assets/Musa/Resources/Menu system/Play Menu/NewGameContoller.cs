using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGameController : MonoBehaviour
{
    public void ChangeScene(string GameScene)
    {
        SSSoundManager.Instance.PlayMusicEffect(SSSoundManager.Instance.EffectSource2.clip);
        SceneManager.LoadScene("GameScene (Main)");
    }
}